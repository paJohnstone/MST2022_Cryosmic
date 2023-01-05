using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour
{

    public Rigidbody2D rangedAttack;
    public float speed = 2;
    public float ttime;
    public bool left = false;
    public bool right = true;
    public GameObject pooof;
    public GameObject rangedSpawner;

    // Start is called before the first frame update
    void Start()
    {
        rangedSpawner = GameObject.FindWithTag("Spawner1");
        rangedAttack = GetComponent<Rigidbody2D>();
        ttime = 1.6f;
        if (right == true)
        {
            pooof.GetComponent<ForestExplode>().right = true;
            pooof.GetComponent<ForestExplode>().left = false;
            rangedAttack.AddForce(new Vector2(3f, 2f) * speed, ForceMode2D.Impulse);

        }
        if (left == true)
        {
            pooof.GetComponent<ForestExplode>().right = false;
            pooof.GetComponent<ForestExplode>().left = true;
            rangedAttack.AddForce(new Vector2(-3f, 2f) * speed, ForceMode2D.Impulse);

        }
    }

    // Update is called once per frame
    void Update()
    {
        rangedSpawner.GetComponent<ForestRange>().onlyOne = true;

        if (ttime > 0)
        {
            ttime = ttime - (1 * Time.deltaTime);

        }
        if (ttime < 0)
        {
            pooof.GetComponent<ForestExplode>().timer = true;
            ttime = 0;
            Destroy(gameObject);
            Instantiate(pooof, transform.position, transform.rotation);
            rangedSpawner.GetComponent<ForestRange>().onlyOne = false;

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            pooof.GetComponent<ForestExplode>().timer = false;
            rangedSpawner.GetComponent<ForestRange>().onlyOne = false;
            Destroy(gameObject);
            Instantiate(pooof, transform.position, pooof.transform.rotation);

        }


    }

}

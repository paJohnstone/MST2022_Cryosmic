using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotAttack : MonoBehaviour
{

    public Rigidbody2D rangedAttack;
    public float speed = 2;
    public float ttime;
    public float time2;
    public bool left = false;
    public bool right = true;
    public GameObject rangedSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
        
        rangedSpawner.GetComponent<CowboyRanged>().onlyOne = true;
        rangedAttack = GetComponent<Rigidbody2D>();
        ttime = 1.2f;
        time2 = 0.3f;
        if (right == true)
        {

            rangedAttack.AddForce(new Vector2(6f, 0f) * speed, ForceMode2D.Impulse);

        }
        if (left == true)
        {

            rangedAttack.AddForce(new Vector2(-6f, 0f) * speed, ForceMode2D.Impulse);

        }
    }

    // Update is called once per frame
    void Update()
    {
       // rangedSpawner.GetComponent<CowboyRanged>().onlyOne = true;

        if (ttime > 0)
        {
            ttime = ttime - (1 * Time.deltaTime);

        }
        if (ttime < 0)
        {

            ttime = 0;
            Destroy(gameObject);


        }



        if (time2 > 0)
        {
            time2 = time2 - (1 * Time.deltaTime);

        }
        if (time2 < 0)
        {

            time2 = 0;

            rangedSpawner.GetComponent<CowboyRanged>().onlyOne = false;

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {

            rangedSpawner.GetComponent<CowboyRanged>().onlyOne = false;
            rangedAttack.constraints = RigidbodyConstraints2D.None;
            ttime = 0.2f;

        }


        if (collision.gameObject.tag.Equals("Player"))
        {

            rangedSpawner.GetComponent<CowboyRanged>().onlyOne = false;
            rangedAttack.constraints = RigidbodyConstraints2D.None;
            time2 = 0.3f;
        }

    }


}

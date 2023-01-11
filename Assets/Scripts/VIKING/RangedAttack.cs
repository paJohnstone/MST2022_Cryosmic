using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

    public Rigidbody2D rangedAttack;
    public float speed = 2;
    public float ttime;
    public bool left = false;
    public bool right = true;
    public GameObject rangedSpawner;
    public bool spin;

    // Start is called before the first frame update
    void Start()
    {
        spin = false;
        rangedAttack = GetComponent<Rigidbody2D>();
        ttime = 1.6f;
        
        if (right == true)
        {
            rangedAttack.AddForce(new Vector2(2.5f, 1.5f) * speed, ForceMode2D.Impulse);

        }
        if (left == true)
        {
            
            rangedAttack.AddForce(new Vector2(-2.5f, 1.5f) * speed, ForceMode2D.Impulse);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spin == false)
        {
            transform.Rotate(0, 0, -1);
            rangedSpawner.GetComponent<VikingRanged>().onlyOne = true;
        }
        
        

        if (ttime > 0)
        {
            ttime = ttime - (1 * Time.deltaTime);

        }
        if (ttime < 0)
        {
            
            ttime = 0;
            Destroy(gameObject);
            
            rangedSpawner.GetComponent<VikingRanged>().onlyOne = false;

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            
            rangedSpawner.GetComponent<VikingRanged>().onlyOne = false;
            spin = true;
            rangedAttack.velocity = Vector3.zero;
            rangedAttack.angularVelocity = 0;

        }


        if (collision.gameObject.tag.Equals("Player"))
        {
            
            rangedSpawner.GetComponent<VikingRanged>().onlyOne = false;

            spin = true;
            rangedAttack.velocity = Vector3.zero;
            rangedAttack.angularVelocity = 0;


        }

    }
}

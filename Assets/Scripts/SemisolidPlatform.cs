using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemisolidPlatform : MonoBehaviour
{
    public float semiWait;
    private bool seeThrough;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            semiWait = 5;
            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
        }
        if (semiWait <= 0)
        {
            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
            semiWait = 5;
        }
        else
        {
            semiWait -= Time.fixedDeltaTime;
        }


    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        if (Input.GetKeyDown(KeyCode.DownArrow))
    //        {
    //            semiWait = 0.5f;
    //            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
    //        }
    //        if (semiWait <= 0)
    //        {
    //            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
    //        }
    //        else
    //        {
    //            semiWait -= Time.fixedDeltaTime;
    //        }
    //    }
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        if (Input.GetKeyDown(KeyCode.DownArrow))
    //        {
    //            semiWait = 0.5f;
    //            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
    //        }
    //        if (semiWait <= 0)
    //        {
    //            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
    //        }
    //        else
    //        {
    //            semiWait -= Time.fixedDeltaTime;
    //        }
    //    }
    //}
    // This was attempting to make it so that it is only when a player is on the platform it will let them through, as opposed to every platform in the match
}

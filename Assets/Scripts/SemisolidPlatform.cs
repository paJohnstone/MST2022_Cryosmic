using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemisolidPlatform : MonoBehaviour
{
    private float semiWait;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            semiWait = 1;
            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
        }
        if (semiWait <= 0)
        {
            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
            semiWait = 1;
        }
        else
        {
            semiWait -= Time.fixedDeltaTime;
        }
    }
}

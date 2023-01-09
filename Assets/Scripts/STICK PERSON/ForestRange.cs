using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestRange : MonoBehaviour
{
    public Rigidbody2D rangedAttack;
    public float ttime;
    public GameObject rangedPrefab;
    public bool activeRanged = false;
    public float speed = 2;
    public GameObject meleeSpawner;
    public bool meleeActive;
    public bool onlyOne = false;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        meleeActive = meleeSpawner.GetComponent<ForestMelee>().activeMelee;
        if (activeRanged == false)
        {
            if (Input.GetKeyDown(KeyCode.Z) && meleeActive == false && onlyOne == false && player.GetComponent<Controller>().hitStun == false)
            {
                
                ttime = 2f;
                Instantiate(rangedPrefab, transform.position, rangedPrefab.transform.rotation);
            }

            //Instantiate
            //Instantiate(meleePrefab, transform.position, meleePrefab.transform.rotation);


        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rangedPrefab.GetComponent<Ranged>().left = true;
            rangedPrefab.GetComponent<Ranged>().right = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rangedPrefab.GetComponent<Ranged>().left = false;
            rangedPrefab.GetComponent<Ranged>().right = true;
        }
    }
}

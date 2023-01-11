using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestMelee : MonoBehaviour
{

    public GameObject meleePrefab;
    public GameObject forestGet;
    public GameObject player;
    public float ttime;
    public float speed;
    public bool activeMelee;

    // Start is called before the first frame update
    void Start()
    {
        //forestGet = FindObjectOfType<GameObject>().CompareTag<>  for not being able to attack in hitstun


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && player.GetComponent<Controller>().hitStun == false)
        {
            meleePrefab.SetActive(true);
            activeMelee = true;
            ttime = 0.3f;

        }
        if (activeMelee == true)
        {


            // Launch a melee attack
            //Instantiate(meleePrefab, transform.position, meleePrefab.transform.rotation);

            if (ttime > 0)
            {

                ttime = ttime - (1 * Time.deltaTime);
            }
            if (ttime < 0)
            {
                ttime = 0;
                meleePrefab.SetActive(false);
                activeMelee = false;
            }
        }
    }
}

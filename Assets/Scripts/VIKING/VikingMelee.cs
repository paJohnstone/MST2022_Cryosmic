using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class VikingMelee : MonoBehaviour
{

    public GameObject meleePrefab;
    public GameObject meleePrefab2;
    public GameObject player;
    public float ttime;
    public bool activeMelee;
    public bool activeMelee2;
    public bool smash = false;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad.buttonWest.wasPressedThisFrame && player.GetComponent<VikingController>().hitStun == false)
        {
            meleePrefab.SetActive(true);
            activeMelee = true;
            ttime = 0.3f;
            smash = true;
        }
        {


            // Launch a melee attack
            //Instantiate(meleePrefab, transform.position, meleePrefab.transform.rotation);

            if (ttime > 0)
            {

                ttime = ttime - (1 * Time.deltaTime);
            }
            if (ttime < 0 && activeMelee2 == false)
            {
                
                meleePrefab.SetActive(false);
                activeMelee = false;
                ttime = 0.8f;
                meleePrefab2.SetActive(true);
                activeMelee2 = true;
                
            }
            if (ttime < 0 && activeMelee2 == true)
            {
                meleePrefab2.SetActive(false);
                activeMelee2 = false;
                ttime = 0;
                smash = false;
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VikingRanged : MonoBehaviour
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
        var gamepad = Gamepad.current;
        meleeActive = meleeSpawner.GetComponent<VikingMelee>().activeMelee;
        if (activeRanged == false)
        {
            if (gamepad.buttonEast.wasPressedThisFrame && meleeActive == false && onlyOne == false && player.GetComponent<VikingController>().hitStun == false)
            {

                ttime = 2f;
                if(rangedPrefab.GetComponent<RangedAttack>().left == true)
                {
                    Instantiate(rangedPrefab, transform.position + new Vector3 (-0.4f, 0), rangedPrefab.transform.rotation);
                }

                if (rangedPrefab.GetComponent<RangedAttack>().right == true)
                {
                    Instantiate(rangedPrefab, transform.position + new Vector3(0.4f, 0), rangedPrefab.transform.rotation);
                }

            }

            


        }
        Vector2 move = gamepad.leftStick.ReadValue();
        if ((move.x < 0))
        {
            rangedPrefab.GetComponent<RangedAttack>().left = true;
            rangedPrefab.GetComponent<RangedAttack>().right = false;
        }
        if (move.x > 0)
        {
            rangedPrefab.GetComponent<RangedAttack>().left = false;
            rangedPrefab.GetComponent<RangedAttack>().right = true;
        }
    }
}

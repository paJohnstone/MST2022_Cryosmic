using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{

    public float dashDistance = 15f;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;
    public Rigidbody2D playerR;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;

        if (gamepad.leftTrigger.wasPressedThisFrame)
        {

            StartCoroutine(Dashing(-1f));



        }

        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            //dashing right
            StartCoroutine(Dashing(1f));
        }

    }


    IEnumerator Dashing(float direction)
    {
        isDashing = true;

        playerR.velocity = new Vector2(playerR.velocity.x, playerR.velocity.y);
        playerR.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        //float gravity = playerR.gravityScale;
        //playerR.gravityScale = put something here
        yield return new WaitForSeconds(0.25f);

        isDashing = false;
    }
}



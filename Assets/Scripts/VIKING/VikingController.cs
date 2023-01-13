using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VikingController : MonoBehaviour
{
    public Rigidbody2D playerR;
    public GameObject meleeSpawner;
    public bool isOnGround = true;
    public bool hitStun = false;
    //private bool freeze = false;
    public float knockbackStrength = 8f;
    public float jumpForce = 12.0f;
    public float hitStunTime = 0;
    public bool meleeActive;
    public bool meleeSmash = false;
    private bool right;
    private bool left;
    private float horizontalInput;
    public float speed = 0.008f;
    private float semiWait;
    private bool isInvincible;
    public Vector3 hit;

    

    [SerializeField]
    private float invincibilityDurationSeconds;

    [SerializeField]
    private float invincibilityDeltaTime;

    [SerializeField]
    private GameObject model;


    // Start is called before the first frame update
    void Start()
    {
        playerR = GetComponent<Rigidbody2D>();
        hitStunTime = 0;


    }

    

    // Update is called once per frame
    void Update()
    {
        Movement();
        constraints();
        hitSTUN();
        meleeActive = meleeSpawner.GetComponent<VikingMelee>().activeMelee;
        meleeSmash = meleeSpawner.GetComponent<VikingMelee>().smash;
    }

    void Movement()
    {
        var gamepad = Gamepad.current;
        if (gamepad.buttonSouth.wasPressedThisFrame && isOnGround && hitStun == false && meleeSmash == false)
        {
            playerR.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;


        }

        if (gamepad.leftShoulder.wasPressedThisFrame && isOnGround && hitStun == false && meleeSmash == false)
        {
            playerR.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;


        }
        Vector2 move = gamepad.leftStick.ReadValue();
        if (move.x > 0)
        {
            right = true;
            left = false;
        }
        else if (move.x < 0)
        {
            right = false;
            left = true;
        }
        else if (move.x == 0)
        {
            return;
        }
        if (hitStun == false && right && meleeSmash == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            playerR.transform.Translate(Vector2.right * speed * move);
        }

        else if (hitStun == false && left && meleeSmash == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            playerR.transform.Translate(Vector2.left * speed * move);
        }


    }

    void constraints()
    {
        if (left && hitStun == false && meleeActive == false && meleeSmash == false)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (right && hitStun == false && meleeActive == false && meleeSmash == false)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

        }








        if (collision.gameObject.tag.Equals("Danger") && isInvincible == false)
        {
            hit = collision.contacts[0].normal;
            Debug.Log(hit);
            float angle = Vector3.Angle(hit, Vector3.up);

            if (Mathf.Approximately(angle, 0))
            {
                //Down
                //Debug.Log("Down");
            }
            if (Mathf.Approximately(angle, 180))
            {
                //Up
                //Debug.Log("Up");
            }
            if (Mathf.Approximately(angle, 90))
            {
                // Sides
                //Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                //if (cross.y > 0)
                //{ // left side of the player
                //    Debug.Log("Left");
                //}
                //else
                //{ // right side of the player
                //    Debug.Log("Right");
                //}
            }
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 toTarget = (collision.gameObject.transform.position - transform.position).normalized;

        if (Vector3.Dot(toTarget, gameObject.transform.forward) > 0 && isInvincible == false)
        {
            hit = new Vector3(1, 0.25f, 0);
            //Debug.Log("from front");
        }
        else
        {
            hit = new Vector3(-1, 0.25f, 0);
            //Debug.Log("from back");
        }


        //if (collision.gameObject.tag.Equals("Danger"))
        //{
        //    //hit = collision.GetContacts[0].normal;
        //    //Debug.Log(hit);
        //    float angle = Vector3.Angle(hit, Vector3.up);

        //    if (Mathf.Approximately(angle, 0))
        //    {
        //        //Down
        //        //Debug.Log("Down");
        //    }
        //    if (Mathf.Approximately(angle, 180))
        //    {
        //        //Up
        //        //Debug.Log("Up");
        //    }
        //    if (Mathf.Approximately(angle, 90))
        //    {
        //        // Sides
        //        //Vector3 cross = Vector3.Cross(Vector3.forward, hit);
        //        //if (cross.y > 0)
        //        //{ // left side of the player
        //        //    Debug.Log("Left");
        //        //}
        //        //else
        //        //{ // right side of the player
        //        //    Debug.Log("Right");
        //        //}
        //    }
        //}



        if (collision.gameObject.CompareTag("Danger") && isInvincible == false)
        {
            hitStun = true;
            hitStunTime = 0.5f;
            //Collider2D enemyRigidbody = collision.gameObject.GetComponent<Collider2D>();
            //Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);
            if (!isInvincible)
            {
                StartCoroutine(BecomeTemporarilyInvincible());
            }
        }

        //Delete Tags correleted with the character using said tags. Forest Being: 1 and 2;   Cowboy: 3 and 4;   Viking: 5 and 6;   Failed Experiment: 7 and 8;
        //if (collision.gameObject.CompareTag("Danger1") && isInvincible == false)
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger2") && isInvincible == false)
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger3") && isInvincible == false)
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger4") && isInvincible == false)
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger5") && isInvincible == false)
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger6") && isInvincible == false)
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger7") && isInvincible == false)
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger8") && isInvincible == false)
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
    }




    void hitSTUN()
    {
        if (hitStun == true)
        {

            if (hitStunTime > 0)
            {
                hitStunTime = hitStunTime - (1 * Time.deltaTime);
            }
            if (hitStunTime < 0)
            {
                hitStunTime = 0;
                hitStun = false;
            }
        }
    }

    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }
    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            // Alternate between 0 and 1 scale to simulate flashing
            if (model.transform.localScale == new Vector3(3, 3, 3))
            {
                ScaleModelTo(new Vector3(0, 0, 0));
            }
            else
            {
                ScaleModelTo(new Vector3(3, 3, 3));
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        Debug.Log("Player is no longer invincible!");
        ScaleModelTo(new Vector3(3, 3, 3));
        isInvincible = false;
    }
}

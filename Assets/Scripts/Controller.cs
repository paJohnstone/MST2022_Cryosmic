using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
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
    private bool right;
    private bool left;
    private float horizontalInput;
    public float speed = 0.008f;
    private float semiWait;
    public Vector3 hit;



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
        meleeActive = meleeSpawner.GetComponent<ForestMelee>().activeMelee;
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && hitStun == false)
        {
            playerR.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;


        }

        if (hitStun == false && right)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            playerR.transform.Translate(Vector2.right * speed * horizontalInput);
        }

        else if (hitStun == false && left)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            playerR.transform.Translate(Vector2.left * speed * horizontalInput);
        }
    }
    void constraints()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && hitStun == false && meleeActive == false)
        {
            transform.eulerAngles = new Vector2(0, 180);
            left = true;
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && hitStun == false && meleeActive == false)
        {
            transform.eulerAngles = new Vector2(0, 0);
            left = false;
            right = true;
        }
    }
     
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

        }


        
        




        if (collision.gameObject.tag.Equals("Danger"))
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

        if (Vector3.Dot(toTarget, gameObject.transform.forward) > 0)
        {
            hit = new Vector3(1, 0.25f, 0);
            //Debug.Log("from front");
        }
        else
        {
            hit = new Vector3(-1, 0, 0);
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



        if (collision.gameObject.CompareTag("Danger"))
        {
            hitStun = true;
            hitStunTime = 2;
            //Collider2D enemyRigidbody = collision.gameObject.GetComponent<Collider2D>();
            //Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        }

        //Delete Tags correleted with the character using said tags. Forest Being: 1 and 2;   Cowboy: 3 and 4;   Viking: 5 and 6;   Failed Experiment: 7 and 8;
        //if (collision.gameObject.CompareTag("Danger1"))
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger2"))
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger3"))
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger4"))
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger5"))
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger6"))
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger7"))
        //{
        //    hitStun = true;
        //    hitStunTime = 2;
        //    playerR.AddForce(hit * knockbackStrength, ForceMode2D.Impulse);

        //}
        //if (collision.gameObject.CompareTag("Danger8"))
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
}
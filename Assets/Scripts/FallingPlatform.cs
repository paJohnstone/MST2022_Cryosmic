using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    private Rigidbody2D fprb;
    private BoxCollider2D fpbc;
    public GameObject respawnPosition1;
    private Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        
        fprb = GetComponent<Rigidbody2D>();
        fpbc = GetComponent<BoxCollider2D>();
        initialPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.transform.position.y > gameObject.transform.position.y)
        {
            Debug.Log("Awesome");
            Invoke("PlatformDrop", 0.5f);
            
        }

    }

    void PlatformDrop()
    {
        fprb.isKinematic = false;
        fpbc.enabled = false;
        Invoke("PlatformSetInactive", 1f);
    }

    void PlatformSetInactive()
    {
        gameObject.SetActive(false);
        Invoke("PlatformRespawn", 2f);
    }

    void PlatformRespawn()
    {
        gameObject.transform.position = initialPosition;
        gameObject.SetActive(true);
        fprb.isKinematic = true;
        fpbc.enabled = true;
    }



}

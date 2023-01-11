using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public float healthMax;
    public float healthCur;
    private GameObject healthPlayer;
    [SerializeField]
    private GameObject healthGreen;
    private float percent;
    // Start is called before the first frame update
    void Start()
    {
        healthCur = healthMax; 
    }

    // Update is called once per frame
    void Update()
    {
        percent = healthCur / healthMax;
        healthGreen.transform.localScale = new Vector3(percent, healthGreen.transform.localScale.y, healthGreen.transform.localScale.z);
        
    }
    //make sure to put this in your script using "public HealthBar healthScript;" or something like that and selecting the healthbar. ask me to figure out how to use multiple later
    //use the commented code below to deal damage with your hitboxes (i hope), just you know, make sure it has the correct tag
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        //healthScript = collision.gameObject.GetComponent<HealthBar>();
        //healthScript.healthCur - 20;
    //}
}
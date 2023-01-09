using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestExplode : MonoBehaviour
{

    private float ttime;
    private float expand = 0.7f;
    private float minScale = 0.7f;
    private float maxScale = 3f;
    public bool left = false;
    public bool right = true;
    public bool timer = false;
    public Rigidbody2D explode;

    // Start is called before the first frame update
    void Start()
    {
        ttime = 1.2f;
        expand = 0.7f;
        if (right == true && timer == false)
        {
            explode.AddForce(new Vector2(4f, 2f), ForceMode2D.Impulse);

        }
        if (left == true && timer == false)
        {
            explode.AddForce(new Vector2(-4f, 2f), ForceMode2D.Impulse);

        }
        if (right == true && timer == true)
        {
            explode.AddForce(new Vector2(2f, 0f), ForceMode2D.Impulse);

        }
        if (left == true && timer == true)
        {
            explode.AddForce(new Vector2(-2f, 0f), ForceMode2D.Impulse);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ttime > 0)
        {
            ttime = ttime - (1 * Time.deltaTime);
            expand = expand + (1 * Time.deltaTime) * 0.3f;

            Expando();
        }
        if (ttime < 0)
        {
            ttime = 0;
            Destroy(gameObject);
        }



    }
    void Expando()
    {
        Vector3 vec = new Vector3((expand), (expand), (expand));

        transform.localScale = vec;
    }
}

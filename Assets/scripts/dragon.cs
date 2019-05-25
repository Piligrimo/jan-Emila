using UnityEngine;
using System.Collections;

public class dragon : MonoBehaviour {

    Rigidbody2D rb;
    bool right=false;
    int i = 0;

    public float spd = 1;
    Vector3[] tar = { new Vector3(108, - 3, 0), new Vector3(108, 3, 0), new Vector3(115, 3, 0), new Vector3(115,- 3, 0) };
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        float d = (transform.position - tar[i]).magnitude;
        rb.velocity = new Vector2(spd * (tar[i].x - transform.position.x) / d, spd * (tar[i].y - transform.position.y) / d); 
        if ((right && rb.velocity.x<0)|| (!right && rb.velocity.x > 0))
        {
            right = !right;
            transform.Rotate(0, 180, 0);
        }
        if (d<0.1)
        {
            i = (i + 1) % 4;
        }
    }
   
    
 

}

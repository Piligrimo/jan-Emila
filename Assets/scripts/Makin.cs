using UnityEngine;
using System.Collections;

public class Makin : MonoBehaviour {
    public float lvlend;
    Rigidbody2D rb;
    bool m;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x - GameObject.Find("Emila").transform.position.x < 12)
            m = true;
        if (m) 
            rb.velocity = new Vector2(4.5f, rb.velocity.y);
        if (transform.position.x > lvlend)
            Destroy(gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uberenemy : MonoBehaviour {
    Rigidbody2D rb;
    GameObject player,pencil=null;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Emila");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.value-0.5f,Random.value-0.5f).normalized*5;
	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce((player.transform.position - transform.position));
        if (player.transform.position.x < transform.position.x)
            transform.rotation = Quaternion.Euler(0,0,12);
        else
            transform.rotation = Quaternion.Euler(0, 180, 12);
        if (rb.velocity.magnitude > 7)
            rb.velocity=rb.velocity.normalized*7;
        if (pencil != null)
            if (!pencil.GetComponent<Collider2D>().isTrigger)
            {
                Destroy(pencil);
                Destroy(gameObject);
            }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<destroidrawing>() != null)
            if (other.GetComponent<Collider2D>().isTrigger)
                pencil = other.gameObject;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<destroidrawing>() != null)
            pencil = null;
    }
}

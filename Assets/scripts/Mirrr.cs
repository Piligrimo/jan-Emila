using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirrr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ammo")
        {
            other.gameObject.GetComponent<Slowball>().starttime = Time.time;
            other.gameObject.GetComponent<Slowball>().reflected = true;
            Vector2 v = other.gameObject.GetComponent<Rigidbody2D>().velocity;
            other.gameObject.GetComponent<Rigidbody2D>().velocity= new Vector2(v.x,-v.y);
        }
    }
}

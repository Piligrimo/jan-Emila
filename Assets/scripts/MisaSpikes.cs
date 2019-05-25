using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisaSpikes : MonoBehaviour {
     GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Emila");
    }
	
	// Update is called once per frame
	void Update () {
   
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Emila" || other.gameObject.name == "leg")
        {
            player.GetComponent<Rigidbody2D>().freezeRotation = false;
            player.GetComponent<Controll>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value * 7, Random.value * 25);
            player.GetComponent<Rigidbody2D>().angularVelocity = Random.value * 180;
            for (int i = 0; i < player.GetComponents<Collider2D>().Length; i++)
                player.GetComponents<Collider2D>()[i].enabled = false;
            for (int i = 0; i < player.GetComponentsInChildren<Collider2D>().Length; i++)
                player.GetComponentsInChildren<Collider2D>()[i].enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowscript : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Emila");
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < 2)
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,28));
	}
}

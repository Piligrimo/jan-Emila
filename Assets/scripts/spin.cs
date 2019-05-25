using UnityEngine;
using System.Collections;

public class spin : MonoBehaviour {
    GameObject btn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().angularVelocity = 20;
	}
}

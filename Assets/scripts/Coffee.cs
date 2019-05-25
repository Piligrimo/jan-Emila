using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Emila")
        {
            
            GameObject.FindGameObjectWithTag("cap").GetComponent<Captain>().sleepy = -57;
            gameObject.SetActive(false);
        }
    }
}

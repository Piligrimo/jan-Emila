using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakInPrison : MonoBehaviour {
    public GameObject Meka;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Emila" || other.gameObject.name == "leg")
        {
            GetComponent<Animator>().SetTrigger("catch");
            Meka.SetActive(true);
        }
    }
}

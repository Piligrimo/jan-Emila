using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour {
    public GameObject blowingHead;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Emila")
            blowingHead.GetComponent<Animator>().SetBool("blow", true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Emila")
            blowingHead.GetComponent<Animator>().SetBool("blow", false);
    }

}

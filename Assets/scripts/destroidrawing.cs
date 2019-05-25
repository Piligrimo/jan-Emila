using UnityEngine;
using System.Collections;

public class destroidrawing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per fram
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "red" && gameObject==GameObject.Find("Main Camera").GetComponent<drawscript>().newone)
        {
            GameObject.Find("Main Camera").GetComponent<drawscript>().crossred = true;
        }

    }
}

using UnityEngine;
using System.Collections;

public class leg : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "floor" )
           GetComponentInParent<Controll>().onground = true;

    }
    //void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "floor")
    //        GetComponentInParent<Controll>().onground = false;

    //}
}

using UnityEngine;
using System.Collections;

public class gravitychg : MonoBehaviour {
    public GameObject go;
    bool prev;
    public float q = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	if (GetComponent<Animator>().GetBool("prss"))
            go.GetComponent<Rigidbody2D>().gravityScale = -1*q;
     else
            go.GetComponent<Rigidbody2D>().gravityScale = 1*q;

    }
}

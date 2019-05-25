using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
    Animator an;
	// Use this for initialization
	void Start () {
        an = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = transform.position - GameObject.Find("Emila").transform.position;
        an.SetBool("prss", v.magnitude<0.3);
    }
   
}

using UnityEngine;
using System.Collections;

public class Spiketrep : MonoBehaviour {
    public GameObject button;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Animator>().SetBool("active", button.GetComponent<Animator>().GetBool("prss"));
	}
}

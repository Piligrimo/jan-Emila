using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    public float freq,shift;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Animator>().SetBool("active",Mathf.FloorToInt(shift+Time.time*freq)%2==0);
	}
}

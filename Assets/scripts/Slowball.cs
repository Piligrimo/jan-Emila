using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowball : MonoBehaviour {
    public float starttime;
    public bool reflected = false;
	// Use this for initialization
	void Start () {
        starttime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - starttime > 3)
            Destroy(gameObject);
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Emila")
        {
            other.gameObject.GetComponent<Controll>().sloweffect = 2;
            GetComponent<Animator>().SetTrigger("die");
            GameObject.FindGameObjectWithTag("cap").GetComponent<Captain>().sleepy += 3;
            GetComponent<Collider2D>().enabled = true;
        }
    }
}

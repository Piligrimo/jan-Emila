using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {
    public GameObject pref;
    public float period;
    public float spawntime= Time.time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > spawntime)
        {
            Instantiate(pref,transform.position,transform.rotation);
            spawntime += period;
        }
    }
}

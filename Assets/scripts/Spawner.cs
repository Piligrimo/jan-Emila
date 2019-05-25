using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject pref;
    GameObject cur;
    public float delay, time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (cur == null && time >= 0)
            time -= Time.deltaTime;
        if (time < 0)
        {
            cur = Instantiate(pref, transform.position, transform.rotation) as GameObject;
            time = delay;
        }
	}
}

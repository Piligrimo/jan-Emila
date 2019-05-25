using UnityEngine;
using System.Collections;

public class fall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -30)
            Destroy(gameObject);
	}
}

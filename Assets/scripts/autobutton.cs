using UnityEngine;
using System.Collections;

public class autobutton : MonoBehaviour {
    public bool active;
    float t;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (active)
        {
            t += Time.deltaTime;
            if (t > 1)
            {
                t = 0;
                GetComponent<Animator>().SetBool("prss",!GetComponent<Animator>().GetBool("prss"));
            }
        }
	}
}

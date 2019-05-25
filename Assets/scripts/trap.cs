using UnityEngine;
using System.Collections;

public class trap : MonoBehaviour {
    public GameObject button,arrow;
    bool active;
    public float speed = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!active && button.GetComponent<Animator>().GetBool("prss"))
        {
           GameObject a = Instantiate(arrow, transform.position, transform.rotation) as GameObject;
            a.GetComponent<arrow>().speed = speed;
        }
        active = button.GetComponent<Animator>().GetBool("prss");

    }
}

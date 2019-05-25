using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {
    public GameObject go,pref;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Animator>().GetBool("prss"))
        {
                Destroy(go);
                GameObject n = Instantiate(pref) as GameObject;
                go = n;
        }
    }
}

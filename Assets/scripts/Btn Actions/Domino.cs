using UnityEngine;
using System.Collections;

public class Domino : MonoBehaviour {
    public GameObject[] doms =new GameObject[7];
    public GameObject[] domprefs = new GameObject[7];
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (GetComponent<Animator>().GetBool("prss"))
        {
            for (int i = 0; i < 7; i++)
            {
                Destroy(doms[i]);
                GameObject n = Instantiate(domprefs[i]) as GameObject;
                doms[i] = n;
            }
        }
	}
}

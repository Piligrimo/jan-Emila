using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour {
    public GameObject[] Parts,EmisParts;
    public GameObject Mirror;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 3; i++)
            Parts[i].transform.localPosition = EmisParts[i].transform.localPosition;
        Parts[2].transform.localRotation = EmisParts[2].transform.localRotation;
        float y = EmisParts[3].transform.position.y - Mirror.transform.position.y-0.5f;
        if (EmisParts[3].transform.position.x > 380 && EmisParts[3].transform.position.x < 397)
            Parts[3].transform.position = new Vector3(EmisParts[3].transform.position.x, Mirror.transform.position.y - y, 0);
        else
            Parts[3].transform.position = new Vector3(300, -100, 0);
        Parts[3].transform.rotation = EmisParts[3].transform.rotation;
    }
}

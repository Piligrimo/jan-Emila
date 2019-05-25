using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {
    Animator an;
    public GameObject btn;
    // Use this for initialization
    void Start()
    {
        an = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update () {
        an.SetBool("ph", btn.GetComponent<Animator>().GetBool("prss"));
	}
}

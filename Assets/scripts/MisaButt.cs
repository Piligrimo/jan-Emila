using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisaButt : MonoBehaviour {
    public GameObject Misa, Emila;
    Animator an;
    // Use this for initialization
    void Start()
    {
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v1 = transform.position - Emila.transform.position,
                v2 = transform.position - Misa.transform.position;
        an.SetBool("prss", v1.magnitude < 0.3 || v2.magnitude < 0.3);
    }
}

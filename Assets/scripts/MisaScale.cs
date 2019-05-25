using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisaScale : MonoBehaviour {
    Vector3 trueScale;
    public Text mashtab;
    float curQuoph=1, dir=0.5f;
	// Use this for initialization
	void Start () {
        trueScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(curQuoph);
        if (curQuoph.ToString().Length>3)
            mashtab.text = "Масштаб 1:"+curQuoph.ToString().Substring(0,3);
        else
            mashtab.text = "Масштаб 1:" + curQuoph.ToString();
        curQuoph += dir * Time.deltaTime;
        if ((curQuoph > 2 && dir>0) || (curQuoph < 1 && dir<0))
            dir *= -1;
        transform.localScale = trueScale * curQuoph;
	}
}

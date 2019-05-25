using UnityEngine;
using System.Collections;

public class pencil : MonoBehaviour {
    public Camera cam;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    Vector3 v = transform.position - cam.ScreenToWorldPoint( Input.mousePosition);
        if (GetComponentInParent<Controll>().right)
	        transform.rotation= Quaternion.Euler(0,0, Mathf.Atan2(v.y, v.x) * 180 / 3.1415926f+130);
        else
            transform.rotation = Quaternion.Euler(0, 180, -Mathf.Atan2(v.y, v.x) * 180 / 3.1415926f-60);
    }
}

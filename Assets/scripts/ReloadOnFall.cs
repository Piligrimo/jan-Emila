using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadOnFall : MonoBehaviour {
    public GameObject World, WorldPreset, Misa,cam;
    Transform Startransform;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -10)
        {
            Destroy(World);
            World = Instantiate(WorldPreset) as GameObject;
            GetComponent<Rigidbody2D>().freezeRotation = true;
            GetComponent<Controll>().enabled = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            transform.rotation = Quaternion.EulerAngles(0, 0, 0);
            if (!GetComponent<Controll>().right)
                transform.Rotate(0, 180, 0);
            transform.position = GetComponent<Controll>().checkpoint;
            for (int i = 0; i < gameObject.GetComponents<Collider2D>().Length; i++)
                GetComponents<Collider2D>()[i].enabled = true;
            for (int i = 0; i < GetComponentsInChildren<Collider2D>().Length; i++)
                GetComponentsInChildren<Collider2D>()[i].enabled = true;
            Misa.transform.position = new Vector3(transform.position.x - 10, 4.3f, 0);
            cam.transform.position = new Vector3(transform.position.x, .1f, -10);
        }
	}
}

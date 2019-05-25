using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigMisa : MonoBehaviour {
    bool intro = true,BeSmall=false;
    public Text[] scale;
    public GameObject cam;
    float prev = 0;
	// Use this for initialization
	void Start () {
        scale[0].enabled = false;
        transform.localScale = new Vector3(-0.4f, 0.4f, 1);

    }
	
	// Update is called once per frame
	void Update () {
		if (intro)
        {
            scale[0].text = "Мастшаб " + (Mathf.RoundToInt(Time.timeSinceLevelLoad - 1f)).ToString() + ":1";
            if (Time.time > 2)
            {
                transform.localScale = new Vector3(-0.4f, 0.4f, 0) * (Time.time - 1f)+ new Vector3(0, 0, 1);
                scale[0].enabled = true;
            }
            if (Time.time > 7)
                intro = false;
        }
        else
        {
            
            if (BeSmall)
            {
                transform.localScale -= new Vector3(-0.05f,0.05f,0);
                
            }
            scale[1].text = "Мастшаб " + (Mathf.RoundToInt(transform.localScale.magnitude / (new Vector3(-0.4f, 0.4f, 1).magnitude))).ToString() + ":1";
            scale[2].text = scale[1].text;
            GetComponent<Animator>().SetBool("go",true);
            float speed = (cam.transform.position.x-prev)/Time.deltaTime;
            if (speed < 0.3)
                GetComponent<Rigidbody2D>().velocity = new Vector2(1, GetComponent<Rigidbody2D>().velocity.y);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.99f*speed, GetComponent<Rigidbody2D>().velocity.y);
            prev = cam.transform.position.x;
            Debug.Log(speed);
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
     
        if (other.gameObject.tag == "wall" || (other.gameObject.tag == "floor" && other.gameObject.transform.position.y > -5.4))
        {
            other.gameObject.AddComponent<Rigidbody2D>();
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value * 15, Random.value * 25);
            other.gameObject.GetComponent<Rigidbody2D>().angularVelocity = Random.value * 180;
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            other.gameObject.AddComponent<fall>();

        }
        if (other.gameObject.name == "Балка")
        {
            BeSmall = true;
        }
        if (other.gameObject.name == "Emila")
        {
            other.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            other.gameObject.GetComponent<Controll>().enabled = false;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value * 7, Random.value * 25);
            other.gameObject.GetComponent<Rigidbody2D>().angularVelocity = Random.value * 180;
            for (int i = 0;i< other.gameObject.GetComponents<Collider2D>().Length;i++)
                  other.gameObject.GetComponents<Collider2D>()[i].enabled = false;
            for (int i = 0; i < other.gameObject.GetComponentsInChildren<Collider2D>().Length; i++)
                other.gameObject.GetComponentsInChildren<Collider2D>()[i].enabled = false;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Балка")
        {
            BeSmall = false;
        }
    }
}

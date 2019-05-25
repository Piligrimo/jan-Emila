using UnityEngine;
using System.Collections;

public class dovahkiin : MonoBehaviour {
    public float force = 0,effect;
    bool prev;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Animator>().SetBool("move", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)>0.1);
        if (prev)
            GetComponent<Animator>().SetBool("roar", false);
        prev= GetComponent<Animator>().GetBool("roar");

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) < 0.1)
        if (other.gameObject.name == "Emila" || other.gameObject.name == "leg")
        {
            GetComponent<Animator>().SetBool("roar", true);
            if (GameObject.Find("Emila").GetComponent<Controll>().tuumeffect <= 0)
            GameObject.Find("Emila").GetComponent<Controll>().tuumeffect = 2f;
        }

    }
}

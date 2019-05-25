using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGettingTing : MonoBehaviour {
    GameObject player;
    public GameObject Meka,saw,Sm1,Sm2;
    Controll c;
    spikes s;
    int hp = 3;

    float disTime = 0;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Emila");
        c = player.GetComponent<Controll>();
        s = saw.GetComponent<spikes>();
    }
	
	// Update is called once per frame
	void Update () {
        if (disTime>0)
        {
            disTime -= Time.deltaTime;
            if (c.enabled)
            {
                c.enabled = false;
                s.enabled = false;
            }
        }
        else
        {
            if (!c.enabled)
            {
                Meka.GetComponent<meka>().phase = 0;
                Meka.GetComponent<meka>().phaseTime = 0;
                c.enabled = true;
                s.enabled = true;
            }
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Emila")
        {
            hp--;
            switch (hp)
            {
                case 2 : Sm1.SetActive(true); break;
                case 1 : Sm2.SetActive(true); break;
                case 0 : Destroy(Meka); break;
            }
            disTime = 2;
            Meka.GetComponent<Animator>().SetTrigger("dmgd");
            if (player.transform.position.x<5)
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(5,20);
            else
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 20);
           
        }
    }
}

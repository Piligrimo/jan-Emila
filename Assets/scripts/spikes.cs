using UnityEngine;
using System.Collections;

public class spikes : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Emila");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name=="Emila" || other.gameObject.name == "leg")
        {
            player.transform.position = player.GetComponent<Controll>().checkpoint;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.Find("Main Camera").GetComponent<CameraControll>().m = false;
        }
    }
}

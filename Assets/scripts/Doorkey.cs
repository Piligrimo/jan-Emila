using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorkey : MonoBehaviour {
    public GameObject door;
    public Sprite KeyInHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.name == "Emila" || other.gameObject.name == "leg")
        {
            door.GetComponent<KeyDoor>().HasKey = true;
            GameObject.Find("Pencil").GetComponent<SpriteRenderer>().sprite = KeyInHand;
            gameObject.SetActive(false);
        }
    }
}

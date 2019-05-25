using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour {
    public bool HasKey = false;
    public GameObject poof;
    public Sprite pencil;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (HasKey)
        if (other.gameObject.name == "Emila" || other.gameObject.name == "leg")
        {
            Instantiate(poof, transform.position, transform.rotation);
            GameObject.Find("Pencil").GetComponent<SpriteRenderer>().sprite = pencil;
            gameObject.SetActive(false);
        }
    }
}

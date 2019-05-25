using UnityEngine;
using System.Collections;

public class sword : MonoBehaviour {
    public Sprite sw;
    GameObject em;
	// Use this for initialization
	void Start () {
        em = GameObject.Find("Emila");
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(transform.position.x - em.transform.position.x) < 0.5)
        {
            GameObject.Find("Pencil").GetComponent<SpriteRenderer>().sprite = sw;
            Destroy(gameObject);
        }
	}
}

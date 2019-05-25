using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {
    public float speed = 10;
	// Use this for initialization
	void Start () {
    GetComponent<Rigidbody2D>().velocity =- new Vector2(speed * Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad), speed * Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad));
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 300 || transform.position.x < -100 || transform.position.y > 200 || transform.position.y < -100)
            Destroy(gameObject);
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = GameObject.Find("Emila");
        if (other.GetComponent<destroidrawing>() != null)
            if (!other.GetComponent<Collider2D>().isTrigger)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.name == "Emila" || other.gameObject.name == "leg")
        {
            player.transform.position = player.GetComponent<Controll>().checkpoint;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Destroy(gameObject);
        }
    }
}

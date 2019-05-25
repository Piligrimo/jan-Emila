using UnityEngine;
using System.Collections;

public class ammo : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Emila" || other.gameObject.name == "leg" || other.gameObject.name == "leg (1)")
        {
            GameObject.Find("Emila").transform.position = GameObject.Find("Emila").GetComponent<Controll>().checkpoint;
            GameObject.Find("Emila").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (other.gameObject.GetComponent<destroidrawing>() != null && !other.GetComponent<Collider2D>().isTrigger)
            Destroy(other.gameObject);
        if (other.gameObject.tag == "wall" ||( other.gameObject.tag == "floor" && !other.GetComponent<Collider2D>().isTrigger && other.gameObject.GetComponent<destroidrawing>() != null) || other.gameObject.name == "Emila" || other.gameObject.name == "leg" || other.gameObject.name == "leg (1)")
                Destroy(gameObject);
    }
}

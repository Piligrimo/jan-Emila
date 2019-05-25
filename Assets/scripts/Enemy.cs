using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    bool fl;
    GameObject pencil = null;
    public float spd = -1;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(spd, rb.velocity.y);
        if (pencil != null)
            if (!pencil.GetComponent<Collider2D>().isTrigger)
            {
                Destroy(pencil);
                Destroy(gameObject);
            }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "enemy")
        {
            spd *= -1;
            transform.Rotate(0, 180, 0);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<destroidrawing>() != null)
            if (other.GetComponent<Collider2D>().isTrigger)
                pencil = other.gameObject;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<destroidrawing>() != null)
            pencil = null;
    }

}

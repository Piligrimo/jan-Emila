using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossaw : MonoBehaviour {

    public Vector3 target, start;
    public float speed = 5, ans = -400;
    bool toMeka = false;
    public GameObject player, meka;
    float dist(Vector3 v1, Vector3 v2)
    {
        float x1 = v1.x, x2 = v2.x, y1 = v1.y, y2 = v2.y, r = Mathf.Sqrt((y1 - y2) * (y1 - y2) + (x1 - x2) * (x1 - x2));
        return r;
    }
    // Use this for initialization
    void Start()
    {
        target = player.transform.position;
        start = transform.position;
        GetComponent<Rigidbody2D>().angularVelocity = ans;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * (target.x - transform.position.x) / dist(target, transform.position), speed * (target.y - transform.position.y) / dist(target, transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude == 0)
            Start();
        if (dist(transform.position, target) < 0.8)
        {
            if (toMeka)
                target = player.transform.position*1.3f+new Vector3(Random.value - 0.5f, Random.value-0.5f)*8;
            else
                target = meka.transform.position;
            toMeka = !toMeka;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * (target.x - transform.position.x) / dist(target, transform.position), speed * (target.y - transform.position.y) / dist(target, transform.position));
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<destroidrawing>() != null)
            if (!other.GetComponent<Collider2D>().isTrigger)
                Destroy(other.gameObject);
        if (other.gameObject.tag == "enemy")
            Destroy(other.gameObject);
    }
}

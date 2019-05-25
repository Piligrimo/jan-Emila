using UnityEngine;
using System.Collections;

public class saw : MonoBehaviour {
    public Vector3 target,start;
    public float speed = 5,ans=-400;
    float dist(Vector3 v1, Vector3 v2)
    {
        float x1 = v1.x, x2 = v2.x, y1 = v1.y, y2 = v2.y, r = Mathf.Sqrt((y1 - y2) * (y1 - y2) + (x1 - x2) * (x1 - x2));
        return r;
    }
    // Use this for initialization
    void Start () {
        start = transform.position;
        GetComponent<Rigidbody2D>().angularVelocity = ans;
	    GetComponent<Rigidbody2D>().velocity= new Vector2(speed * (target.x - transform.position.x) / dist(target, transform.position), speed * (target.y - transform.position.y) / dist(target, transform.position));
    }
	
	// Update is called once per frame
	void Update () {
        if (dist(transform.position, target) < 0.8)
        {
            Vector3 v = start;
            start = target;
            target = v;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * (target.x - transform.position.x) / dist(target, transform.position), speed * (target.y - transform.position.y) / dist(target, transform.position));
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<destroidrawing>() != null)
            if (!other.GetComponent<Collider2D>().isTrigger)
                Destroy(other.gameObject);
        if (other.gameObject.tag=="enemy")
            Destroy(other.gameObject);
    }
}

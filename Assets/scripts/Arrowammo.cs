using UnityEngine;
using System.Collections;

public class Arrowammo : MonoBehaviour {
    public float aim=2,sign,spawntime;
    Vector3 target;
    Quaternion q;
	// Use this for initialization
	void Start () {
        target = transform.position - GameObject.Find("Emila").transform.position;
        q = Quaternion.Euler(0, 0, 180 * Mathf.Atan2(target.y, target.x) / 3.141596f - 90);
        if (target.x < 0)
            sign = -100;
        else
            sign = 100;
        spawntime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (aim > 0)
        {
            aim -= Time.deltaTime;
            if (Mathf.Abs(q.eulerAngles.z - transform.rotation.eulerAngles.z) > 5)
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - Time.deltaTime * sign);
        }
        else
            GetComponent<Rigidbody2D>().velocity = -10*target.normalized;
        if (Time.time - spawntime > 10)
            Destroy(gameObject);
	}
}

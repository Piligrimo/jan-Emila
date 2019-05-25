using UnityEngine;
using System.Collections;

public class EmilasDetector : MonoBehaviour {
    public GameObject lili;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<EmilasDetector>() == null && other.gameObject.tag != "ems" && other.gameObject.tag!= "red")
        {

            lili.GetComponent<BossLili>().coll2 = transform.position;
            Destroy(gameObject);
        }
    }
}

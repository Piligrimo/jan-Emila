using UnityEngine;
using System.Collections;

public class LilisDetector : MonoBehaviour {
    public GameObject lili;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<LilisDetector>()== null && other.gameObject.tag!="Untagged")
        {

            lili.GetComponent<BossLili>().coll = transform.position;
            Destroy(gameObject);
        }
    }

}

using UnityEngine;
using System.Collections;

public class attackHexagon : MonoBehaviour {
    //Короч это будет шестиугольник. Он появляется и крутится. А потом летит в игрока.
    //Нужно его перечеркивать, чтоб уничтожить.
    //Хир ви гоу!!!
    public GameObject hex;
    GameObject pencil;
    Vector3 startscale;
    float preparetime,hp; // Это будет время, которое он крутиться
	// Use this for initialization
	void Start () {
        hp = 10;
        preparetime = 4;
        startscale = hex.transform.localScale;
        hex.GetComponent<spikes>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (pencil != null)
            if (!pencil.GetComponent<Collider2D>().isTrigger)
            {
                Destroy(pencil);
                hp--;
            }
        if (hp < 3)
            Destroy(gameObject);
        hex.transform.localScale = startscale * (hp/10f);
        if (preparetime > 0)
        {
            preparetime -= Time.deltaTime;
            hex.transform.Rotate(0, 0, 360*Time.deltaTime);
        }
        else
        {
            hex.GetComponent<spikes>().enabled = true;
            hex.transform.Rotate(0, 0, - 270*Time.deltaTime);
            Vector3 v=transform.position-GameObject.Find("Emila").transform.position;
            GetComponent<Rigidbody2D>().AddForce(-0.1f*new Vector2(v.x, v.y));
            //            GetComponentInChildren<Rigidbody2D>().velocity = -new Vector2(v.x, v.y).normalized;
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

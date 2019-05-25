using UnityEngine;
using System.Collections;

public class drawscript : MonoBehaviour {
    public Vector3 pnt1, pnt2;
    public GameObject pencil, newone;
    public GameObject[] queue=new GameObject[5];
    public Camera cam;
    public  int qsize=0;
    public bool crossred, drawing=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!drawing && Input.GetKey(KeyCode.Mouse0))
        {
            drawing = true;
            pnt1 = cam.ScreenToWorldPoint(Input.mousePosition);
            pnt1.z = 0;
            GameObject n = Instantiate(pencil, pnt1, transform.rotation) as GameObject;
            newone = n;
        }
        if (drawing && Input.GetKey(KeyCode.Mouse0))
        {
            pnt2 = cam.ScreenToWorldPoint(Input.mousePosition);
            pnt2.z = 0;
            newone.transform.position = (pnt1 + pnt2) / 2;
            Vector3 v = pnt1 - pnt2;
            if (v.magnitude * 6.8 <120)
                newone.transform.localScale = new Vector3(v.magnitude * 6.8f, 1, 1);
            else
                newone.transform.localScale = new Vector3(120, 1, 1);
            newone.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(v.y, v.x) * 180 / 3.1415926f);
            if (crossred)
            {
                Destroy(newone);
                crossred = false;
            }
        }
        if (drawing && !Input.GetKey(KeyCode.Mouse0) )
        {
            if (qsize < 5)
                qsize++;
            drawing = false;
            newone.GetComponent<Rigidbody2D>().gravityScale = 1;
            newone.GetComponent<BoxCollider2D>().isTrigger = false;
            if (qsize==5)
                Destroy(queue[4]);
            for (int i = qsize-1; i > 0; i--)
            {
                   queue[i] = queue[i - 1];
            }
            queue[0] = newone;

        }

    }
}

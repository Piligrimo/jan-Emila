using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour
{
    public GameObject player,bg;
    public bool m =false,bossFight=false;
    public Vector3 camtar,spd,arena;
    // Use this for initialization
    void Start()
    {
        camtar = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        spd = new Vector3(0.02f, 0, 0)*Mathf.Abs(transform.position.x - camtar.x);
        if (GameObject.Find("makin") != null)
        {
            if (Mathf.Abs(player.transform.position.x - GameObject.Find("makin").transform.position.x) < 15)
                m = true;
        }
        else
            m = false;
        if (m)
            camtar = new Vector3((player.transform.position.x + GameObject.Find("makin").transform.position.x)/2, transform.position.y, -10);
        else
        {
            if (GetComponent<drawscript>().drawing)
                camtar = new Vector3((player.transform.position.x + GetComponent<drawscript>().pnt2.x) / 2, transform.position.y, -10);
            else
                camtar = player.transform.position;
            
        }
        if (m)
            spd *= 2;
        if (bossFight)
            camtar = arena;
        if (transform.position.x - camtar.x > 3)
        {
            transform.position -= spd;
            bg.transform.position += spd/8;
        }
        if (transform.position.x - camtar.x < -3 )
        {
            transform.position += spd;
            bg.transform.position -= spd / 8;
        }
        
    }
}

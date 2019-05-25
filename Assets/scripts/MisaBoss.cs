using UnityEngine;
using System.Collections;

public class MisaBoss : MonoBehaviour {
    bool right=false, hexSpawned=false, dead=false;
    public int jump = 0;
    public float attacktime =10;
    public int hp=3;
    public GameObject button,arrow,eraserpr,er,hexagon;
    public GameObject[] Faces,fallin;
     Vector2[] spots= {new Vector2(105.6112f, 1.796038f), new Vector2(112.8911f,6.786037f),new Vector2(120.8711f,1.796038f),new Vector2(112.7511f,-3.663963f) };
    Vector2[] speeds = { new Vector2(7, 18), new Vector2(7, 10), new Vector2(-7f, 10), new Vector2(-7f, 18) };
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-15,18);

    }
	 
	// Update is called once per frame
	void Update ()
   {
        
        if (hp == 0 && !dead)
        {
            for (int i = 0; i < fallin.Length; i++)
            {
                dead = true;
                fallin[i].AddComponent<Rigidbody2D>();
                fallin[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value*6-3, Random.value*3);
                fallin[i].GetComponent<Rigidbody2D>().angularDrag = Random.value * 180;
                fallin[i].GetComponent<Collider2D>().enabled = false;
            }
        }
        if ((!right && transform.position.x < GameObject.Find("Emila").transform.position.x) || (right && transform.position.x > GameObject.Find("Emila").transform.position.x))
        {
            right = !right;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        for (int i = 0; i < 3; i++)
            Faces[i].SetActive(i < hp);
        GetComponent<Collider2D>().isTrigger = GetComponent<Rigidbody2D>().velocity.y > 0;
        if (!dead)
        {
            
           
            if (GetComponent<Rigidbody2D>().velocity == Vector2.zero && attacktime < 0)
            {
                GetComponent<Rigidbody2D>().velocity = speeds[jump % 4];
                transform.position = new Vector3(spots[jump % 4].x, spots[jump % 4].y, 0);
                jump++;
                if (jump % 4 != 1)
                    attacktime = 10;
            }
            if ((transform.position - new Vector3(spots[3].x, spots[3].y, 0)).magnitude < 0.2)
                button.GetComponent<Animator>().SetBool("prss", true);
            if (attacktime >= 0)
            {
                Debug.Log((transform.position - new Vector3(spots[2].x, spots[2].y, 0)).magnitude);
                if (jump % 4 == 0 && 10 - attacktime > GameObject.FindGameObjectsWithTag("ammo").Length * 2)
                {
                    GetComponent<Animator>().SetTrigger("Draw");
                    Instantiate(arrow, new Vector3(104 + 2 * attacktime, 6.5f, 0), Quaternion.Euler(0, 0, 0));
                }
                if (jump % 4 == 2 && !hexSpawned && (transform.position - new Vector3(spots[2].x, spots[2].y, 0)).magnitude < 0.1)
                {
                    Instantiate(hexagon);
                    hexSpawned = true;
                }
                if (jump % 4 == 3 && er == null)
                    er = Instantiate(eraserpr) as GameObject;
                if (jump % 4 != 3 && er != null)
                    Destroy(er);
                if (jump % 4 == 3)
                    hexSpawned = false;
                attacktime -= Time.deltaTime;
            }
        }
        else
        {
            if (GetComponent<Rigidbody2D>().velocity == Vector2.zero && transform.position.x > 122)
                GetComponent<Rigidbody2D>().velocity = new Vector2(-10,18);
        }
    }
}

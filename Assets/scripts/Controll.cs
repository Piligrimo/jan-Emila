using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class Controll : MonoBehaviour {
    public float speed,lvlend,tuumeffect,sloweffect;
    Rigidbody2D rb;
    Animator an;
    public bool tuumed =false;
    public bool right = true, onground,walltouch=false, talking= false;
    public Vector3 checkpoint;
    public GameObject white;
    public bool god=false;
    float endtimer=-1;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (tuumeffect <= 0)
        {
            tuumed = false;
            if (onground)
                walltouch = false;
            if (!walltouch && !talking)
                speed = Input.GetAxis("Horizontal") * 6;
            if (sloweffect>0)
            {
                sloweffect -= Time.deltaTime;
                speed *= .5f;
            }
            float sy = rb.velocity.y;
            if (!walltouch && !talking)
                rb.velocity = new Vector2(speed, sy);
            else
                rb.velocity = new Vector2(-0.3f * speed, sy);
            if (onground && Input.GetAxis("Vertical") > 0 && rb.velocity.y < 3)
            {
                onground = false;
                rb.velocity += new Vector2(0, 16);
            }
            if ((speed > 0 && !right) || (right && speed < 0))
            {
                flip();
                right = !right;
            }
            an.SetBool("go", speed != 0 && onground);
            if (transform.position.y < -20)
            {
                transform.position = checkpoint;
                rb.velocity = new Vector2(0, 0);
                GameObject.Find("Main Camera").GetComponent<CameraControll>().m = false;
            }
            if (transform.position.x > lvlend)
            {
                white.GetComponent<Animator>().SetBool("end", true);
                endtimer = 0;
            }
            if (god)
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 6, Input.GetAxis("Vertical") * 6);

            if (talking)
            {
                rb.velocity = new Vector2(0, sy);

            }
        }
        else
        {
            tuumeffect -= Time.deltaTime;
            if (tuumeffect < 1.45
                && ! tuumed)
            {
                tuumed = true;
                rb.velocity = new Vector2(12, 12);
            }
        }
        if (endtimer>=0)
        {
            endtimer += Time.deltaTime;
            if (endtimer > 3)
                Application.LoadLevel(Application.loadedLevel+1);
        }
    }
    void flip()
    {
        transform.Rotate(0, 180, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "checkpoint")
        {
            checkpoint = other.transform.position;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall")
            walltouch = true;

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall")
            walltouch = false;

    }
}

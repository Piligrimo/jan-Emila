using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captain : MonoBehaviour {
    public GameObject player, ball,pointer,sprite,exit;
    bool right = true;
    float lastSpawnTime;
    public float sleepy;
    public int hp=3;
    public Sprite[] SleepyCapSprites;
    GameObject[] coffies;
    Rigidbody2D rb;

        // Use this for initialization
	void Start () {
        coffies = GameObject.FindGameObjectsWithTag("coffee");
        lastSpawnTime = Time.time;
        player = GameObject.Find("Emila");
        pointer = GameObject.Find("point");
        exit = GameObject.Find("Exit");
        exit.SetActive(false);
        sleepy = -60;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (sleepy > 70)
            EmiSleeps();
        if (pointer.transform.localPosition.x-sleepy>1)
            pointer.transform.localPosition -= new Vector3(Time.deltaTime*20, 0, 0);
        if (pointer.transform.localPosition.x - sleepy < -1)
            pointer.transform.localPosition += new Vector3(Time.deltaTime * 20, 0, 0);
        if (Time.time - lastSpawnTime>5)
        {
            lastSpawnTime = Time.time;
            GameObject b = Instantiate(ball, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Vector3 vel = player.GetComponent<Rigidbody2D>().velocity;
            b.GetComponent<Rigidbody2D>().velocity = player.transform.position - transform.position + new Vector3(0,1,0)+vel*.5f;
        }
        Vector2 v = new Vector2(player.transform.position.x - transform.position.x, 0);
        if (v.magnitude > 7)
            v = v.normalized*7;
        rb.AddForce(v);
        if (rb.velocity.magnitude > 10)
            rb.velocity =rb.velocity.normalized * 10;
        if ((transform.position.x>player.transform.position.x && right)|| (transform.position.x < player.transform.position.x && !right))
        {
            transform.Rotate(0, 180, 0);
            right = !right;
        }
        GetComponent<Animator>().SetBool("move", rb.velocity.magnitude > 2);
    }
    void EmiSleeps()
    {
        player.transform.position=new Vector3(-2,12,0);
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        sleepy = -60;
        for (int i = 0; i < coffies.Length; i++)
            coffies[i].SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ammo")
            if (other.gameObject.GetComponent<Slowball>().reflected)
            {
                hp--;
                other.gameObject.GetComponent<Animator>().SetTrigger("die");
                other.gameObject.GetComponent<Collider2D>().enabled = false;
                if (hp>=0)
                    GetComponentInChildren<SpriteRenderer>().sprite = SleepyCapSprites[hp];
                if (hp==0)
                {
                    GetComponent<Collider2D>().isTrigger = false;
                    gameObject.tag = "floor";
                    sprite.transform.localPosition = Vector3.zero;
                    GetComponent<Animator>().SetTrigger("sleep");
                    float x = player.transform.position.x - transform.position.x;
                    rb.velocity = new Vector2(x,4);
                    rb.gravityScale = 1;
                    rb.angularVelocity = Random.value * 450 - 900;
                    exit.SetActive(true);
                    GetComponent<Captain>().enabled = false;
                }
            }
    }
 }

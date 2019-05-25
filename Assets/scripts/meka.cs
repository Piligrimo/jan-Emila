using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meka : MonoBehaviour {
    public GameObject player,drone,staw;
    public GameObject[] saw;
    Rigidbody2D rb;
    Animator an;
    bool right = false;
    public float phaseTime = 0,cd=0;
     public  int phase = 0;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        
        if ((player.transform.position - transform.position).magnitude < 40)
        {
            if (phase == -1)
            {
                phase++;
                transform.position = new Vector3(10,0,0.15f);
            }
            if (phase == 0)
            {
                if (!right && player.transform.position.x - transform.position.x > 5 || right && player.transform.position.x - transform.position.x < -5)
                {
                    right = !right;
                    transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
                }
                if (Mathf.Abs(player.transform.position.x - transform.position.x) > 5)
                {
                    an.SetBool("go", true);
                    if (!right)
                        rb.velocity = new Vector2(-1.3f, rb.velocity.y);
                    else
                        rb.velocity = new Vector2(1.3f, rb.velocity.y);
                }
                else
                {
                    an.SetBool("go", false);
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
            if (phase == 1)
            {
                an.SetBool("go", false);
                if (cd <= 0)
                {

                    Instantiate(drone, transform.position, Quaternion.Euler(0, 0, 0));
                    cd = 4;
                }
                else
                {
                    cd -= Time.deltaTime;
                }
            }
            if (phase == 2)
            {
                for (int i = 0; i < 2; i++)
                    if (!saw[i].active)
                    {
                        saw[i].SetActive(true);
                        saw[i].transform.position = transform.position;
                        saw[i].GetComponent<Bossaw>().target = player.transform.position * 1.3f + new Vector3(Random.value - 0.5f, Random.value - 0.5f) * 8;
                        saw[i].GetComponent<Bossaw>().start = transform.position;
                    }
            }
            else
            {
                saw[0].SetActive(false);
                saw[1].SetActive(false);
            }
            staw.SetActive(phase != 2 );
            if (phaseTime > 15)
            {
                phase = (phase + 1) % 3;
                phaseTime = 0;
            }
            else
                phaseTime += Time.deltaTime;
        }
        else
        {
            phase = -1;
            phaseTime = 0;
            
        }
    }
}

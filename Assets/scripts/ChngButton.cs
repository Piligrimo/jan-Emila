using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChngButton : MonoBehaviour {
    bool prevPressed = false;
    Animator an;
    public GameObject icon;
    public GameObject[] friends;
    public Sprite[] iconSprites;
    public int current = 0;
	// Use this for initialization
	void Start () {
        for (int i=0;i<3;i++)
            if (i==current)
                friends[i].SetActive(true);
            else
                friends[i].SetActive(false);
        icon.GetComponent<SpriteRenderer>().sprite = iconSprites[current];
        an = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!prevPressed && an.GetBool("prss"))
        {
            friends[current].SetActive(false);
            current = (current + 1) % 3;
            friends[current].SetActive(true);
            icon.GetComponent<SpriteRenderer>().sprite = iconSprites[current];

        }
        prevPressed = an.GetBool("prss");
	}
}

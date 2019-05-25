using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossSeleka : MonoBehaviour {
    public GameObject Emila, enemy,gate2,ab1,ab2,red,gate,d1,d2,poof;
    int attacktype;
    float fighttime, lastx, cstt, effect, diatime;
    bool tuumed=false,finale=false;
    public Text SelFin, EmFin;
    public bool thro;
	// Use this for initialization
	void Start () {
        gate2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!finale)
        {
            GetComponent<Animator>().SetBool("roar", false);
            GetComponent<Animator>().SetBool("lose", false);
            GetComponent<Animator>().SetBool("refresh", Emila.transform.position.x < 104);
            GameObject.Find("Main Camera").GetComponent<CameraControll>().bossFight = Emila.transform.position.x > 104;
            ab1.GetComponent<autobutton>().active = attacktype == 1;
            ab2.GetComponent<autobutton>().active = attacktype == 2;
            red.SetActive(attacktype == 2);
            d1.SetActive(attacktype == 3);
            d2.SetActive(attacktype == 3);
            gate.SetActive(attacktype >= 0);
            Emila.GetComponent<Controll>().enabled = effect <= 0;
            if (effect > 0)
                effect -= Time.deltaTime;
            if (Emila.transform.position.x > 104 && lastx < 104)
            {
                fighttime = -3;
                cstt = 0;
            }
            lastx = Emila.transform.position.x;
            if (Input.GetKey(KeyCode.Q))
                fighttime = 66;
            if (Emila.transform.position.x > 104)
            {
                if (GameObject.FindGameObjectsWithTag("sword").Length == 0)
                {
                    GetComponent<Animator>().SetBool("lose", true);
                    GameObject.Find("Main Camera").GetComponent<CameraControll>().bossFight = false;
                    name = "makin";
                    finale = true;
                }
                if (Emila.transform.position.x > 120 && !tuumed)
                {
                    tuumed = true;
                    GetComponent<Animator>().SetBool("roar", true);
                }
                if (thro)
                {
                    effect = 1;
                    thro = false;
                    Emila.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 1), ForceMode2D.Impulse);
                }
                fighttime += Time.deltaTime;
                if ((fighttime > 0 && fighttime < 10) || (fighttime > 35 && fighttime < 45))
                    attacktype = 0;
                if ((fighttime > 10 && fighttime < 20) || (fighttime > 45 && fighttime < 55))
                    attacktype = 1;
                if ((fighttime > 20 && fighttime < 30) || (fighttime > 55 && fighttime < 65))
                    attacktype = 2;
                if (fighttime > 65 && fighttime < 70)
                    attacktype = 4;

                if (fighttime > 70)
                    attacktype = 3;
                if (attacktype == 0)
                {
                    if (fighttime > cstt)
                    {
                        cstt = fighttime + 2;
                        Instantiate(enemy, new Vector3(120, 6, 0), Quaternion.Euler(0, 0, 0));
                    }
                }

            }
            else
            {
                attacktype = -1;
                tuumed = false;
            }
        }
        else
        {
            gate2.SetActive(true);
            diatime += Time.deltaTime;
            if (diatime > 1 && SelFin.text != "Seleka: Погоди, не делай этого!")
                SelFin.text = "Seleka: Погоди, не делай этого!";
            if (diatime > 4 && EmFin.text != "Emila: Почему вы так боитесь? Там очень маленький шанс срабатывания.")
                EmFin.text = "Emila: Почему вы так боитесь? Там очень маленький шанс срабатывания.";
            if (diatime > 7 && SelFin.text != "Seleka: Погоди, не делай этого!\n\n\nSeleka: Я читами сделал, чтоб был 100%...")
                SelFin.text = "Seleka: Погоди, не делай этого!\n\n\n\n\nSeleka: Я читами сделал, чтоб был 100%...";
            if (diatime > 10 && EmFin.text != "Emila: Почему вы так боитесь? Там очень маленький шанс срабатывания.\n\n\n\nEmila: Пропустите меня дальше!")
                EmFin.text = "Emila: Почему вы так боитесь? Там очень маленький шанс срабатывания.\n\n\n\nEmila: Пропустите меня дальше!";
            if (diatime > 13 && SelFin.text != "Seleka: Погоди, не делай этого!\n\n\nSeleka: Я читами сделал, чтоб был 100%...\n\n\nSeleka: Проходи, только не трогай меня.")
                SelFin.text = "Seleka: Погоди, не делай этого!\n\n\n\n\nSeleka: Я читами сделал, чтоб был 100%...\n\n\nSeleka: Проходи, только не трогай меня.";
            if (diatime>15)
            {
                Instantiate(poof, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}

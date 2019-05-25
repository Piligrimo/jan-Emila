using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scenery : MonoBehaviour {
    public Text t1;
    public Image e,enter,a,d,l,r;
    float time;
	// Use this for initialization
	void Start () {

        time = Time.time;
        e.enabled = false;
        a.enabled = false;
        d.enabled = false;
        l.enabled = false;
        r.enabled = false;
        enter.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - time > 5 && t1.text[7] == 'П' )
        {
            t1.text = "Нажми             чтобы взглянуть на руку.";
            e.enabled = true;
        }
        if (t1.text == "Нажми             чтобы взглянуть на руку." && Input.GetKey(KeyCode.E))
        {
            t1.text = "Ох... Не вышло... Ну попробуй";
            e.enabled = false;
            enter.enabled = true;
        }
        if (t1.text == "Ох... Не вышло... Ну попробуй" && Input.GetKey(KeyCode.Return))
        {
            t1.text = "Опять не получилось... \n Наверно управление в игре не предоставляет возможности взглянуть на руку.";
            enter.enabled = false;
            time = Time.time;
        }
        if (Time.time - time > 5 && t1.text == "Опять не получилось... \n Наверно управление в игре не предоставляет возможности взглянуть на руку.")
        {
            t1.text = "Emila: Значит придется искать ответы... \n Хорошо, что игра корридорная. Сразу ясно куда идти";
            time = Time.time;
        }
        if (Time.time - time > 5 && t1.text == "Emila: Значит придется искать ответы... \n Хорошо, что игра корридорная. Сразу ясно куда идти")
        {
            t1.text = "Используй            и             \n \n либо            и             для ходьбы";
            d.enabled = true;
            a.enabled = true;
            r.enabled = true;
            l.enabled = true;
        }
    }
}

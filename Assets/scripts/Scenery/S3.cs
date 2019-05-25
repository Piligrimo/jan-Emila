using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class S3 : MonoBehaviour
{
    public Camera cam;
    bool meet = false;
    int talked = 0;
    public GameObject bossscreen,enemy,gate;
    public Text Etxt, Jtxt;
    float diatime = -1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!meet && cam.transform.position.x > 19)
        {
            meet = true;
            Instantiate(bossscreen, cam.transform.position + new Vector3(9, -1.5f, 1), transform.rotation);
            Time.timeScale = 0.1f;
        }
        if (talked==1 && cam.transform.position.x<5)
        {
            Jtxt.text = "";
            Etxt.text = "\n\n\n\n\n\n\n\n\n\n Emila в мыслях: Этот рисунок доставляет некоторые проблемы. Попробую его зачернуть!";
        }
        if (talked == 1 && GameObject.FindGameObjectsWithTag("enemy").Length == 3)
        {
            if (diatime < 0)
            {
                GameObject.Find("Emila").GetComponent<Controll>().talking = true;
                Etxt.text = "";
                Jtxt.text = "jan sitelen lili: Что ты себе позволяешь!? Ты рисовала это, чтоб уничтожать? Ты сама то рисовать умеешь!?";
                diatime = 0;
            }
            if (diatime >= 0)
                diatime += Time.deltaTime;
            if (diatime > 4)
                if (Etxt.text != "\n\n\n\n\n\nEmila в мыслях: Вот сейчас было обидно!")
                    Etxt.text = "\n\n\n\n\n\nEmila в мыслях: Вот сейчас было обидно!";
            if (diatime > 6)
                if (Jtxt.text != "jan sitelen lili: Что ты себе позволяешь!? Ты рисовала это, чтоб уничтожать? Ты сама то рисовать умеешь!?\n\n\njan sitelen lili: Я буду мстить! Я тебе покажу, что я умею!")
                    Jtxt.text = "jan sitelen lili: Что ты себе позволяешь!? Ты рисовала это, чтоб уничтожать? Ты сама то рисовать умеешь!?\n\n\njan sitelen lili: Я буду мстить! Я тебе покажу, что я умею!";
            if (diatime > 8)
                if (Etxt.text != "\n\n\n\n\n\nEmila в мыслях: Вот сейчас было обидно!\n\n\nEmila: Рисование в список того, что вы умеете точно не входит.")
                    Etxt.text = "\n\n\n\n\n\nEmila в мыслях: Вот сейчас было обидно!\n\n\nEmila: Рисование в список того, что вы умеете точно не входит.";
            if (diatime > 10)
                if (Jtxt.text != "jan sitelen lili: Что ты себе позволяешь!? Ты рисовала это, чтоб уничтожать? Ты сама то рисовать умеешь!?\n\n\njan sitelen lili: Я буду мстить! Я тебе покажу, что я умею!\n\n\njan sitelen lili: D^:<\nВстретимся в конце уровня! Там и проверим!")
                {
                    Jtxt.text = "jan sitelen lili: Что ты себе позволяешь!? Ты рисовала это, чтоб уничтожать? Ты сама то рисовать умеешь!?\n\n\njan sitelen lili: Я буду мстить! Я тебе покажу, что я умею!\n\n\njan sitelen lili: D^:<\nВстретимся в конце уровня! Там и проверим!";
                    talked = 2;
                    GameObject.Find("Emila").GetComponent<Controll>().talking = false;
                    GameObject.Find("lili").AddComponent<Rigidbody2D>();
                    GameObject.Find("lili").GetComponent<Rigidbody2D>().velocity = new Vector2(3, 10);
                    Destroy(gate);
                } 
        }
        if (meet && GameObject.Find("BossAn (clone)") == null && talked==0)
        {
            if (diatime < 0)
                diatime = 0;
            if (diatime >= 0)
                diatime += Time.deltaTime;
            if (diatime > 2)
                if (Etxt.text != "Emila: Здравствуйте, вы не видели Макина?")
                    Etxt.text = "Emila: Здравствуйте, вы не видели Макина?";
            if (diatime > 5)
                if (Jtxt.text != "jan sitelen lili: Кто ты? Почему ты ругаешь мои рисунки?")
                    Jtxt.text = "jan sitelen lili: Кто ты? Почему ты ругаешь мои рисунки?";
            if (diatime > 8)
                if (Etxt.text != "Emila: Здравствуйте, вы не видели Макина?\n\n\nEmila: Но, но... Я просто сказала, что рисовать на клетчатой бумаге синей ручкой некруто...")
                    Etxt.text = "Emila: Здравствуйте, вы не видели Макина?\n\n\nEmila: Но, но... Я просто сказала, что рисовать на клетчатой бумаге синей ручкой некруто...";
            if (diatime > 12)
                if (Jtxt.text != "jan sitelen lili: Кто ты? Почему ты ругаешь мои рисунки?\n\n\n\n\njan sitelen lili:Главное как рисуешь, а не чем и на чём.")
                    Jtxt.text = "jan sitelen lili: Кто ты? Почему ты ругаешь мои рисунки?\n\n\n\n\njan sitelen lili:Главное как рисуешь, а не чем и на чём.";
            if (diatime > 16)
                if (Etxt.text != "Emila: Здравствуйте, вы не видели Макина?\n\n\nEmila: Но, но... Я просто сказала, что рисовать на клетчатой бумаге синей ручкой некруто...\n\n\nEmila:А покажите мне, как вы рисуете")
                    Etxt.text = "Emila: Здравствуйте, вы не видели Макина?\n\n\nEmila: Но, но... Я просто сказала, что рисовать на клетчатой бумаге синей ручкой некруто...\n\n\nEmila:А покажите мне, как вы рисуете";
            if (diatime > 18)
            {
                Jtxt.text = "jan sitelen lili: Кто ты? Почему ты ругаешь мои рисунки?\n\n\n\n\njan sitelen lili:Главное как рисуешь, а не чем и на чём. \n\n\njan sitelen lili: Мой первый арт на эту тему. Не судите строго.";
                if (talked==0)
                    Instantiate(enemy,  new Vector3(26.47848f, -4.701103f, 0), transform.rotation);
                talked = 1;
                diatime = -1;
                GameObject.Find("makin").name = "lili";
                GameObject.Find("Emila").GetComponent<Controll>().talking = false;
            }
        }
    }
}

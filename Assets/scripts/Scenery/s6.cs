using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class s6 : MonoBehaviour {
    public Camera cam;
    bool meet = false, f=false;
    int talked = 0;
    public GameObject bossscreen,Seleka, gate,sword,poof;
    public Text Etxt, Jtxt;
    float diatime = -1;
    // Use this for initialization
    void Start () {
        gate.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if ( cam.transform.position.x > -11 && diatime<0 && !f)
            diatime = 0;

        if (diatime >= 0)
            diatime += Time.deltaTime;
        if (!f)
        {
            if (diatime >= 0 && Etxt.text != "Emila: Макин!?")
                Etxt.text = "Emila: Макин!?";
            if (diatime >= 2 && Jtxt.text != "\nSeleka: Боюсь, ты обозналась...")
            {
                Jtxt.text = "\nSeleka: Боюсь, ты обозналась...";
                Seleka.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Seleka.GetComponent<Animator>().SetInteger("state", 1);
            }
            if (diatime > 3 && !meet)
            {
                meet = true;
                GameObject n = Instantiate(bossscreen, cam.transform.position + new Vector3(7, -1.5f, 1), Quaternion.Euler(0, 0, 0)) as GameObject;
                Time.timeScale = 0.1f;
            }
            if (diatime >= 4 && Etxt.text != "Emila: Макин!?\n\n\nEmila: О, Селека, здравствуйте. А что вы делали в кустах?")
                Etxt.text = "Emila: Макин!?\n\nEmila: О, Селека, здравствуйте. А что вы делали в кустах?";
            if (diatime >= 7 && Jtxt.text != "\nSeleka: Боюсь, ты обозналась...\n\n\nSeleka: Тебе какая разница? Скрытность прокачивал!")
                Jtxt.text = "\nSeleka: Боюсь, ты обозналась...\n\n\nSeleka: Тебе какая разница? Скрытность прокачивал!";
            if (diatime >= 10 && Etxt.text != "Emila: Макин!?\n\n\nEmila: О, Селека, здравствуйте. А что вы делали в кустах?\n\n\nEmila: Наверно, стелс - не ваше призванье :^)")
                Etxt.text = "Emila: Макин!?\n\nEmila: О, Селека, здравствуйте. А что вы делали в кустах?\n\n\nEmila: Наверно, стелс - не ваше призванье :^)";
            if (diatime >= 13 && Jtxt.text != "\nSeleka: Боюсь, ты обозналась...\n\n\nSeleka: Тебе какая разница? Скрытность прокачивал!\n\n\nSeleka: Навельна стельс - ни васе плизвание >8^p")
                Jtxt.text = "\nSeleka: Боюсь, ты обозналась...\n\n\nSeleka: Тебе какая разница? Скрытность прокачивал!\n\n\nSeleka: Навельна стельс - ни васе плизвание >8^p";
            if (diatime >= 16 && Etxt.text != "Emila: Макин!?\n\n\nEmila: О, Селека, здравствуйте. А что вы делали в кустах?\n\n\nEmila: Наверно, стелс - не ваше призванье :^)\n\n\nEmila: А можете подсказать, проходил ли тут Макин?")
                Etxt.text = "Emila: Макин!?\n\nEmila: О, Селека, здравствуйте. А что вы делали в кустах?\n\n\nEmila: Наверно, стелс - не ваше призванье :^)\n\n\nEmila: А можете подсказать, проходил ли тут Макин?";
            if (diatime >= 19 && Jtxt.text != "\nSeleka: Боюсь, ты обозналась...\n\n\nSeleka: Тебе какая разница? Скрытность прокачивал!\n\n\nSeleka: Навельна стельс - ни васе плизвание >8^p\n\n\nSeleka: Допустим...")
                Jtxt.text = "\nSeleka: Боюсь, ты обозналась...\n\n\nSeleka: Тебе какая разница? Скрытность прокачивал!\n\n\nSeleka: Навельна стельс - ни васе плизвание >8^p\n\n\nSeleka: Допустим...";
            if (diatime >= 21 && Etxt.text != "Emila: Ну, мне нужно с ним поговорить.")
            {
                Etxt.text = "Emila: Ну, мне нужно с ним поговорить.";
                Jtxt.text = "";
            }
            if (diatime >= 23 && Jtxt.text != "\nSeleka: Но я тебя все равно к нему не пущу.")
                Jtxt.text = "\nSeleka: Но я тебя все равно к нему не пущу.";
            if (diatime >= 25 && Etxt.text != "Emila: Ну, мне нужно с ним поговорить.\n\nEmila:Но почему?")
                Etxt.text = "Emila: Ну, мне нужно с ним поговорить.\n\nEmila:Но почему?";
            if (diatime >= 28 && Jtxt.text != "\nSeleka: Но я тебя все равно к нему не пущу.\n\nSeleka: Я... Охраняю его!")
                Jtxt.text = "\nSeleka: Но я тебя все равно к нему не пущу.\n\nSeleka: Я... Охраняю его!";
            if (diatime >= 31 && Etxt.text != "Emila: Ну, мне нужно с ним поговорить.\n\nEmila:Но почему?\n\nEmila: Ух-ты. Вы довольно заботливый брат.")
                Etxt.text = "Emila: Ну, мне нужно с ним поговорить.\n\nEmila:Но почему?\n\nEmila: Ух-ты. Вы довольно заботливый брат.";
            if (diatime >= 34 && Jtxt.text != "\nSeleka: Но я тебя все равно к нему не пущу.\n\nSeleka: Я... Охраняю его!\n\n\nSeleka: Ну, на самом деле я наврал, что охраняю его. Я просто не пускаю к нему друзей.")
                Jtxt.text = "\nSeleka: Но я тебя все равно к нему не пущу.\n\nSeleka: Я... Охраняю его!\n\n\nSeleka: Ну, на самом деле я наврал, что охраняю его. Я просто не пускаю к нему друзей.";
            if (diatime >= 37 && Etxt.text != "Emila: Ну, мне нужно с ним поговорить.\n\nEmila:Но почему?\n\nEmila: Ух-ты. Вы довольно заботливый брат.\n\n\n\nEmila: И что, совсем никак не пройти?")
                Etxt.text = "Emila: Ну, мне нужно с ним поговорить.\n\nEmila:Но почему?\n\nEmila: Ух-ты. Вы довольно заботливый брат.\n\n\n\nEmila: И что, совсем никак не пройти?";
            if (diatime >= 40 && Jtxt.text != "\nSeleka: Но я тебя все равно к нему не пущу.\n\nSeleka: Я... Охраняю его!\n\n\nSeleka: Ну, на самом деле я наврал, что охраняю его. Я просто не пускаю к нему друзей.\n\n\nSeleka: Ну, может быть я пущу тебя, если ты победишь\n меня  в бою!")
                Jtxt.text = "\nSeleka: Но я тебя все равно к нему не пущу.\n\nSeleka: Я... Охраняю его!\n\n\nSeleka: Ну, на самом деле я наврал, что охраняю его. Я просто не пускаю к нему друзей.\n\n\nSeleka: Ну, может быть я пущу тебя, если ты победишь\n меня в бою!";
            if (diatime > 43)
            {
                GameObject.Find("Emila").GetComponent<Controll>().talking = false;
                f = true;
                Jtxt.text = "";
                Etxt.text = "";
                Seleka.GetComponent<Animator>().SetInteger("state", 2);
                Instantiate(poof);
                Instantiate(sword);
                diatime = -1;
            }
        }
       else
        {
            if (Seleka!=null)
            if((GameObject.Find("Emila").transform.position-Seleka.transform.position).magnitude<2 && GameObject.FindGameObjectsWithTag("sword").Length == 1 && !GameObject.Find("Emila").GetComponent<Controll>().talking)
                {
                GameObject.Find("Emila").GetComponent<Controll>().talking = true;
                    Jtxt.transform.position = new Vector3(cam.transform.position.x + 5f, Jtxt.transform.position.y, Jtxt.transform.position.z);
                    Etxt.transform.position = new Vector3(cam.transform.position.x - 5f, Etxt.transform.position.y, Etxt.transform.position.z);
                    diatime = 0;
            }
            if (diatime > 0 && Jtxt.text != "Seleka: Ахахахахаха! Ты меня не убьешь, я читами накрутил себе бесконечность hp")
                Jtxt.text = "Seleka: Ахахахахаха! Ты меня не убьешь, я читами накрутил себе бесконечность hp";
            if (diatime > 3 && Etxt.text != "\n\n\nEmila: Эй! Так нечестно! А был же кинжал, которым можно кого угодно убить с одного удара...")
                Etxt.text = "\n\n\nEmila: Эй! Так нечестно! А был же кинжал, которым можно кого угодно убить с одного удара...";
            if (diatime > 6 && Jtxt.text != "Seleka: Ахахахахаха! Ты меня не убьешь, я читами накрутил себе бесконечность hp\n\n\nSeleka:Ах, да. Бритва Меруноса. Она на конце уровня. Пожалуй, оправлюсь туда, чтоб не дать тебе подойти к ней.")
                Jtxt.text = "Seleka: Ахахахахаха! Ты меня не убьешь, я читами накрутил себе бесконечность hp\n\n\nSeleka:Ах, да. Бритва Меруноса. Она на конце уровня. Пожалуй, оправлюсь туда, чтоб не дать тебе подойти к ней.";
            if (diatime > 8 && Seleka!=null)
            {
                gate.SetActive(true);
                Instantiate(poof);
                Destroy(Seleka);
                GameObject.Find("Emila").GetComponent<Controll>().talking = false;
            }
        }
    }
}

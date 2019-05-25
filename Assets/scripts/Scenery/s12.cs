using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s12 : MonoBehaviour {

    public Camera cam;
    bool meet = false,talked=false;
    public GameObject bossscreen, boss,Cap,FX,UI;
    public Text Etxt, Jtxt;
    float diatime = -1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!meet && cam.transform.position.x > 20)
        {
            meet = true;
            Instantiate(bossscreen, cam.transform.position + new Vector3(2, -1.5f, 1), transform.rotation);
            Time.timeScale = 0.1f;
            Etxt.text = "";
        }
        if (meet && GameObject.Find("BossAn (clone)") == null && !talked)
        {
            if (diatime < 0)
                diatime = 0;
            if (diatime >= 0)
                diatime += Time.deltaTime;
            
            if (diatime > 2)
                if (Jtxt.text != "jan oko wan wan: Элмайра, милая! Какими судьбами ты тут?")
                    Jtxt.text = "jan oko wan wan: Элмайра, милая! Какими судьбами ты тут?";
            if (diatime > 5)
                if (Etxt.text != "Emila: Кэп! Здравствуйте! Я ищу Макина, он проходил тут?")
                    Etxt.text = "Emila: Кэп! Здравствуйте! Я ищу Макина, он проходил тут?";
            if (diatime > 8)
                if (Jtxt.text != "jan oko wan wan: Элмайра, милая! Какими судьбами ты тут?\n\n jan oko wan wan: Однозначно, да. Все уровни линейные.")
                    Jtxt.text = "jan oko wan wan: Элмайра, милая! Какими судьбами ты тут?\n\n jan oko wan wan: Однозначно, да. Все уровни линейные.";
            if (diatime > 11)
                if (Etxt.text != "Emila: Кэп! Здравствуйте! Я ищу Макина, он проходил тут?\n\n\n\nEmila: Я шла сюда от земель с белой бумагой и карандашным всем остальным, и только сейчас начала                                         \n что-то понимать.                           ")
                    Etxt.text = "Emila: Кэп! Здравствуйте! Я ищу Макина, он проходил тут?\n\n\n\nEmila: Я шла сюда от земель с белой бумагой и карандашным всем остальным, и только сейчас начала                                         \n что-то понимать.                           ";
             if (diatime > 14)
                if (Jtxt.text != "jan oko wan wan: Элмайра, милая! Какими судьбами ты тут?\n\n jan oko wan wan: Однозначно, да. Все уровни линейные.\n\n\njan oko wan wan: Что ж,               \n я постараюсь это исправить.               ")
                    Jtxt.text = "jan oko wan wan: Элмайра, милая! Какими судьбами ты тут?\n\n jan oko wan wan: Однозначно, да. Все уровни линейные.\n\n\njan oko wan wan: Что ж,               \n я постараюсь это исправить.               ";
            if (diatime > 16)
                if (Etxt.text != "Emila: Что?")
                {
                    Etxt.text = "Emila: Что?";
                    Jtxt.text = "";
                }
            if (diatime > 17)
                if (Jtxt.text != "\n\n\njan oko wan wan: Я говорю, ты должно быть устала после такого долгого пути.\n         Не хочешь ли поспать?")
                    Jtxt.text = "\n\n\njan oko wan wan: Я говорю, ты должно быть устала после такого долгого пути.\n         Не хочешь ли поспать?";
            if (diatime > 20)
                if (Etxt.text != "Emila: Что?\n\n\n\n\nEmila: Я бы с удовльствием, но я не уверена, что не сплю прямо сейчас. Заходить глубже первого уровня                     \nсна опаааасно!                        ")
                    Etxt.text = "Emila: Что?\n\n\n\n\nEmila: Я бы с удовльствием, но я не уверена, что не сплю прямо сейчас. Заходить глубже первого уровня                     \nсна опаааасно!                        ";
            if (diatime > 23 && !talked)
            {
                talked = true;
                Etxt.text = "";
                Jtxt.text = "\n\n\n\n\nОТДОХНИ!!!";
                Instantiate(Cap);
                Destroy(boss);
                Instantiate(FX);
                Instantiate(FX, new Vector3(12.41179f, 6.100179f, 0),Quaternion.Euler(0,0,0));
                GameObject.Find("Emila").GetComponent<Controll>().talking = false;
                UI.SetActive(true);
            }
        }
    }
}

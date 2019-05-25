using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class s9 : MonoBehaviour {
    bool meet=false;
    public Camera cam;
    public GameObject bossscreen,sz,eraser,Misa,Boss;
    public Text Misas, Emilas;
    float talktime=0,lastx=0;
    // Use this for initialization
	void Start () {
        Boss.SetActive(false);
        for (int i = 0; i < 3; i++)
            Boss.GetComponent<MisaBoss>().Faces[i].active = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Emila").transform.position.x>100 && lastx<=100)
        {
            Boss.SetActive(true);
            Boss.transform.position = new Vector3(122.51f, -3.28f, 0);
            Boss.GetComponent<MisaBoss>().hp = 3;
            Boss.GetComponent<MisaBoss>().jump = 0;
            Boss.GetComponent<MisaBoss>().attacktime = 10;
            for(int i=0;i<3;i++)
                Boss.GetComponent<MisaBoss>().Faces[i].active = true;
            cam.GetComponent<CameraControll>().bossFight = true;
        }
        if (GameObject.Find("Emila").transform.position.x < 100 && lastx >=100)
        {
            for (int i = 0; i < 3; i++)
                Boss.GetComponent<MisaBoss>().Faces[i].active = false;
            cam.GetComponent<CameraControll>().bossFight = false;
        }

            if (!meet && cam.transform.position.x > 2)
        {
            meet = true;
            Instantiate(bossscreen, cam.transform.position + new Vector3(0, 0, 1), transform.rotation);
            Time.timeScale = 0.1f;
            Misas.text = "\nMisa: Ты хотела сказать \"мира инженерной графики\"!";
        }
        if (meet )
        {
            if (GameObject.Find("Emila").transform.position.x> -1)
            talktime += Time.deltaTime;
            if (talktime < 14)
            {
                if (talktime > 2.5 && Misas.text != "")
                {
                    Emilas.text = "Emila: Миша! Здравствуйте!";
                    Misas.text = "";
                }
                if (talktime > 4 && Misas.text != "Misa: Ух-ты! Привет! Ты какими судьбами тут?")
                {
                    Misas.text = "Misa: Ух-ты! Привет! Ты какими судьбами тут?";
                }
                if (talktime > 6 && Emilas.text != "Emila: Миша! Здравствуйте!\n\n\n Emila: Я не знаю, что происходит...")
                {
                    Emilas.text = "Emila: Миша! Здравствуйте!\n\n\n Emila: Я не знаю, что происходит...";
                }
                if (talktime > 7 && Misas.text != "Misa: Ух-ты! Привет! Ты какими судьбами тут?\n\n\n Misa: Таааак жизненно! И что ты будешь делать?")
                {
                    Misas.text = "Misa: Ух-ты! Привет! Ты какими судьбами тут?\n\n\n Misa: Таааак жизненно! И что ты будешь делать?";
                }
                if (talktime > 9 && Emilas.text != "Emila: Миша! Здравствуйте!\n\n\n Emila: Я не знаю, что происходит...\n\n\n Emila: Я видела Макина, думаю догнать его.")
                {
                    Emilas.text = "Emila: Миша! Здравствуйте!\n\n\n Emila: Я не знаю, что происходит...\n\n\n Emila: Я видела Макина, думаю догнать его.";
                }
                if (talktime > 11 && Misas.text != "Misa: Ух-ты! Привет! Ты какими судьбами тут?\n\n\n Misa: Таааак жизненно! И что ты будешь делать?\n\n\nMisa: Ддаа... Он тут проходил недавно... Погоди, что с твоими линиями?" && Emilas.text != "")
                {
                    Misas.text = "Misa: Ух-ты! Привет! Ты какими судьбами тут?\n\n\n Misa: Таааак жизненно! И что ты будешь делать?\n\n\nMisa: Ддаа... Он тут проходил недавно... Погоди, что с твоими линиями?";
                }
            }
            if (talktime > 14 && GameObject.FindGameObjectsWithTag("size").Length == 0 && talktime < 20 )
            {
                Misas.text = "";
                Emilas.text = "";
                Instantiate(sz, cam.GetComponent<drawscript>().newone.transform.position, Quaternion.Euler(0,0,cam.GetComponent<drawscript>().newone.transform.rotation.eulerAngles.z+180));

            }
            if (talktime > 18 && talktime < 20 && Misas.text != "Misa: Эмила!? Это что!? Линия не по ГОСТу, надо стереть!" && Misas.text != "Misa: Эмила!? Это чтo!? Линия не по ГОСТу, надо стереть!")
            {
                Misas.text = "Misa: Эмила!? Это что!? Линия не по ГОСТу, надо стереть!";
            }
            if (talktime > 20 && Misas.text == "Misa: Эмила!? Это что!? Линия не по ГОСТу, надо стереть!")
            {
                Misas.text = "Misa: Эмила!? Это чтo!? Линия не по ГОСТу, надо стереть!";
                Instantiate(eraser);
            }
            if (cam.transform.position.x < -18)
            {
                Destroy(Misa);
                Misas.text = "";
                cam.GetComponent<CameraControll>().m = false;
                GameObject.Find("Emila").GetComponent<Controll>().talking = false;
                Emilas.text = "Emila: Эй! Куда он пропал?";
                if (GameObject.FindGameObjectsWithTag("size").Length > 0)
                Destroy(GameObject.FindGameObjectsWithTag("size")[0]);
            }
        }
        lastx = GameObject.Find("Emila").transform.position.x;
    }
}

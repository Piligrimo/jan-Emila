using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossLili : MonoBehaviour {
    float csttime,victory,lasdst, fighttime = 0, fighttime0 = 0, trueVictory=50;
    public GameObject ammo, enemy,sp1,sp2,detectorj,detectore,sprks,lght,sprkse,lghte,Elmy,penend,boom,box1,box2,wall;
    int atack = 0;
    public Text txt;
    public Vector3 coll,coll2;
    public Quaternion cr;
    public Image em, ja;
    bool lastfght=false;
    string[] s = {"jan sitelen lili: Не судите строго!", "jan sitelen lili: У меня еще паблик есть!", "jan sitelen lili (врет): Я пять лет училась в художке и ты будешь учить меня рисовать?", "jan sitelen lili: Ты не умеешь рисовать!", "jan sitelen lili: Твои линии недостаточно ровные!", "jan sitelen lili: Сейчас увидим, кто лучше рисует!", "jan sitelen lili: У меня все нормально с анатомией, это ты не разбираешься!", "jan sitelen lili: Я все сама придумываю, мои персонажи - самые оригинальные!" };
   void Start () {

        csttime = Time.time;
        Elmy = GameObject.Find("Emila");
        em.gameObject.SetActive(false);
        ja.gameObject.SetActive(false);
        sp1.gameObject.SetActive(false);
        sp2.gameObject.SetActive(false);
        sprks.gameObject.SetActive(false);
        sprkse.gameObject.SetActive(false);
        lght.gameObject.SetActive(false);
        lghte.gameObject.SetActive(false);
    }


    void Update()
    {
       
        GetComponent<Animator>().SetBool("atk",false);
        fighttime += Time.deltaTime;
        Vector3 dst = transform.position - GameObject.Find("Emila").transform.position;
        GameObject.Find("Main Camera").GetComponent<CameraControll>().bossFight = dst.magnitude < 20;
        if (dst.magnitude > 20 && victory > 0)
            victory -= 3 * Time.deltaTime;
        if (dst.magnitude < 20 && lasdst > 20 && fighttime <= 0)
        {
            fighttime = 0;
            csttime = 5;
        }
        fighttime0 += Time.deltaTime;
      
        if (dst.magnitude > 50)
            if (fighttime >= csttime)
            {
                csttime += 8;
                GameObject hit = Instantiate(ammo, transform.position, transform.rotation) as GameObject;
                hit.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Cos(hit.transform.rotation.z), Mathf.Sin(hit.transform.rotation.z)) * 7;
            }
        if (dst.magnitude < 50 && dst.magnitude > 20)
            if (fighttime >= csttime)
            {
                csttime += 8;
                GameObject hit = Instantiate(ammo, transform.position, transform.rotation) as GameObject;
                hit.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Cos(hit.transform.rotation.z), Mathf.Sin(hit.transform.rotation.z)) * 7;
                GameObject hit1 = Instantiate(ammo, transform.position + new Vector3(0.5f, 0, 0), transform.rotation) as GameObject;
                hit1.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Cos(hit1.transform.rotation.z), Mathf.Sin(hit.transform.rotation.z)) * 7;
                GameObject hit2 = Instantiate(ammo, transform.position + new Vector3(1f, 0, 0), transform.rotation) as GameObject;
                hit2.GetComponent<Rigidbody2D>().velocity = new Vector2(-Mathf.Cos(hit2.transform.rotation.z), Mathf.Sin(hit.transform.rotation.z)) * 7;

            }
        if (dst.magnitude < 20)
        {
            em.gameObject.SetActive(true);
            ja.gameObject.SetActive(true);
            if (!lastfght)
            {
                victory += Time.deltaTime;
                
                int lastatck = atack;
                atack = (int)(fighttime / 15) % 3;
                if (atack != lastatck)
                    txt.text = s[(int)(Random.value * s.Length)];
                if (fighttime > csttime && atack == 0)
                {
                    csttime += 1;
                    float an;
                    if (transform.position.y > Elmy.transform.position.y)
                        an = Vector3.Angle(transform.position - GameObject.Find("Emila").transform.position, Vector3.right);
                    else
                        an = -Vector3.Angle(transform.position - GameObject.Find("Emila").transform.position, Vector3.right);

                    GameObject hit = Instantiate(ammo, transform.position, Quaternion.Euler(0, 0, an)) as GameObject;
                    hit.GetComponent<Rigidbody2D>().velocity = -new Vector2(Mathf.Cos(hit.transform.rotation.z), Mathf.Sin(hit.transform.rotation.z)) * 7;
                    GetComponent<Animator>().SetBool("atk", true);
                }
                if (fighttime > csttime && atack == 1)
                {
                    csttime += 5f;
                    float an;
                    if (transform.position.y > Elmy.transform.position.y)
                        an = Vector3.Angle(transform.position - Elmy.transform.position, Vector3.right);
                    else
                        an = -Vector3.Angle(transform.position - Elmy.transform.position, Vector3.right); GameObject hit = Instantiate(ammo, transform.position, Quaternion.Euler(0, 0, an)) as GameObject;
                    hit.GetComponent<Rigidbody2D>().velocity = -new Vector2(Mathf.Cos(hit.transform.rotation.z), Mathf.Sin(hit.transform.rotation.z)) * 14f;
                    GetComponent<Animator>().SetBool("atk", true);
                }
                if (fighttime > csttime && atack == 2)
                {
                    csttime += 3;
                    Instantiate(enemy, transform.position, Quaternion.Euler(0, 0, 0));
                    GetComponent<Animator>().SetBool("atk", true);
                }
                sp1.SetActive(atack == 2);
                sp2.SetActive(atack == 2);

                lasdst = dst.magnitude;
                em.fillAmount = victory / 100;
                ja.fillAmount = (100 - victory) / 100;
                if (victory > 100)
                {
                    lastfght = true;
                    sprks.gameObject.SetActive(true);
                    sprkse.gameObject.SetActive(true);
                    lght.gameObject.SetActive(true);
                    lghte.gameObject.SetActive(true);
                }
            }
            else
            {
                txt.text = "Двигай мышкой как можно быстрее для победы в магической дуэли!";
                Vector3 v = (transform.position - penend.transform.position);
                v.Normalize();
                v *= 1.5f;
                sprks.transform.position = penend.transform.position + (((trueVictory) / 100) * (transform.position - penend.transform.position)) + v;
                sprks.transform.rotation = Quaternion.Euler(0, 0, 180 * Mathf.Atan2((transform.position - penend.transform.position).y, (transform.position - penend.transform.position).x) / 3.141596f + 180);
                lght.transform.rotation = Quaternion.Euler(0, 0, 180 * Mathf.Atan2((transform.position - penend.transform.position).y, (transform.position - penend.transform.position).x) / 3.141596f + 180);
                lght.transform.localScale = new Vector3((lght.transform.position - sprks.transform.position).magnitude / 3.1f, 2, 2);
                sprkse.transform.position = penend.transform.position + (((trueVictory) / 100) * (transform.position - penend.transform.position)) - v;
                sprkse.transform.rotation = Quaternion.Euler(0, 0, 180 * Mathf.Atan2((transform.position - penend.transform.position).y, (transform.position - penend.transform.position).x) / 3.141596f);
                lghte.transform.position = penend.transform.position;
                lghte.transform.rotation = Quaternion.Euler(0, 0, 180 * Mathf.Atan2((transform.position - penend.transform.position).y, (transform.position - penend.transform.position).x) / 3.141596f);
                lghte.transform.localScale = new Vector3((lghte.transform.position - sprkse.transform.position).magnitude / 3.1f, 2, 2);
                if (trueVictory!=666)
                    trueVictory = trueVictory + 0.07f * Mathf.Sqrt(Input.GetAxis("Mouse X") * Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y") * Input.GetAxis("Mouse Y")) - .1f;
                if (trueVictory < 10)
                {
                    Elmy.transform.position = Elmy.GetComponent<Controll>().checkpoint;
                    Elmy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    Instantiate(boom, Elmy.transform.position, Quaternion.Euler(0, 0, 0));
                    victory = 0;
                    trueVictory = 50;
                    lastfght = false;
                }
                if (trueVictory>90 && trueVictory!= 666)
                {
                    Instantiate(boom, transform.position, Quaternion.Euler(0, 0, 0));
                    sprks.gameObject.SetActive(false);
                    sprkse.gameObject.SetActive(false);
                    lght.gameObject.SetActive(false);
                    lghte.gameObject.SetActive(false);
                    box1.GetComponent<Collider2D>().enabled = false;
                    box2.GetComponent<Collider2D>().enabled = false;
                    GetComponent<Collider2D>().enabled = false;
                    box1.AddComponent<Rigidbody2D>();
                    box1.GetComponent<Rigidbody2D>().velocity = new Vector2(5,10);
                    box1.GetComponent<Rigidbody2D>().angularVelocity = 10;
                    box2.AddComponent<Rigidbody2D>();
                    box2.GetComponent<Rigidbody2D>().velocity = new Vector2(-6f, 7f);
                    box2.GetComponent<Rigidbody2D>().angularVelocity = -30;
                    gameObject.AddComponent<Rigidbody2D>();
                    GetComponent<Rigidbody2D>().velocity = new Vector2(.1f, 15);
                    GetComponent<Rigidbody2D>().angularVelocity = 25;
                    wall.AddComponent<Rigidbody2D>();
                    wall.tag = "floor";
                    trueVictory = 666;
                    txt.text = "jan sitelen lili: Ты пожалеешь!!!";
                    txt.fontSize += 10;
                }
            }
        }
    else
        {
            sprks.gameObject.SetActive(false);
            sprkse.gameObject.SetActive(false);
            lght.gameObject.SetActive(false);
            lghte.gameObject.SetActive(false);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Karakter : MonoBehaviour
{
    public Animator silahAnim;
    public int maxMermi = 120;
    public int kullanilanMermi = 30;
    public float FenerPili = 100;
    public int pilAdedi = 0;
    public Text pilText;
    public Text bilgiText;
    int silahMenzil = 10;
    public bool Reload = false;
    public Slider fenerYuzde;
    public GameObject mermiIzi;
    RaycastHit hit;
    public LayerMask layer;
    public int Can = 100;
    Envanter env;
    public altPanel panel;


    // Start is called before the first frame update
    void Start()
    {
        env = GameObject.Find("Script").GetComponent<Envanter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Can <= 0)
        {
            SceneManager.LoadScene("sahnegiris");
        }
        Fener();
        Animasyonlar();
        itemEkle();
        Kapi();
        Bilgi();
    }

    void Animasyonlar()
    {
        if (Input.GetMouseButton(0))
        {
            if(kullanilanMermi>0)
            {
                silahAnim.SetTrigger("Ates");
            }
            
        }
        if (Input.GetMouseButton(1))
        {
            silahAnim.SetBool("YakinBakis", true);
        }
        else
        {
            silahAnim.SetBool("YakinBakis", false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(kullanilanMermi < 30 && maxMermi >0){
                silahAnim.SetTrigger("Reload");
            }
        }
    }
    public void Ates()
    {
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,silahMenzil,layer))
        {
            if (hit.transform.gameObject.tag == "Dusman")
            {
                hit.transform.gameObject.GetComponent<DusmanScript>().Can -= Random.Range(5, 9);
                hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Vuruldum");
            }
            else
            {
                Instantiate(mermiIzi, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

            }
        }

    }
    public void itemEkle()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, 5, layer))
            {
                if (hit.transform.gameObject.tag == "Anahtar1")
                {
                    env.ItemEkle(1);
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.gameObject.tag == "Anahtar2")
                {
                    env.ItemEkle(3);
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.gameObject.tag == "Fener")
                {
                    env.ItemEkle(4);
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.gameObject.tag == "Anahtar3")
                {
                    env.ItemEkle(5);
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.gameObject.tag == "Silah")
                {
                    env.ItemEkle(2);
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.gameObject.tag == "Pil")
                {
                    pilAdedi++;
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
    public void Kapi()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, 5,layer))
            {
                if (hit.transform.gameObject.tag == "Kapi")
                {
                    if (env.items[panel.slotsayi].itemismi=="Anahtar")
                    {
                        if(hit.transform.gameObject.GetComponent<kapiScript>().KapiKodu == env.items[panel.slotsayi].itemKodu)
                        {
                            hit.transform.gameObject.GetComponent<Animator>().SetTrigger("kapiAcilma");
                            env.items[panel.slotsayi].itemismi = null;
                        }
                        else
                        {
                            hit.transform.gameObject.GetComponent<Animator>().SetTrigger("kapiKilitli");
                        }
                    }
                }

            }
        }
    }
    public void Fener()
    {
        if(env.items[panel.slotsayi].itemismi=="Fener")
        {
            fenerYuzde.gameObject.SetActive(true);
            fenerYuzde.value = FenerPili;
            if (pilAdedi > 0)
            {
                if(FenerPili < 0)
                {
                    pilText.text = "Pil Takmak İçin Sol Tıkla.";

                }
                else
                {
                    pilText.text = "Pil Adedi : " + pilAdedi.ToString();

                }
                if (Input.GetMouseButtonDown(0))
                {
                    pilAdedi--;
                    FenerPili = 100;
                }
            }
            else
            {
                if(FenerPili > 0)
                {
                    pilText.text = "Piliniz Yok!";
                }
            }
            
        }
        else
        {
            fenerYuzde.gameObject.SetActive(false);
            pilText.text = "";
        }
    }
    public void Bilgi()
    {
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,4, layer))
        {
            if (hit.transform.gameObject.layer == 10)
            {
                bilgiText.text = hit.transform.gameObject.name+" almak için F tuşuna basın.";

            }
            else if(hit.transform.gameObject.layer==11){
                if (hit.transform.gameObject.GetComponent<kapiScript>().KapiKodu == env.items[panel.slotsayi].itemKodu)
                {
                    bilgiText.text = "Kapıyı açmak için E tuşuna basın.";
                }
                else
                {
                    bilgiText.text = "Anahtar Eksik.";
                }
            }
            else
            {
                bilgiText.text = "";
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class altPanel : MonoBehaviour
{
    public List<GameObject> slotlar;
    public int slotsayi;
    public Sprite seciliSlot, bosSlot;
    Envanter env;
    public GameObject panel;
    bool boolsecili = false;
    El el;

    void Start()
    {
        env = GameObject.Find("Script").GetComponent<Envanter>();
        el = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<El>();
        panel = transform.gameObject;
        Invoke("slotlariesle", 1);
       
    }

    void Update()
    {
        if (boolsecili)
        {
            SecilenSlot();
            slotuBelirle();
            itemSec(env.items[slotsayi]);
        }
        
    }

    void slotuBelirle()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotsayi = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotsayi = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotsayi = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotsayi = 3;
        }
    }
    public void slotlariesle()
    {
        slotlar[0] = panel.transform.GetChild(0).gameObject;
        slotlar[1] = panel.transform.GetChild(1).gameObject;
        slotlar[2] = panel.transform.GetChild(2).gameObject;
        slotlar[3] = panel.transform.GetChild(3).gameObject;
        boolsecili = true;
    }
    void SecilenSlot()
    {
        for(int i=0; i < 4; i++)
        {
            slotlar[i].GetComponent<Image>().sprite = bosSlot;
        }
        slotlar[slotsayi].GetComponent<Image>().sprite = seciliSlot;
    }

    void itemSec(Item item)
    {
        for(int i = 0; i < el.objeler.Count; i++)
        {
            if (el.objeler[i].name == item.itemismi)
            {
                el.objeler[i].SetActive(true);
            }
            else
            {
                el.objeler[i].SetActive(false);
            }
        }
    }
}

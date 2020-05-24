using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int slotsayi;
    public Item item;
    Envanter env;
    public Image itemicon;

    void Start()
    {
        env = GameObject.Find("Script").GetComponent<Envanter>();
    }

    void Update()
    {
        item = env.items[slotsayi];
        if (item.itemismi != null)
        {
            itemicon.enabled = true;
            itemicon.sprite = item.itemicon;
        }
        else
        {
            itemicon.enabled = false;

        }
    }
}

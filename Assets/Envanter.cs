using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envanter : MonoBehaviour
{
    public List<Item> items;
    public int slotmiktar;
    public GameObject slot;
    public GameObject Panel;
    DataItem dataItem;

    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Ses");
        dataItem = GameObject.Find("Script").GetComponent<DataItem>();
        for (int i = 0; i < slotmiktar; i++)
        {
            GameObject slotobj = (GameObject)Instantiate(slot);
            slotobj.transform.SetParent(Panel.transform);
            slotobj.GetComponent<Slot>().slotsayi = i;
        }
        for(int i = 0; i < slotmiktar; i++)
        {
            items.Add(new Item());
        }
        
    }

    public void ItemEkle(int id)
    {
        for(int i=0; i < dataItem.items.Count; i++)
        {
            if (dataItem.items[i].itemid == id)
            {
                Item yenitem = new Item(dataItem.items[i].itemid, dataItem.items[i].itemKodu, dataItem.items[i].itemismi, dataItem.items[i].itemTipi);
                BosSLotaEkle(yenitem);
            }
        }
    }
    public void BosSLotaEkle(Item item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].itemismi == null)
            {
                items[i] = item;
                break;
            }
        }
    }
   
}

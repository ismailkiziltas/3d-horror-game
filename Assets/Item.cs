using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int itemid;
    public int itemKodu;
    public ItemType itemTipi;
    public Sprite itemicon;
    public string itemismi;

    public enum ItemType
    {
        Silah,
        Anahtar,
        Fener,
        Bos
    }
    public Item(int id, int kod, string isim,ItemType tipi)
    {
        itemid = id;
        itemismi = isim;
        itemicon = Resources.Load<Sprite>(id.ToString());
        itemKodu = kod;
        itemTipi = tipi;
    }
    public Item()
    {

    }
}

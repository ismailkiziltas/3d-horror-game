using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataItem : MonoBehaviour
{
    public List<Item> items;

    void Awake()
    {
        items.Add(new Item(0, 0, "", Item.ItemType.Bos));
        items.Add(new Item(1, 1, "Anahtar", Item.ItemType.Anahtar));
        items.Add(new Item(2, 0, "Silah", Item.ItemType.Silah));
        items.Add(new Item(3, 2, "Anahtar", Item.ItemType.Anahtar));
        items.Add(new Item(4, 0, "Fener", Item.ItemType.Fener));
        items.Add(new Item(5, 3, "Anahtar", Item.ItemType.Anahtar));
    }
}

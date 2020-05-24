using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapiScript : MonoBehaviour
{
    public int KapiKodu;
    BoxCollider bc;
    private void Start()
    {
        bc = GetComponent<BoxCollider>();
    }
    public void bcSil()
    {
        Destroy(bc);
    }
}

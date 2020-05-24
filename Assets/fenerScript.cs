using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fenerScript : MonoBehaviour
{
    Karakter kr;
    Light isik;

    // Start is called before the first frame update
    void Start()
    {
        kr = GameObject.FindGameObjectWithTag("Karakter").GetComponent<Karakter>();
        isik = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(kr.FenerPili > 0)
        {
            isik.enabled = true;
            kr.FenerPili -= Time.deltaTime * 2;
        }
        else
        {
            isik.enabled = false;
        }
    }
}

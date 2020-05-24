using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject Karakter;
    //public GameObject Canvas;
    public GameObject altPanel;
    public GameObject image;
    public GameObject slider;
    public void aktifEt()
    {
        Karakter.SetActive(true);
        altPanel.SetActive(true);
        image.SetActive(true);
        slider.SetActive(true);
        Destroy(gameObject);
    }
}

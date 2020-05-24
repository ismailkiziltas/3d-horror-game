using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public Slider ses;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OyunuBaslat()
    {
        SceneManager.LoadScene("sahne1");
    }
    public void Kapat()
    {
        Application.Quit();
    }
    public void panelAc()
    {
        panel.SetActive(true);
        ses.value = PlayerPrefs.GetFloat("Ses");
    }
    public void panelKapat()
    {
        panel.SetActive(false);
    }
    public void DusukGrafik()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void OrtaGrafik()
    {
        QualitySettings.SetQualityLevel(3);
    }
    public void YuksekGrafik()
    {
        QualitySettings.SetQualityLevel(8);
    }
    public void SesAyari()
    {
        PlayerPrefs.SetFloat("Ses", ses.value);
    }
}

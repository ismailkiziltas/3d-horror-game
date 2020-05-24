using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silahIslem : MonoBehaviour
{
    public Karakter kr;
    Animator anim;
    AudioSource ses;
    public AudioClip sesAtes;
    public AudioClip sesReload;
    public AudioClip sesGosterSakla;
    // Start is called before the first frame update
    void Start()
    {
        ses = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    public void mermiSayisiAzalt()
    {
        ses.clip = sesAtes;
        ses.Play();
        kr.Ates();
        kr.kullanilanMermi--;
        anim.ResetTrigger("Ates");
    }
    public void Reload()
    {
        if (kr.kullanilanMermi < 30 && kr.maxMermi > 0)
        {
            for (int i = 0; i < 30; i++)
            {
                if (kr.kullanilanMermi < 30 && kr.maxMermi > 0)
                {
                    kr.kullanilanMermi++;
                    kr.maxMermi--;
                    kr.Reload = false;
                }

            }
        }
    }
    public void ReloadSes()
    {
        ses.clip = sesReload;
        ses.Play();
    }
    public void gosterSaklaSes()
    {
        ses.clip = sesGosterSakla;
        ses.Play();
    }
}

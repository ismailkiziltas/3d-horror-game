using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScare : MonoBehaviour
{
    public GameObject image;
    AudioSource ses;
    public AudioClip sesKorku;
    public GameObject zombi;
    void Start()
    {
        ses = GetComponent<AudioSource>();    
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Karakter")
        {
            zombi.SetActive(true);
            image.SetActive(true);
            ses.clip = sesKorku;
            ses.Play();
            Destroy(image, 0.5f);
            Destroy(gameObject,1f);
        }
    }
}

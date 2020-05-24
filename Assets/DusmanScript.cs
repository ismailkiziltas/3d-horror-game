using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DusmanScript : MonoBehaviour
{
    public AudioSource ses;
    public AudioClip sesYurume;
    public AudioClip sesVurma;
    public NavMeshAgent yapayZeka;
    Rigidbody rb;
    CapsuleCollider cc;
    public GameObject hedef;
    float Uzaklik;
    Animator myAnim;
    Karakter kr;
    public int Can = 100;
    public GameObject anahtar;
    public bool anahtarurettimi = false;
    public GameObject objePozisyon;
    // Start is called before the first frame update
    void Start()
    {
        ses = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        yapayZeka = GetComponent<NavMeshAgent>();
        myAnim = GetComponent<Animator>();
        kr = hedef.GetComponent<Karakter>();
        cc = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Uzaklik = Vector3.Distance(gameObject.transform.position, hedef.transform.position);
        if(Can <= 0)
        {
            if (anahtarurettimi == false)
            {
                Instantiate(anahtar,objePozisyon.transform.position, Quaternion.identity);
                anahtarurettimi = true;
            }
            cc.enabled = false;
            rb.isKinematic = true;
            myAnim.ResetTrigger("Atak");
            myAnim.ResetTrigger("Vuruldum");
            myAnim.SetTrigger("Oldum");
            myAnim.SetBool("Yurume",false);
            yapayZeka.isStopped = true;
            Destroy(gameObject, 10);
        }
        else { 
            if (Uzaklik > 2)
            {
                myAnim.SetBool("Yurume", true);
            
                yapayZeka.isStopped = false;
                yapayZeka.SetDestination(hedef.transform.position);
            }
            else
            {
                myAnim.SetBool("Yurume", false);
                myAnim.SetTrigger("Atak");
                Dondurme(hedef.transform);
                yapayZeka.isStopped = true;
            }
        }
    }
    private void Dondurme(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion Bakis = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, Bakis, Time.deltaTime * 2);
    }
    public void hedefcanAzalt()
    {
        ses.clip = sesVurma;
        ses.Play();
        kr.Can -= Random.Range(4, 12);
    }
    public void yurumeSesi()
    {
        ses.clip = sesYurume;
        ses.Play();
    }
}

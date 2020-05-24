using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunBitti : MonoBehaviour
{
    public GameObject altpanel;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Karakter")
        {
            altpanel.SetActive(false);
            Panel.SetActive(true);
            Invoke("anamenu", 3);
        }
    }
    public void anamenu()
    {
        SceneManager.LoadScene("sahnegiris");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationDelegate : MonoBehaviour
{
    public GameObject img3,img2,img1;
    public Animator anim;

    

    // Start is called before the first frame update
    void Start()
    {
      
        anim = GameObject.Find("countdown").GetComponent<Animator>();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void img3_ON()
    {
        img3.SetActive(true);
        anim.Play("3");
    }

    void img3_OFF()
    {
        img3.SetActive(false);
    }
    void img2_ON()
    {
        img2.SetActive(true);
        anim.Play("2");
    }

    void img2_OFF()
    {
        img2.SetActive(false);
    }
    void img1_ON()
    {
        img1.SetActive(true);
        anim.Play("1");
    }

    void img1_OFF()
    {
        img1.SetActive(false);
    }
}

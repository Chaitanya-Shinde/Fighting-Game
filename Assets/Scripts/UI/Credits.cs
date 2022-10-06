using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Animator transAnim;
    public float transTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transAnim = GameObject.Find("FadeTrans").GetComponent<Animator>();
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadMain());
    }

    IEnumerator LoadMain()
    {
       
            transAnim.SetTrigger("OnFade");
            yield return new WaitForSeconds(transTime);
            SceneManager.LoadScene(0);
       
        
        

    }
}

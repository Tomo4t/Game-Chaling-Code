using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class loadscenes : MonoBehaviour
{
    public Animator Animator;
    public float transitiontime = 1f;

    public static loadscenes instance;

    

    public void Awake()
    {
        if (instance == null)
        instance = this;

    }

    public void loadenextscene(string scenename)
    {
        StartCoroutine(enumerator(scenename));
    }
    public void LoodLevelOrTou()
    {
        if (ShopManager.instance.TourilButten.gameObject.activeSelf)
        {
            loadenextscene("Office");
        }
        else 
        {
            loadenextscene("Toutorial");
        }
    }

    IEnumerator enumerator(string sceneload)
    {
        Animator.SetTrigger("StartTra");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(sceneload);
       
    }

}
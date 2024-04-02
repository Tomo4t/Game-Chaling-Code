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
    public void loadeArabic(string scenename)
    {
        PlayerPrefs.SetInt("Lung", 0);
        PlayerPrefs.Save();
        StartCoroutine(enumerator(scenename));
    }
    public void loadeEnglish(string scenename)
    {
        PlayerPrefs.SetInt("Lung", 1);
        PlayerPrefs.Save();
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
    public void ArLoodLevelOrTou()
    {
        if (ShopManager.instance.TourilButten.gameObject.activeSelf)
        {
            loadenextscene("ArOffice");
        }
        else
        {
            loadenextscene("ArToutorial");
        }
    }
    IEnumerator enumerator(string sceneload)
    {
        Animator.SetTrigger("StartTra");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(sceneload);
       
    }

}
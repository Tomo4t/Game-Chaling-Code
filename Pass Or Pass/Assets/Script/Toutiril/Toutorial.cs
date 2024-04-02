using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Toutorial : MonoBehaviour, IDataPersistence
{
    public Animator Apaper, Acarecter;

    public static bool Right, Left, Up, Doun, butten, butten2, Phone, brosed = false, stamp,Paaper;

    public GameObject Clint,Paper,Hand1, hand2, hand3, hand4, hand5,hand6,hand7,hand8,hand9,hnd10;

    public BoxCollider phone, stampg, paper;

    public GameObject Text1, Text2, Text3, Text4, Text5,Text6;

    public string sceentolood = "MainRoom";
    public IEnumerator Start() 
    {

        DataPersistenceManager.Instance.LoadGame();

        Hand1.SetActive(true);
        yield return new WaitUntil(() => Right);
        Hand1.SetActive(false);
        Text1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.touchCount > 0);
        Text1.gameObject.SetActive(false);
        Text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.touchCount > 0);
        Text2.gameObject.SetActive(false);
        hand2.SetActive(true);
        yield return new WaitUntil(() => butten);
        Text2.gameObject.SetActive(false);
        hand2.SetActive(false);
        hand3.SetActive(true);
        yield return new WaitUntil(() => Left);
        hand3.SetActive(false);
        Text3.gameObject.SetActive(true);
        hand4.SetActive(true);
        phone.enabled = true;
        yield return new WaitUntil(() => Phone);
        Text3.gameObject.SetActive(false);
        hand4.SetActive(false);
        hand5.SetActive(true);
        Clint.SetActive(true);
        Paper.SetActive(true);
        yield return new WaitUntil(() => Doun);
        Text6.SetActive(true);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.touchCount > 0);
        Text6.SetActive(false);
        hand5.SetActive(false);
        Text4.gameObject.SetActive(false);
        Text5.gameObject.SetActive(true);
        hand6.SetActive(true);
        stampg.enabled = true;
        yield return new WaitUntil(() => stamp);
        SealMovement.instance.Toutoreal();
        Text5.gameObject.SetActive(false);
        hand6.SetActive(false);
        hand7.SetActive(true);
        yield return new WaitUntil(() => Up);
        hand7.SetActive(false);
        hand8.SetActive(true);
        paper.enabled = true;
        yield return new WaitUntil(() => Paaper);
        hand8.SetActive(false);
        Apaper.SetTrigger("1");
        yield return new WaitForSeconds(0.5f);
        Paper.SetActive(false);
        Acarecter.SetTrigger("1");
        yield return new WaitForSeconds(0.5f);
        hand9.SetActive(true);
        hand9.SetActive(false);
        Clint.SetActive(false);
       

        DataPersistenceManager.Instance.SaveGame();

        loadscenes.instance.loadenextscene(sceentolood);

    }
    public void BrestButten1() 
    { butten = true; }
    public void BrestButten2()
    { butten2 = true; }
    public void Update()
    {
        if (Input.touchCount > 0)
        {
            RaycastHit hit;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.CompareTag("phone"))
                    {
                        Phone = true;
                    }
                    if (hit.collider.gameObject.CompareTag("Green"))
                    {
                        stamp = true;
                    }
                    if (hit.collider.gameObject.CompareTag("paper"))
                    {
                        Paaper = true;
                    }
                }
            }
        }
    }

    public void LoadData(GameData data)
    {
       
    }

    public void SaveData(ref GameData data)
    {
        data.PlayedTou = true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DilogeManger : MonoBehaviour
{
    [SerializeField] private GameObject dialogueparent;
    [SerializeField] private GameObject buttonparent;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;
    [SerializeField] private float typengSpeed = 0.05f;

    public AudioSource Text;

    public static bool isAcceptBribe = false;

    private int currentDialogeIndex = 0;

    public static DilogeManger instance;

    public void Awake()
    {
        if (instance == null)
        instance = this; 
    }
    

    public void dialogueStart(Pearson Customer)
    {
        dialogueparent.gameObject.SetActive(true);
        DisableButtons();
        StartCoroutine(printDialogue(Customer));
    }
    private void DisableButtons()
    {
       
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);

    }
    private bool optionSlected = false;
    private IEnumerator printDialogue(Pearson Customer)
    {
        currentDialogeIndex = 0;
       
        Speatch dialogue = Customer.Speatch;
        dialogue.LastLine = false;

        do
        {
            CustomersMovement.TryToBribe = false;
           
            if (currentDialogeIndex >=  dialogue.Diloge.Count - 2 && Customer.DoamintInfo.TackBribe == true)
            {
                dialogue.LastLine = true;
            }
            else if(currentDialogeIndex >= dialogue.Diloge.Count - 1)
            {
                dialogue.LastLine = true;
            }
            string line = dialogue.Diloge.GetValueOrDefault(currentDialogeIndex);

            if (currentDialogeIndex > 0)
            {
              
                yield return new WaitUntil(() => CustomersMovement.TryToBribe);
                dialogueparent.SetActive(true);
            }

            if (dialogue.GiveBrib && Customer.DoamintInfo.TackBribe == true)
            {
                int moany = UnityEngine.Random.Range(40, 50);
                if (dialogue.LastLine == false)
                {
                    yield return StartCoroutine(typeText(line + " " + moany, dialogue));
                }
                else
                {
                    yield return StartCoroutine(typeText(line , dialogue));
                }
              
                option1Button.interactable = true;
                option2Button.interactable = true;
               
                option1Button.GetComponentInChildren<TMP_Text>().text = "No";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Yes";
                option1Button.onClick.AddListener(() => PaseBribe(dialogue.Diloge.Count - 2));
                option2Button.onClick.AddListener(() => TackBribe(dialogue.Diloge.Count - 1 , moany));
                buttonparent.SetActive(true);
                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                yield return new WaitUntil(() => optionSlected);
                dialogue.GiveBrib = false;
                
            }
            else if (currentDialogeIndex != 0 && Customer.DoamintInfo.TackBribe == true) 
            {
                dialogue.LastLine = true;
                yield return StartCoroutine(typeText("Realy? \n I mean Thanks", dialogue));
               
            }
            else 
            {
                Debug.Log("4");
              
                yield return StartCoroutine(typeText(line, dialogue));
            }
            optionSlected = false;
           
        }
        while (dialogue.LastLine == false);
        
       
        DialogueStop();
    }
    private void PaseBribe(int indexJump)
    {
       
        DisableButtons();
        currentDialogeIndex = indexJump;
        optionSlected = true;
    }
    private void TackBribe(int indexJump, int moany)
    {
        isAcceptBribe = true;



        DisableButtons();
        Enum.TryParse<Types>(Asiner.CurintClint.DoamintInfo.Type, out Types parsedEnum);
        int num = 0;
        if (Asiner.Instince.Bribes.ContainsKey(parsedEnum))
        {
            Asiner.Instince.Bribes.TryGetValue(parsedEnum, out num);
            Asiner.Instince.Bribes.Remove(parsedEnum);
            Asiner.Instince.Bribes.Add(parsedEnum, num+ 1);
        }
        else
        {
            Asiner.Instince.Bribes.Add(parsedEnum, 0);
        }
        
        Asiner.Instince.UpdateMony(moany);
       
        SealMovement.instance.AcpetBribe();
        currentDialogeIndex = indexJump;
        
       
        optionSlected = true;
    }

    private IEnumerator typeText(string text , Speatch dialogue)
    {
        dialogueText.text = "";
       
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typengSpeed);
            Text.Play();
        }
        Text.Stop();
        if (dialogue.LastLine == false)
        {
            yield return new WaitUntil(() => Input.touchCount > 0);
        }
      
        if (dialogue.LastLine)
        {
            CustomersMovement.inRoom = false;
           
            buttonparent.gameObject.SetActive(false);
            StopAllCoroutines();
            DialogueStop();

        }
      
        currentDialogeIndex++;
    }
    public void LeveRome()
    {
        CustomersMovement.inRoom = false;
        CustomersMovement.instance.MovePaperToCharacter();
        buttonparent.gameObject.SetActive(false);
      
        DialogueStop();
    }
    public void DialogueStop()
    {
        CustomersMovement.instance.MovePaperToCharacter();
        dialogueText.text = "";
        dialogueparent.SetActive(false);
       
        
        StopAllCoroutines();
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject Active, CreateSaveFile,PlayPanel,SavesPanel;
   
    private bool deleate = false;
    [SerializeField] private Button SaveButton1, SaveButton2, SaveButton3;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text  _name, Money, Day, Rank, Notice, date, id, gender, age;
    [SerializeField] private Toggle Gender;

    private void Start()
    {
        if (PlayerPrefs.GetInt("File0", 0) == 1 ? true : false)
        {
            SaveButton1.onClick.RemoveListener(Create); SaveButton1.onClick.AddListener(openPlay); SaveButton1.onClick.AddListener(LoadProfil);
        }
        if (PlayerPrefs.GetInt("File1", 0) == 1 ? true : false)
        {
            SaveButton2.onClick.RemoveListener(Create); SaveButton2.onClick.AddListener(openPlay); SaveButton2.onClick.AddListener(LoadProfil);
        }
        if (PlayerPrefs.GetInt("File2", 0) == 1 ? true : false)
        {
            SaveButton3.onClick.RemoveListener(Create); SaveButton3.onClick.AddListener(openPlay); SaveButton3.onClick.AddListener(LoadProfil);
        }
    }
    public void DeleatSave()
    {
        deleate = true;
        DataPersistenceManager.Instance.SaveGame();
        PlayerPrefs.SetInt("File" +   (DataPersistenceManager.FileToUse),0);
        if (DataPersistenceManager.FileToUse == 0) { SaveButton1.onClick.AddListener(Create); SaveButton1.onClick.RemoveListener(openPlay); SaveButton1.onClick.RemoveListener(LoadProfil);  }

        else if (DataPersistenceManager.FileToUse == 1) { SaveButton2.onClick.AddListener(Create); SaveButton2.onClick.RemoveListener(openPlay); SaveButton2.onClick.RemoveListener(LoadProfil);  }

        else { SaveButton3.onClick.AddListener(Create); SaveButton3.onClick.RemoveListener(openPlay); SaveButton3.onClick.RemoveListener(LoadProfil);  }
        Active.SetActive(false);
        PlayPanel.SetActive(false);
        Active = SavesPanel;
        Active.SetActive(true);

    
    }
    public void Useflile(int filenum)
    {
        DataPersistenceManager.FileToUse = filenum;
        PlayerPrefs.SetInt("File",filenum);
        DataPersistenceManager.Instance.LoadGame();
    }
    public void Create()
    {
        Active = CreateSaveFile;
        CreateSaveFile.SetActive(true);
    }
    public void openPlay() { Active.SetActive(false); Active = PlayPanel; Active.SetActive(true); }
    public void CreateButten() 
    {
        if (DataPersistenceManager.FileToUse == 0) { SaveButton1.onClick.RemoveListener(Create); SaveButton1.onClick.AddListener(openPlay); SaveButton1.onClick.AddListener(LoadProfil);  PlayerPrefs.SetInt("File0", 1); }

        else if (DataPersistenceManager.FileToUse == 1) { SaveButton2.onClick.RemoveListener(Create); SaveButton2.onClick.AddListener(openPlay); SaveButton2.onClick.AddListener(LoadProfil); PlayerPrefs.SetInt("File1", 1); }

        else { SaveButton3.onClick.RemoveListener(Create); SaveButton3.onClick.AddListener(openPlay); SaveButton3.onClick.AddListener(LoadProfil); PlayerPrefs.SetInt("File2", 1); }
        SavesPanel.SetActive(false);
        Active.SetActive(false);
        Active = PlayPanel;
        Active.SetActive(true);
        PlayerPrefs.Save();
        
    }

    

    public void LoadData(GameData data) 
    {
        age.text = data.Age.ToString();
        
        date.text = data.date[0].ToString()+ " / " + data.date[1].ToString()+" / " + data.date[2].ToString();
        Day.text = data.Day.ToString();
        gender.text =(data.isMale ? "M" : "F");
        _name.text = data.Name;
        id.text = data.seed.ToString();
        Money.text = data.Money.ToString();
        Notice.text = data.WeeklyNotice.ToString();
        Rank.text = data.Rank.ToString();
        
    }
    public void SaveData(ref GameData data) 
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
            data.Name = inputField.text;
        }
        else
        {
            data.Name = Gender.isOn ? "Steave" : "Alex";
        }
        if (deleate)
        {
            data = new GameData();
            deleate = false;    
        }
     
        
        data.isMale = Gender.isOn;
    }

    
    public void LoadProfil() 
    {
        DataPersistenceManager.Instance.LoadGame();
    }
    public void saveAndLoad() 
    {
        
        DataPersistenceManager.Instance.SaveGame();
        DataPersistenceManager.Instance.LoadGame();
        
    }

    public void OpenOrClose(GameObject open)
    {
        Active.SetActive(false);
        Active = open;
        Active.SetActive(true);
    }
    
    public void Open(GameObject open)
    {
       
        Active = open;
        Active.SetActive(true);
    }
    private void OnApplicationQuit()
    {
        
    }

}


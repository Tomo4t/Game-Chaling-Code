using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;


public class DataPersistenceManager : MonoBehaviour
{
    [Header("file storage Config")]
    [SerializeField] private string[] fileNames = new string[3] { "SaveData1.game", "SaveData2.game", "SaveData3.game"};
    [SerializeField] public static int FileToUse = 0;

    private GameData gameData;

    private List<IDataPersistence> dataPersistencesObjects;

    private FileDataHandler[] dataHandler = new FileDataHandler[3];
    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance == null) { Instance = this; }else { Destroy(Instance.gameObject); Instance = this; }
        for (int i = 0; i < 3; i++)
        {
            dataHandler[i] = new FileDataHandler(Application.persistentDataPath, fileNames[i]);

        }
        dataPersistencesObjects = FindAllDataPersistenceObjects();
       
    }
    private void Start()
    {
        
    }

    public void NewGame() 
    {
        gameData = new GameData();
    }
    public void LoadGame() 
    {
        Debug.Log("LodingData");
        gameData = dataHandler[PlayerPrefs.GetInt("File")].Load();

        if (gameData == null)
        {
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }
    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        { 
            dataPersistenceObj.SaveData(ref gameData);
        }

        dataHandler[PlayerPrefs.GetInt("File")].Save(gameData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistencesObjects);
    }
}

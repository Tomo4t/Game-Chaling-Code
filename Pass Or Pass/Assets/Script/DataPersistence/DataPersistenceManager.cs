using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DataPersistenceManager : MonoBehaviour
{
    [Header("file storage Config")]
    [SerializeField] private string[] fileNames = new string[3] { "SaveData1.game", "SaveData2.game", "SaveData3.game"};
    [SerializeField] public static int FileToUse;

    private GameData gameData;

    private List<IDataPersistence> dataPersistencesObjects;

    private FileDataHandler[] dataHandler = new FileDataHandler[3];
    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { Instance = this; }else { Debug.LogError("ther is more then one Data Persistence manger in scene"); }
    }
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            dataHandler[i] = new FileDataHandler(Application.persistentDataPath, fileNames[i]);
           
        }
        dataPersistencesObjects = FindAllDataPersistenceObjects();
    }

    public void NewGame() 
    {
        gameData = new GameData();
    }
    public void LoadGame() 
    {
        gameData = dataHandler[FileToUse].Load();

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

        dataHandler[FileToUse].Save(gameData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistencesObjects);
    }
}

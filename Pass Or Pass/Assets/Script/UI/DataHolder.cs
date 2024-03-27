using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHolder : MonoBehaviour
{
    public static Dictionary<Types, int> Bribes = new Dictionary<Types, int>();

    public void Awake()
    {
        DontDestroyOnLoad(this);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainRoom")) Destroy(this.gameObject);
    }
}

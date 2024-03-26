using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{

    public GameObject pausePanel;
    public Button pauseButton;
    private int clickCounter = 0;
    bool ispused = false;
    private void Start()
    {
        
        pauseButton.onClick.AddListener(TogglePause);

    }

    private void TogglePause()
    {
        ispused = !ispused;
       Time.timeScale = ispused ? 0 : 1;
    }


    private void SetInteractableState(bool state)
    {
        pauseButton.interactable = state;
    }
}
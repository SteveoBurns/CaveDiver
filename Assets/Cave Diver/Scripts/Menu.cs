using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private bool isPaused = true;

    private void Start()
    {
        if (isPaused)
            Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            Debug.Log("escape was pressed");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject creditspanel;
    


    private void Update()
    {
        //Run Pause function when escape is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();            
        }
    }

    /// <summary>
    /// Load the game level 1
    /// </summary>
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
        
    }

    /// <summary>
    /// Loads the main menu
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    /// <summary>
    /// Pauses the game and shows the pause panel
    /// </summary>
    public void Pause()
    {
       
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    /// <summary>
    /// Unpauses the game and hides the pause panel.
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    //Show and Hide credits panel
    #region Credits panel
    public void CreditsShow()
    {
        creditspanel.SetActive(true);
    }
    public void CreditsHide()
    {
        creditspanel.SetActive(false);
    }
    #endregion

    /// <summary>
    /// Exit game in build and in editor
    /// </summary>
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}

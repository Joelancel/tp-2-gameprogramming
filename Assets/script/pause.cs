using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private float timer = 0f;
    void Start()
    {
        pauseMenuUI.SetActive(true);
        TogglePauseMenu();
        timer = 0.5f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Escape) && timer > 0.5)
        {
            TogglePauseMenu();
            timer = 0f;
        }

    }


    public void TogglePauseMenu()
    {
        print(pauseMenuUI.activeSelf);
        if (pauseMenuUI.activeSelf)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; 
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        pauseMenuUI.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
 
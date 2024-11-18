using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseManager : MonoBehaviour
{
    private bool isGamePaused = false;
    public GameObject pausePanel;

    public TMP_Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused == false)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused == true)
        {
            pausePanel.SetActive(false);
            Time.timeScale = (float)playPause.timeScale;
            isGamePaused = false;
        }

        levelText.text = enemySpawn.level.ToString();
    }

    public void resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = (float)playPause.timeScale;
        isGamePaused = false;
    }

    public void quitToMenu()
    {
        Application.Quit();
    }
}

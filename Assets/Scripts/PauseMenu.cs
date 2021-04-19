using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject pauseMenuUI;

    public static string playername;

    //zobrazit playername
    [SerializeField] TextMeshProUGUI playerNameText;

    private void Start()
    {
        playerNameText.text = playername;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void SaveDatas()
    {
        ActorData data = new ActorData();
        data.name = playername;
        data.level = SceneManager.GetActiveScene().buildIndex;
        data.score = GameStatus.currentScore;
        data.health = GameStatus.zivot;

        SaveData.SaveActor(data);
    }

    public void LoadData()
    {
        ActorData data = SaveData.LoadName(System.IO.Path.Combine(Application.dataPath, "Resources/actors.xml"), playername);
        GameStatus.currentScore = data.score;
        GameStatus.zivot = data.health;
        SceneManager.LoadScene(data.level);
        gamePaused = false;
        Time.timeScale = 1f;
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gamePaused = false;

    public GameObject pauseMenuUI;

    public static string playername;


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

        ActorContainer actors = new ActorContainer(); //SaveData.LoadActors(System.IO.Path.Combine(Application.dataPath, "Resources/actors.xml"));
        actors.actors.Add(data);
        Console.WriteLine(data);

        SaveData.SaveActors(System.IO.Path.Combine(Application.dataPath, "Resources/actors.xml"), actors);
    }

    public void LoadData()
    {
        ActorData data = SaveData.Load(System.IO.Path.Combine(Application.dataPath, "Resources/actors.xml"), playername);
        GameStatus.currentScore = data.score;
        SceneManager.LoadScene(data.level);
    }
}
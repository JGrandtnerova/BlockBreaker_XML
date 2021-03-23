using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public InputField playername;


    public void LoadNextScene()
    {
        // call script player with name  and level and score 

        PauseMenu.playername = playername.text;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {   
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    public void LoadSavedScene()
    {
        string name = playername.text;
        ActorData data = SaveData.Load(System.IO.Path.Combine(Application.dataPath, "Resources/actors.xml"), name);
        PauseMenu.playername = name;
        GameStatus.currentScore = data.score;
        SceneManager.LoadScene(data.level);
    }

    public void QuitGame()
    {
        Application.Quit();
        FindObjectOfType<GameStatus>().ResetGame();
    }



}

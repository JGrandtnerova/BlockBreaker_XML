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
        // pri presune z levelov
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadfirstScene()
    {
        // zo start buttonu do lvl1 
        
        PauseMenu.playername = playername.text;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        GameStatus.currentScore = 0;
        GameStatus.zivot = 3;
    }

    public void LoadStartScene()
    {   
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    public void LoadSavedScene()
    {
        string name = playername.text;
        ActorData data = SaveData.LoadName(System.IO.Path.Combine(Application.dataPath, "Resources/actors.xml"), name);
        PauseMenu.playername = name;
        
        Debug.Log("Text: " + data.score);
        SceneManager.LoadScene(data.level);
        GameStatus.currentScore = data.score;
        GameStatus.zivot = data.health;
    }

    public void TopScore()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
        FindObjectOfType<GameStatus>().ResetGame();
    }



}

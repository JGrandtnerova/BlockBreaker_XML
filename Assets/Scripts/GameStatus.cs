using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 2;

    [SerializeField] public static int currentScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] bool isAutoPlayEnabled;

    public static int zivot;

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }


    private void Awake()
    {
        scoreText.text = currentScore.ToString();
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        //spocita kolko objektov typu GameStatus mam
        //ak sa zisti ze ich mam viac ako 1 napr. pri prechode do dalsieho levelu tak
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            //toto musim vzdy robit ak pracujem so Singleton Pattern, inak to dobre nefunguje
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetGame()
    {
        Destroy(gameObject);
        //povieme ze ma znicit sam seba ak zacne nova hra, tym sa vlastne vsetko vyresetuje
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}

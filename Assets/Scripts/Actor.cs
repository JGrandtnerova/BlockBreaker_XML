using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public ActorData data = new ActorData();

    [SerializeField]
   public static string playername;

    [SerializeField]
    public static int level = 1;

    [SerializeField]
    public static int score = 0;

    public void StoreData()
    {
        data.name = playername;
        data.score = score;
        data.level = level;
    }

    public void LoadData()
    {
        playername = data.name;
        score = data.score;
        level = data.level;
    }

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {

    }
}


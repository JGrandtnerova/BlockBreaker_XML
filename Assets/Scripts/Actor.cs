using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public ActorData data = new ActorData();

    [SerializeField]
    string playername;

    [SerializeField]
    int level;

    [SerializeField]
    int score;

    public string Playername { get => playername; set => playername = value; }
    public int Level { get => level; set => level = value; }
    public int Score { get => score; set => score = value; }
}

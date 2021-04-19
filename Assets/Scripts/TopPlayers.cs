using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopPlayers : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player1;
    [SerializeField] TextMeshProUGUI player2;
    [SerializeField] TextMeshProUGUI player3;
    [SerializeField] TextMeshProUGUI player4;
    [SerializeField] TextMeshProUGUI player5;

    // Start is called before the first frame update
    void Start()
    {
        List<ActorData> players = SaveData.TopPlayers();
        player1.text = "1st place: " + players[4].name + ", Score: " + players[4].score;
        player2.text = "2nd place: " + players[3].name + ", Score: " + players[3].score;
        player3.text = "3rd place: " + players[2].name + ", Score: " + players[2].score;
        player4.text = "4th place: " + players[1].name + ", Score: " + players[1].score;
        player5.text = "5th place: " + players[0].name + ", Score: " + players[0].score;
    }

    
}

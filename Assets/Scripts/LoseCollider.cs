using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCollider : MonoBehaviour
{
    public Ball lopticka;
    public Paddle padlo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectables" || collision.tag == "ExtraBall")
        {
            Destroy(collision.gameObject);
        }
        else
        {
            if (GameStatus.zivot != 0)
            {
                GameStatus.zivot--;
                padlo.AddToHealth();
                lopticka.hasStarted = false; //kvoli metoode update v ball.cs
                lopticka.Update();

            }
            else { SceneManager.LoadScene("GameOver"); }
        }
    }
}

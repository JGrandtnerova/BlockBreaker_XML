using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1.25f;
    [SerializeField] float maxX = 15.52f;
    
    
    //zivot paddla
    [SerializeField] TextMeshProUGUI healthCount;
    
    //bonusy
    [SerializeField] private GameObject extraball;
    [SerializeField] private GameObject ball;
    bool bonusStarted = false;
    public float timeRemaining;
    public float BonusSize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        healthCount.text = GameStatus.zivot.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if ( bonusStarted )
        {
            timeRemaining -= Time.deltaTime;
            if(timeRemaining < 0)
            {
                transform.localScale -= new Vector3(BonusSize, 0, 0);
                bonusStarted = false;
                minX -= BonusSize * 1.2f;
                maxX += BonusSize * 1.2f;
            }
        
        }
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        

        transform.position = paddlePos;
    }

    public void AddToHealth()
    { 
        healthCount.text = GameStatus.zivot.ToString();
        Debug.Log("ubralo zivot");
    }

    private float GetXPos()
    {
        if (FindObjectOfType<GameStatus>().IsAutoPlayEnabled())
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectables")
        {

            float bonusValue = Random.Range(0f, 2f);//vloz co sa ma stat, takze random 1 a 2 moznost - bud zvacsi padlo alebo prida loptick
            Debug.Log(bonusValue);
            if (bonusValue >= 1f)
            {
                int numberNewBalls = Random.Range(2, 4);

                for (int i = 0; i < numberNewBalls; i++)
                {
                    GameObject newBall = Instantiate(extraball, transform.position, Quaternion.identity) as GameObject;
                    Vector2 ballPos = new Vector2(ball.transform.position.x, ball.transform.position.y);
                    newBall.transform.position = ballPos;
                }
            }
            else
            {
                if (!bonusStarted)
                {

                    bonusStarted = true;
                    timeRemaining = 10;

                    transform.localScale += new Vector3(BonusSize, 0, 0);
                    minX += BonusSize * 1.2f;
                    maxX -= BonusSize * 1.2f;
                }
            }
        }

        Destroy(collision.gameObject);
    }
}

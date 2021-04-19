using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //conf parametre
    [SerializeField] Paddle paddle1;
    [SerializeField] public float xPush = 2f;
    [SerializeField] public float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    [SerializeField] float randomFactor = 0.2f;

    //state
    Vector2 paddleToBallVector; //gap
    public bool hasStarted = false;

    //cached component
    AudioSource myAudioSource;
    public Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag != "ExtraBall")
        {
            paddleToBallVector = transform.position - paddle1.transform.position;
        }
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    public void Update()
    {
        if (gameObject.tag != "ExtraBall")
        {
            if (hasStarted != true)
            {
                LockBallToPaddle();
                LaunchOnMouseClick();
            }
        }
    }

    public void LaunchOnMouseClick()
    { 
        if (Input.GetMouseButtonDown(0))
        { 
           myRigidBody2D.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        } 
    }

    public void LockBallToPaddle()
    {
        
        Vector2 paddlePos = new Vector2(FindObjectOfType<Paddle>().transform.position.x, FindObjectOfType<Paddle>().transform.position.y);
        transform.position = paddlePos + paddleToBallVector; //nova pozicia ball
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag != "Collectables")
        {
            Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
            if (hasStarted)
            {
                AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
                myAudioSource.PlayOneShot(clip);
                myRigidBody2D.velocity += velocityTweak;
            }
        }
    }
}

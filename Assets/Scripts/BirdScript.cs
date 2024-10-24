using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    public AudioManagerScript audioManager;
    public bool birdIsAlive = true;
    public int flapStrength = 5;
    private const float upperBound = 5.35f;
    private const float lowerBound = -5.35f;

    void Awake()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Press space key to move the RigidBody upward
        if (Input.GetKeyDown("space") && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        // Check if bird exit the screen
        if (transform.position.y > upperBound || transform.position.y < lowerBound) {
            TriggerGameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        TriggerGameOver();
    }

    private void TriggerGameOver() 
    {
        if (birdIsAlive)
        {
            audioManager.PlaySFX(audioManager.death);
            logic.GameOver();
            birdIsAlive = false;
        }
    }
}

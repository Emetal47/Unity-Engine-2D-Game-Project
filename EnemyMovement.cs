// Author: Edgar Maldonado
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2.5f;      // The enemy speed.
    public bool vertical;
    public float changeTime = 3.0f;     // Enemy reverses direction after 3 seconds.

    Rigidbody2D rigidbody2d;
    float timer;
    int direction = 1;

    // Start is called before the first frame update.
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame.
    void Update()
    {
        timer -= Time.deltaTime;     // Timer decreases.

        if(timer < 0)        // Changes direction when timer reaches below 0.
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (vertical)                   // Enemy moves vertical.
        {
            position.y = position.y + Time.deltaTime * speed;
        }
        else
        {                                                       // Enemy will move horizontal. 
            position.x = position.x + Time.deltaTime * speed;
        }
        
        rigidbody2d.MovePosition(position);
    }

    // Function to check if enemy collides with user and deals damage to player.
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();    // Create an object of PlayerHealth.
        
        if(player != null)              // If the enemy collides with player.
        {
            player.ChangeHealth(-1);    // Reduces player health by 1.
        }
    }
}

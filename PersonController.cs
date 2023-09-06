// Author: Edgar Maldonado
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour       
{
    Rigidbody2D rigidbody2d;                    // This prevents the character from rotating when it collides with another object.
    float horizontal;
    float vertical;

    Animator animator;                      // To animate player movement.
    Vector2 direction = new Vector2(1, 0);

    // Start is called before the first frame update.
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();  // Retrieves the component. 
        animator = GetComponent<Animator>();
        //QualitySettings.vSyncCount = 0;           // This affects movement speed of player by framerate.
        //Application.targetFrameRate = 10;         // this is not used since different hardware will control character at different movement speed.
    }

    // Update is called once per frame.
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))    // Checks to see if move.x or move.y does not equal to 0.
        {
            direction.Set(move.x, move.y);      // Sets the look direction of player.
            direction.Normalize();
        }
        animator.SetFloat("Move X", direction.x);       // Player animation changes based on horizontal input.
        animator.SetFloat("Move Y", direction.y);       // Player animation changes based on vertical input.

        if (Input.GetKeyDown(KeyCode.X))        // Takes in keyboard input x.
        {
            RaycastHit2D trigger = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, direction, 1.5f, LayerMask.GetMask("NPC"));      // Casts a ray in Scene and checks if it intersects with a collider.

            if(trigger.collider != null)        // The player needs to be in proximity of the Non-playable character.
            {
                NPC character = trigger.collider.GetComponent<NPC>();

                if(character != null)
                {
                    character.DisplayText();                                // Displays the text that becomes visible in-game.
                }
                //Debug.Log("Raycast has hit the object " + trigger.collider.gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 2.5f * horizontal * Time.deltaTime;   // Takes in horizontal input from keyboard.
        position.y = position.y + 2.5f * vertical * Time.deltaTime;     // Takes in vertical input from keyboard.

        rigidbody2d.MovePosition(position);
    }
}

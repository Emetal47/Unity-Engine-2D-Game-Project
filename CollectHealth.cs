// Author: Edgar Maldonado
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHealth : MonoBehaviour
{
    // Function allows for player to collect health item.
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth controller = other.GetComponent<PlayerHealth>();   // Creates PlayerHealth object.

        if (controller != null)     // Checks if there is collision between two gameObjects.
        {
            if(controller.health < controller.maxHealth)    // Checks if current health of player does not exceed max health.
            {
                controller.ChangeHealth(1);     // Calls function in PlayerHealth class to add 1 health to player.
                Destroy(gameObject);            // Destroys the health item so that it can only be used once.
            }
            
        }

        //Debug.Log("Object that entered the trigger : " + other);
    }
}

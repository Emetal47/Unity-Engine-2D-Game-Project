// Author: Edgar Maldonado
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    // Function to deal damage to player.
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerHealth controller = other.GetComponent<PlayerHealth>();   // Create PlayerHealth object.

        if(controller != null)      // Checks if there is collision between gameObjects.
        {
            controller.ChangeHealth(-1);    // Reduces Player's health by 1.
        }
    }
}

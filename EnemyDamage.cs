// Author: Edgar Maldonado
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Function to provide Non-playable character to deal damage.
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerHealth controller = other.GetComponent<PlayerHealth>();   // Creates PlayerHealth object.

        if (controller != null)     // Checks if there is collision.
        {
            controller.ChangeHealth(-5);    // Calls function from PlayerHealth class to deal -5 health points to player.
        }
    }
}

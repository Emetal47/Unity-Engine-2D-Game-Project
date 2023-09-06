// Author: Edgar Maldonado
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftHealth : MonoBehaviour
{
    // Function that allows for Non-Playable character to provide health to player.
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerHealth controller = other.GetComponent<PlayerHealth>();   // Creates PlayerHealth object.

        if (controller != null)     // Checks if there is collision.
        {
            controller.ChangeHealth(5);     // Calls function from PlayerHealth class to provide player with 5 health.
        }
    }
}

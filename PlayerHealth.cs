// Author: Edgar Maldonado
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 20;      // The user's character will have a max health of 20.
    public float timeInvincible = 2.0f;     // 2 seconds of invincibility. 

    public int health { get { return currentHealth; }}
    int currentHealth;

    public bool isInvincible;
    public float invincibleTimer;

    // Start is called before the first frame update.
    void Start()
    {
        currentHealth = maxHealth;      // Starts the player off with 20 health.
    }

    // Update is called once per frame.
    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;  // Counts timer from 2 seconds to 0 seconds.
            if (invincibleTimer < 0)
                isInvincible = false;           // Player will no longer be invincible to damage when the timer falls from 2 seconds.
        }
    }

    // To update player health values.
    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            if (isInvincible)   // To check if player is invincible.
                return;         // Exits function.
            isInvincible = true;    // Enables invincibility.
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);      // Makes sure that health does not go over the set boundaries, 
        Debug.Log(currentHealth + "/" + maxHealth);                             // ex) 0 is lower bounds and 20 is higher bounds.
    }
}

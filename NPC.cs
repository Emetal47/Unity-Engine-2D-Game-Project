// Author: Edgar Maldonado
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float displayTime = 4.0f;    // Display message for 4 seconds.
    public GameObject dialogBox;        // Stores gameObject for the dialogBox.
    float timerDisplay;                 // Stores the length of displaytime.

    // Start is called before the first frame update.
    void Start()
    {
        dialogBox.SetActive(false);     // This is disabled.
        timerDisplay = -1.0f;
    }

    // Update is called once per frame.
    void Update()
    {
        if(timerDisplay >= 0)   // Dialog box is being displayed until time runs out.
        {
            timerDisplay -= Time.deltaTime;     // The time counting down.
            if(timerDisplay < 0)
            {
                dialogBox.SetActive(false);     // Removes dialog box. 
            }
        }
    }

    public void DisplayText()
    {
        timerDisplay = displayTime;     // Initializes to 4 seconds.
        dialogBox.SetActive(true);      // Makes dialog box visible.
    }
}

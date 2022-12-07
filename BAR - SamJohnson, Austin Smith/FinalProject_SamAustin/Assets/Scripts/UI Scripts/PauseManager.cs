using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update() { }

    public void setPause ( )
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            TextDisplay.SetDisplay("PAUSED");
            Time.timeScale = 0.0f;
        }
        else
        {
            TextDisplay.SetDisplay("");
            Time.timeScale = 1.0f;
        }
    }
}

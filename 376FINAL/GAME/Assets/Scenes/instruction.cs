using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instruction : MonoBehaviour
{
    public void quit()
    {
        SceneManager.LoadScene(0);
    }
    public void restore()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

}

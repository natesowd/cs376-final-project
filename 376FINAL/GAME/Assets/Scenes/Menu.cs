using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void startgame()
    {
        SceneManager.LoadScene(1);
    }
    public void checkinstruction()
    {
        SceneManager.LoadScene(2);
    }
}

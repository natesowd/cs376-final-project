using TMPro;
using UnityEngine;

/* Score manager
 * 
 * Manages the Score display
 */

[RequireComponent(typeof(TMP_Text))]
public class ScoreManager : MonoBehaviour
{
 
    public static ScoreManager Singleton;

    public int Score;

    private TMP_Text scoreDisplay;

    
    //Call to change the amount of points the player has. -Input to decrease, +Input to increase
    public static void ScorePoints(int points)
    {
        Singleton.ScorePointsInternal(points);
    }
    
    void Start()
    {
        Singleton = this;
        scoreDisplay = GetComponent<TMP_Text>();
        ScorePointsInternal(0);
    }

    //Internal call from static method
    private void ScorePointsInternal(int points)
    {
        
        if (points > 0)
        {
            GetComponent<AudioSource>().Play(0);
        }
        

        Score += points;

        scoreDisplay.text = "Score: " + Score.ToString();
    }
}
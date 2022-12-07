using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper scorekeeper;

    public TMP_Text scoreDisplay;

    public static int score = 0;

    public static void pointAdded(int delta)
    {
        scorekeeper.addPoints(delta);
    }

    // Start is called before the first frame update
    void Start()
    {
        scorekeeper = this;
        scoreDisplay = GetComponent<TMP_Text>();
        initialScore();
    }

    // Update is called once per frame
    void addPoints(int delta)
    {
        score += delta;
        scoreDisplay.text = "Score: " + score.ToString();
    }

    void initialScore()
    {
        score = 0;
        scoreDisplay.text = "Score: " + score.ToString();
    }
}

using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class LevelManager : MonoBehaviour
{

    public static LevelManager Singleton;

    public int currentLevel;

    public static int CurrentLevel;

    public GameObject player;

    private TMP_Text levelDisplay;


    //Call to change the amount of points the player has. -Input to decrease, +Input to increase
    public static void NextLevel()
    {
        Singleton.NextLevelInternal();
    }

    void Start()
    {
        Singleton = this;
        levelDisplay = GetComponent<TMP_Text>();
        NextLevelInternal();
    }

    //Internal call from static method
    private void NextLevelInternal()
    {
        currentLevel += 1;
        CurrentLevel = currentLevel;

        levelDisplay.text = "Level: " + currentLevel.ToString();

        HealthManager.ChangeHealth(100.0f);
        LaserManager.ChangeEnergy(100.0f);

        Transform playerPos = player.GetComponent<Transform>();
        playerPos.position = new Vector2(60.93291f, 0.0898459f);
    }
}
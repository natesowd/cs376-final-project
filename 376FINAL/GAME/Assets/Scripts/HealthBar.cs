using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
/// <summary>
/// Displays the score in whatever text component is store in the same game object as this
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class HealthBar : MonoBehaviour
{
    public static HealthBar singleton;
    /// <summary>
    /// Text component for displaying the score
    /// </summary>
    private TMP_Text scoreDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        scoreDisplay = GetComponent<TMP_Text>();
    }
    public static void showingHealth(int health)
    {
        singleton.healthShowingInternal(health);
    }
    private void healthShowingInternal(int health)
    {
        scoreDisplay.text = "health:   " + health.ToString();
    }
}
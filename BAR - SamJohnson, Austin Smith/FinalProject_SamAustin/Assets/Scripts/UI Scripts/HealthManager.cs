using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public static HealthManager Singleton;

    //Full length of the healthbar pre-changes, used for calculations
    public float fullLength;

    //RectTransform of healthbar
    private RectTransform rectTransform;

    //Static method to call for changing health, delta is a float representing a percentage of health lost, i.e. -50.0f is -50%
    //Delta is negative for losing health
    //Delta is positive for gaining health
    public static void ChangeHealth(float delta)
    {
        //turns delta into 0.[delta value]
        Singleton.ChangeHealthInternal(delta / 100.0f);
    }

    void Start()
    {
        Singleton = this;

        rectTransform = GetComponent<RectTransform>();

        fullLength = rectTransform.sizeDelta[1];

        ChangeHealthInternal(0.0f / 100.0f);
    }

    void Update()
    {
        
        if (rectTransform.sizeDelta[1] == 0.0f)
        {
            Time.timeScale = 0.0f;
            TextDisplay.SetDisplay("You lost");
        }
     
    }
    //Internal call from a static method
    private void ChangeHealthInternal(float delta)
    {
        //New calculated barlength, determined from multiplying delta and the fullLength of the healthbar
        float barLength = ((rectTransform.sizeDelta[1] / fullLength) + delta) * fullLength;

        //if that length is negative, health is 0, if it's over the fullLength, you have too much health so you max out
        if (barLength > fullLength)
        {
            barLength = fullLength;
        }
        else if (barLength < 0.0f)
        {
            barLength = 0.0f;
        }
         
        if (delta < 0.0f)
        {
            GetComponent<AudioSource>().Play(0);
        }

        //Update the healthbar length
        rectTransform.sizeDelta = new Vector2( rectTransform.sizeDelta[0], barLength);
    }
}
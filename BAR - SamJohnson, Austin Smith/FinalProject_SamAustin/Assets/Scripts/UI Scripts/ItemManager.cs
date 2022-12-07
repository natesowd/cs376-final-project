using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Singleton;

    public TMP_Text heartCounter;
    public static int HeartCount;
    public int heartCount;

    public TMP_Text coinCounter;
    public static int CoinCount;
    public int coinCount;

    public TMP_Text missileCounter;
    public static int MissileCount;
    public int missileCount;


    public static void AlterItems(string item, int delta)
    {
        Singleton.AlterItemsInternal(item, delta);
    }

    void Start ()
    {
        Singleton = this;

        int.TryParse(heartCounter.text, out heartCount);

        int.TryParse(coinCounter.text, out coinCount);

        int.TryParse(missileCounter.text, out missileCount);

        HeartCount = heartCount;
        CoinCount = coinCount;
        MissileCount = missileCount;

        AlterItemsInternal("", 0);
    }

    void Update ()
    {
        int.TryParse(heartCounter.text, out heartCount);

        int.TryParse(coinCounter.text, out coinCount);

        int.TryParse(missileCounter.text, out missileCount);

        HeartCount = heartCount;
        CoinCount = coinCount;
        MissileCount = missileCount;
    }

    private void AlterItemsInternal(string item, int delta)
    {
        if (item == "coin")
        {
            if (((delta < 0) && (coinCount != 0) ) || ((delta > 0) && (coinCount != 999)))
            {
                coinCount += delta;
                coinCounter.text = coinCount.ToString();
            }
        }
        
        if (item == "missile")
        {
            if (((delta < 0) && (missileCount != 0)) || ((delta > 0) && (missileCount != 9)))
            {
                missileCount += delta;

                if (delta < 0)
                {
                    GetComponent<AudioSource>().Play(0);
                }

                missileCounter.text = missileCount.ToString();
            }


        }

        if (item == "heart")
        {
            if (((delta < 0) && (heartCount != 0)) || ((delta > 0) && (heartCount != 9)))
            {
                heartCount += delta;
                heartCounter.text = heartCount.ToString();
            }
        }

    }
}

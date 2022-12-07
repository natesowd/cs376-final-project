using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public Image menu; 
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = menu.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() { }


    public void buyHeart()
    {
        if (ItemManager.CoinCount >= 10)
        {
            ItemManager.AlterItems("heart", 1);
            ItemManager.AlterItems("coin", -10);
        }
    }

    public void buyRocket()
    {
        if (ItemManager.CoinCount >= 20)
        {
            ItemManager.AlterItems("missile", 1);
            ItemManager.AlterItems("coin", -20);
        }
    }

    public void exitMenu()
    {
        rectTransform.anchoredPosition = new Vector2(10000.0f, 0.0f);
    }
}

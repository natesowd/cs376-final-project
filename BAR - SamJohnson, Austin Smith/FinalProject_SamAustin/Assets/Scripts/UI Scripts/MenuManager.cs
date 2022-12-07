using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Image storeMenu;
    public Image menu;
    private RectTransform rectTransform;
    private RectTransform storeRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = menu.GetComponent<RectTransform>();
        storeRectTransform = storeMenu.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() { }


    public void callLevelManager()
    {
        rectTransform.anchoredPosition = new Vector2(10000.0f, 0.0f);
        Time.timeScale = 1.0f;

        if (LevelManager.CurrentLevel != 1)
        {
            LevelManager.NextLevel();
        }
    }

    
    public void openStore()
    {
        storeRectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
    }

}

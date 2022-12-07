using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextDisplay : MonoBehaviour
{
    public static TextDisplay Singleton;

    private TMP_Text display;

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;
        display = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() { }


    public static void SetDisplay(string text)
    {
        Singleton.SetDisplayInternal(text);
    }

    //Internal call from static method
    private void SetDisplayInternal(string text)
    {
        if (text == null)
        {
            text = "";
        }

        display.text = text;
    }



}

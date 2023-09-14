using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMenuScript : MonoBehaviour
{
    public TouchScreenKeyboard keyboard;
    public GameObject calculationObject;
    CalculateScore scoreCalculator;
    string kbText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(keyboard != null)
        {
            kbText = keyboard.text;
            scoreCalculator.nameToUse = kbText;
        }
    }

    void OnEnable()
    {
        OpenSystemKeyboard();
        scoreCalculator = calculationObject.GetComponent<CalculateScore>();
    }

    public void OpenSystemKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);

    }
}

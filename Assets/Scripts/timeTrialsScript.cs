using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeTrialsScript : MonoBehaviour
{

    public float timerTime;
    public bool timerControl;
    public TextMeshPro timerText;
    public GameObject startImage;
    public GameObject collectButton;
    public GameObject probeQuad;
    public GameObject phantomQuad;
    public GameObject probeModel;
    public GameObject phantomModel;

    Texture2D image1;
    Texture2D image2;

    // Start is called before the first frame update
    void Start()
    {
        string filename1 = "C:/d/UnityProjects/MARSS_Unity/Assets/Resources/StartTrial.png";
        string filename2 = "C:/d/UnityProjects/MARSS_Unity/Assets/Resources/groundTruthImage1.png";
        var rawData1 = System.IO.File.ReadAllBytes(filename1);
        var rawData2 = System.IO.File.ReadAllBytes(filename2);
        image1 = new Texture2D(640, 480);
        image2 = new Texture2D(640, 480);
        image1.LoadImage(rawData1);
        image2.LoadImage(rawData2);


        // Set Initial Reference Image
        startImage.GetComponent<RawImage>().texture = image1;

        timerTime = 0.0f;
        timerControl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerControl)
        {
            timerTime += Time.deltaTime;
            UpdateTimer();
        }
    }

    public void StartTimer()
    {
        timerControl = true;

        // Set 1st ground truth image
        startImage.GetComponent<RawImage>().texture = image2;
        collectButton.SetActive(true);
        phantomModel.SetActive(false);
        probeModel.SetActive(false);
        probeQuad.SetActive(true);
        phantomQuad.SetActive(true);
    }

    public void EndTimer()
    {
        timerControl= false;
    }

    public void ResetTimer()
    {
        timerTime = 0.0f;
        timerText.text = timerTime.ToString("F2").Replace(".", ":");
    }

    void UpdateTimer()
    {
        if(timerTime < 60)
        {
            string workWithMe = timerTime.ToString("F2");
            timerText.text = workWithMe.Replace(".", ":");
        }
        else
        {
            int minutes = (int) timerTime / 60;
            int seconds = (int) timerTime % 60;
            string secString;
            if(seconds < 10) { secString = "0" + seconds; }
            else { secString = seconds.ToString(); }
            string workingString = minutes.ToString() + ":" + secString;
            timerText.text = workingString;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Called by the UI to update users score for each level
// and calculate final score after all levels completed
public class CalculateScore : MonoBehaviour
{
    float level1TranslationError;
    float level2TranslationError;
    float level3TranslationError;

    public float totalTime;
    float finalScore;
    int level;
    bool highScoreEnabled;

    public GameObject referenceImage;

    public GameObject probeTarget;
    public GameObject phantomTarget;

    public GameObject level1GTPose;
    public GameObject level2GTPose;
    public GameObject level3GTPose;

    Texture2D image1;
    Texture2D image2;
    Texture2D image3;
    Texture2D image4;
    Texture2D image5;

    public string nameToUse;
    // Start is called before the first frame update
    void Start()
    {
        // Start with level 1
        level = 1;
        highScoreEnabled = false;

        // Load Images: NOTE THAT THESE FILE PATHS ARE ABSOLUTE AND THEREFORE MAY NOT WORK ON ALL BUILDS
        string filename1 = "C:/d/UnityProjects/MARSS_Unity/Assets/Resources/groundTruthImage1.png";
        string filename2 = "C:/d/UnityProjects/MARSS_Unity/Assets/Resources/groundTruthImage2.png";
        string filename3 = "C:/d/UnityProjects/MARSS_Unity/Assets/Resources/groundTruthImage3.png";
        string filename4 = "C:/d/UnityProjects/MARSS_Unity/Assets/Resources/Congratulations.png";
        string filename5 = "C:/d/UnityProjects/MARSS_Unity/Assets/Resources/StartTrial.png";
        var rawData1 = System.IO.File.ReadAllBytes(filename1);
        var rawData2 = System.IO.File.ReadAllBytes(filename2);
        var rawData3 = System.IO.File.ReadAllBytes(filename3);
        var rawData4 = System.IO.File.ReadAllBytes(filename4);
        var rawData5 = System.IO.File.ReadAllBytes(filename5);
        image1 = new Texture2D(640, 480);
        image2 = new Texture2D(640, 480);
        image3 = new Texture2D(640, 480);
        image4 = new Texture2D(640, 480);
        image5 = new Texture2D(640, 480);
        image1.LoadImage(rawData1);
        image2.LoadImage(rawData2);
        image3.LoadImage(rawData3);
        image4.LoadImage(rawData4);
        image4.LoadImage(rawData5);

        // Set Initial Reference Image
        //referenceImage.GetComponent<RawImage>().texture = image1;
    }

    public void UpdateScore()
    {
        Matrix4x4 probeToPhantom = phantomTarget.transform.localToWorldMatrix.inverse * probeTarget.transform.localToWorldMatrix;

        switch (level)
        {
            case 1:
                {
                    level1TranslationError = CalculateTranslationError(level1GTPose.transform.position, probeToPhantom.GetPosition());
                    referenceImage.GetComponent<RawImage>().texture = image2;
                    Debug.Log("Upload image 2");
                    level++;
                    break;
                }
            case 2:
                {
                    level2TranslationError = CalculateTranslationError(level2GTPose.transform.position, probeToPhantom.GetPosition());
                    referenceImage.GetComponent<RawImage>().texture = image3;
                    Debug.Log("Upload image 3");
                    level++;
                    break;
                }
            case 3:
                {
                    level3TranslationError = CalculateTranslationError(level3GTPose.transform.position, probeToPhantom.GetPosition());
                    level = 1;
                    referenceImage.GetComponent<RawImage>().texture = image4;
                    Debug.Log("Upload image 4");
                    CalculateFinalScore();
                    if (highScoreEnabled)
                    {
                        WriteToHighScoreFile();
                    }

                    break;
                }
        }
    }

    float CalculateTranslationError(Vector3 gtPosition, Vector3 probePosition)
    {
        return Mathf.Sqrt(Mathf.Pow(gtPosition.x - probePosition.x, 2)
            + Mathf.Pow(gtPosition.y - probePosition.y, 2)
            + Mathf.Pow(gtPosition.z - gtPosition.z, 2));
    }

    public void CalculateFinalScore()
    {
        // calculate final score based on level 1,2 and 3 score
        finalScore = (1 / (level1TranslationError + level2TranslationError + level3TranslationError + totalTime)) * 100;
    }

    void WriteToHighScoreFile()
    {
        ScoreInstance scoreStorage = new ScoreInstance { name = nameToUse, totalScore = finalScore, lvl1TE = level1TranslationError, lvl2TE = level2TranslationError, lvl3TE = level3TranslationError, time = totalTime };
        XMLManager.instance.leaderboard.list.Add(scoreStorage);
        XMLManager.instance.leaderboard.list.Sort((ScoreInstance x, ScoreInstance y) => y.totalScore.CompareTo(x.totalScore));
    }


}

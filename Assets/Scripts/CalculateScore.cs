using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject probeTarget;
    public GameObject phantomTarget;

    public GameObject level1GTPose;
    public GameObject level2GTPose;
    public GameObject level3GTPose;

    

    // Start is called before the first frame update
    void Start()
    {
        // Start with level 1
        level = 1;    
    }

    public void UpdateScore()
    {
        Matrix4x4 probeToPhantom = phantomTarget.transform.localToWorldMatrix.inverse * probeTarget.transform.localToWorldMatrix;

        switch (level)
        {
            case 1:
            {
                level1TranslationError = CalculateTranslationError(level1GTPose.transform.position, probeToPhantom.GetPosition());
                level++;
                break;
            }
            case 2:
            {
                level2TranslationError = CalculateTranslationError(level2GTPose.transform.position, probeToPhantom.GetPosition());
                level++;
                break;
            }
            case 3:
            {
                level3TranslationError = CalculateTranslationError(level3GTPose.transform.position, probeToPhantom.GetPosition());
                level = 1;
                CalculateFinalScore();
                WriteToHighScoreFile();
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
        finalScore = (1/(level1TranslationError + level2TranslationError + level3TranslationError + totalTime))*100;
    }

    void WriteToHighScoreFile()
    {
        
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectGroundTruth : MonoBehaviour
{
    // Dynamic Poses from Vuforia
    public GameObject probeTarget;
    public GameObject phantomTarget;

    // Quad where clarius image is streamed to
    public GameObject rawImage;

    // Ground Truth Poses
    public GameObject groundTruthPose1;
    public GameObject groundTruthPose2;
    public GameObject groundTruthPose3;

    // Ground Truth Images
    Texture2D image1;
    Texture2D image2;
    Texture2D image3;

    int levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        levelNumber = 1;
        image1 = new Texture2D(640, 480);
        image2 = new Texture2D(640, 480);
        image3 = new Texture2D(640, 480);
    }


    public void CollectGroundTruthData()
    {
        Matrix4x4 probeToPhantom;
        probeToPhantom = phantomTarget.transform.localToWorldMatrix.inverse * probeTarget.transform.localToWorldMatrix;
        switch (levelNumber)
        {
            case 1:
            {
                groundTruthPose1.transform.localRotation= probeToPhantom.rotation;
                groundTruthPose1.transform.localPosition = probeToPhantom.GetPosition();
                image1 = (Texture2D)rawImage.GetComponent<RawImage>().texture;
                levelNumber++;
                Debug.Log("Pose 1 Saved");
                break;
            }
            case 2:
            {
                groundTruthPose2.transform.localRotation = probeToPhantom.rotation;
                groundTruthPose2.transform.localPosition = probeToPhantom.GetPosition();
                image2 = (Texture2D)rawImage.GetComponent<RawImage>().texture;
                levelNumber++;
                Debug.Log("Pose 2 Saved");
                break;
            }
            case 3:
            {
                groundTruthPose3.transform.localRotation = probeToPhantom.rotation;
                groundTruthPose3.transform.localPosition = probeToPhantom.GetPosition();
                image3 = (Texture2D)rawImage.GetComponent<RawImage>().texture;
                // In case we want to redo all three poses
                levelNumber = 0;
                Debug.Log("Pose 3 Saved");
                WriteGroundTruthImagesToFile();
                break;
            }
        }
    }

    // Write our textures to PNG's 
    void WriteGroundTruthImagesToFile()
    {
        string filePath1 = "C:/d/UnityProjects/MARSS_unity/Assets/Resources/groundTruthImage1.png";
        string filePath2 = "C:/d/UnityProjects/MARSS_unity/Assets/Resources/groundTruthImage2.png";
        string filePath3 = "C:/d/UnityProjects/MARSS_unity/Assets/Resources/groundTruthImage3.png";

        byte[] image1Raw = image1.EncodeToPNG();
        byte[] image2Raw = image2.EncodeToPNG();
        byte[] image3Raw = image3.EncodeToPNG();

        System.IO.File.WriteAllBytes(filePath1, image1Raw);
        System.IO.File.WriteAllBytes(filePath2, image2Raw);
        System.IO.File.WriteAllBytes(filePath3, image3Raw);
    }
}

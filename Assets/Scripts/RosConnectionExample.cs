using RosMessageTypes.Sensor;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;
using UnityEngine.UI;

public class RosConnectionExample : MonoBehaviour
{

    // WebCamTexture tex;
    ROSConnection rosNode;


    public RawImage display;
    Texture2D texRos;
    string imageTopic = "US_images";

    void Start()
    {
        // start the ROS connection
        rosNode = ROSConnection.GetOrCreateInstance();

        // subscribe ultrasound images from Clara AGX
        rosNode.Subscribe<ImageMsg>(imageTopic, displayImage);



        rosNode.Subscribe<RosMessageTypes.Std.Float32MultiArrayMsg>("Pelvis", CallbackPelvis);
        rosNode.Subscribe<RosMessageTypes.Std.Float32MultiArrayMsg>("HoloLens", CallbackHoloLens);
        rosNode.Subscribe<RosMessageTypes.Std.Float32MultiArrayMsg>("Clarius", CallbackClarius);


    }


    void CallbackHoloLens(RosMessageTypes.Std.Float32MultiArrayMsg msg)
    {
        TransformationManager.HololensMarkerToSpryTrack = arrayToMatrix(msg.data);
    }

    void CallbackClarius(RosMessageTypes.Std.Float32MultiArrayMsg msg)
    {
        TransformationManager.ClariusToSpryTrack = arrayToMatrix(msg.data);
    }


    void CallbackPelvis(RosMessageTypes.Std.Float32MultiArrayMsg msg)
    {
        TransformationManager.PelvisToSpryTrack = arrayToMatrix(msg.data);
        //Console.WriteLine($"PelvisToSpryTrack:\n{TransformationManager.PelvisToSpryTrack}\n ");
        //Debug.Log($"PelvisToSpryTrack:\n{TransformationManager.PelvisToSpryTrack}\n ");

    }

    private Matrix4x4 arrayToMatrix(float[] data)
    {
        Matrix4x4 matrix = new Matrix4x4();
        matrix[0, 0] = data[0]; matrix[0, 1] = data[1]; matrix[0, 2] = data[2]; matrix[0, 3] = data[3];
        matrix[1, 0] = data[4]; matrix[1, 1] = data[5]; matrix[1, 2] = data[6]; matrix[1, 3] = data[7];
        matrix[2, 0] = data[8]; matrix[2, 1] = data[9]; matrix[2, 2] = data[10]; matrix[2, 3] = data[11];
        matrix[3, 0] = data[12]; matrix[3, 1] = data[13]; matrix[3, 2] = data[14]; matrix[3, 3] = data[15];
        return matrix;
    }


    // The image message from ROS has different format as Unity, need some processing before displaying it.
    public void displayImage(ImageMsg img)
    {

        texRos = new Texture2D((int)img.width, (int)img.height, TextureFormat.RGB24, false); // , TextureFormat.RGB24
        BgrToRgb(img.data);
        texRos.LoadRawTextureData(img.data);

        texRos.Apply();
        display.texture = texRos;
    }


    // Python, Unity have different image conventions, just use this code
    public void BgrToRgb(byte[] data)
    {
        for (int i = 0; i < data.Length; i += 3)
        {
            byte dummy = data[i];
            data[i] = data[i + 2];
            data[i + 2] = dummy;
        }
    }

}

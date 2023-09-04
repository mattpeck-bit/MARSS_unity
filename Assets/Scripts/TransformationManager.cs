using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationManager : MonoBehaviour
{



    public static Matrix4x4 flipYZ = new Matrix4x4(
        new Vector4(1.0f, 0.0f, 0.0f, 0.0f),
        new Vector4(0.0f, -1.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 0.0f, -1.0f, 0.0f),
        new Vector4(0.0f, 0.0f, 0.0f, 1.0f));

    public static Matrix4x4 flipXZ = new Matrix4x4(
        new Vector4(-1.0f, 0.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 1.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 0.0f, -1.0f, 0.0f),
        new Vector4(0.0f, 0.0f, 0.0f, 1.0f));

    public static Matrix4x4 flipZ = new Matrix4x4(
        new Vector4(1.0f, 0.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 1.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 0.0f, -1.0f, 0.0f),
        new Vector4(0.0f, 0.0f, 0.0f, 1.0f));

    public static Matrix4x4 flipY = new Matrix4x4(
        new Vector4(1.0f, 0.0f, 0.0f, 0.0f),
        new Vector4(0.0f, -1.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 0.0f, 1.0f, 0.0f),
        new Vector4(0.0f, 0.0f, 0.0f, 1.0f));

    public static Matrix4x4 flipXY = new Matrix4x4(
        new Vector4(-1.0f, 0.0f, 0.0f, 0.0f),
        new Vector4(0.0f, -1.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 0.0f, 1.0f, 0.0f),
        new Vector4(0.0f, 0.0f, 0.0f, 1.0f));

    public static Matrix4x4 flipXYZ = new Matrix4x4(
        new Vector4(-1.0f, 0.0f, 0.0f, 0.0f),
        new Vector4(0.0f, -1.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 0.0f, -1.0f, 0.0f),
        new Vector4(0f, 0.0f, 0.0f, 1.0f));

    public static Matrix4x4 flipX = new Matrix4x4(
        new Vector4(-1.0f, 0.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 1.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 0.0f, 1.0f, 0.0f),
        new Vector4(0.0f, 0.0f, 0.0f, 1.0f));

    public static Matrix4x4 idendity = new Matrix4x4(
        new Vector4(1.0f, 0.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 1.0f, 0.0f, 0.0f),
        new Vector4(0.0f, 0.0f, 1.0f, 0.0f),
        new Vector4(0.0f, 0.0f, 0.0f, 1.0f));

    public static Matrix4x4 femurToHololens;



    public static Matrix4x4 pvToWorld;
    public static Matrix4x4 SampleToSpryTrack;
    public static Matrix4x4 HololensMarkerToSpryTrack;
    public static Matrix4x4 HololensMarkerToSpryTrackForCalibration;
    public static Matrix4x4 FemurToSpryTrack;
    public static Matrix4x4 PelvisToSpryTrack;
    public static Matrix4x4 SawToSpryTrack;
    public static Matrix4x4 ArthrexToSpryTrack;
    public static Matrix4x4 ClariusToSpryTrack;
    public static Matrix4x4 spryTrackToWorld = Matrix4x4.zero;
    public static bool spryTrackCalibrated = false;


    private static float t_x = -77.70158f;
    private static float t_y = -54.32996f;
    private static float t_z = 13.777130f;
    private static float euler_x = -12.12972f;
    private static float euler_y = 101.0975f;
    private static float euler_z = 17.565290f;


    public static Vector3 HololensToPV_t = new Vector3(t_x, t_y, t_z);
    public static Vector3 HololensToPV_eulerAngle = new Vector3(euler_x, euler_y, euler_z);

    public static Matrix4x4 HololensMarkerToPV = ComputeTransformationMatrix(HololensToPV_t, HololensToPV_eulerAngle);




    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ComputeSpryTrackToWorld();
        if (spryTrackCalibrated)
        {
            //UpdateFemur();
            UpdatePelvis();
            UpdateClarius();
            //UpdateSaw();
            //UpdateArthrex();
        }
        //Debug.Log($"Current slider values: t_x: {t_x_slider},t_y: {t_y_slider},t_z: {t_z_slider}\n" +
        //    $"euler_x: {euler_x_slider},euler_y: {euler_y_slider},t_z: {euler_z_slider}\n ");
        string t_str = HololensToPV_t.ToString("F10");
        string r_str = HololensToPV_eulerAngle.ToString("F10");

        Debug.Log($"HololensMarkerToPV, current t: {t_str}, current rotation: {r_str}");

    }
        
    public static void ComputeSpryTrackToWorld()
    {
        if (HololensMarkerToSpryTrackForCalibration[3, 3] == 1 && pvToWorld[3, 3] == 1)
        {

            Debug.Log("Computing sprytrack to world");
            spryTrackToWorld =
                pvToWorld * flipYZ * HololensMarkerToPV * HololensMarkerToSpryTrackForCalibration.inverse;
            spryTrackCalibrated = true;

        }
    }

    public static Matrix4x4 ComputeTransformationMatrix(Vector3 t, Vector3 euler)
    {
        //
        Debug.Log($"Received euler.x= {euler.x}, euler.y= {euler.y}, euler.z={euler.z}\n ");
        Vector3 s = new Vector3(1, 1, 1);
        Quaternion q = Quaternion.Euler(euler);

        Debug.Log($"converted quaternion: {q}\n ");
        Debug.Log($"converted quaternion to angles: {q.eulerAngles}\n ");
        return Matrix4x4.TRS(t, q, s);
    }

    void UpdateSaw()
    {

        Transform target = GameObject.Find("Saw").transform;
        if (target == null)
        {
            Debug.LogWarning($"target {"HoloLens"} not found");
            return;
        }

        Matrix4x4 totalTransform = spryTrackToWorld * SawToSpryTrack * flipX;
        //Debug.Log($"HololensMarkerToSpryTrack: \n {TransformationManager.HololensMarkerToSpryTrack}");
        //Debug.Log($"pvToWorld: \n {TransformationManager.pvToWorld}");
        //Debug.Log($"FemurToSpryTrack: \n {TransformationManager.FemurToSpryTrack}");
        //Debug.Log("---------------------------------------------------------------------------------------------------------");

        Vector3 position = totalTransform.GetColumn(3) / 1000f;
        Quaternion rotation = Quaternion.LookRotation(totalTransform.GetColumn(2), totalTransform.GetColumn(1));
        target.position = position;
        target.rotation = rotation;


        Debug.Log($"position of femur: {position.ToString("f6")}, rotation : {rotation.ToString("f6")}\n");

    }

    void UpdateArthrex()
    {

        Transform target = GameObject.Find("Arthrex").transform;
        if (target == null)
        {
            Debug.LogWarning($"target {"Arthrex"} not found");
            return;
        }

        Matrix4x4 totalTransform = spryTrackToWorld * ArthrexToSpryTrack * flipX;
        //Debug.Log($"HololensMarkerToSpryTrack: \n {TransformationManager.HololensMarkerToSpryTrack}");
        //Debug.Log($"pvToWorld: \n {TransformationManager.pvToWorld}");
        //Debug.Log($"FemurToSpryTrack: \n {TransformationManager.FemurToSpryTrack}");
        //Debug.Log("---------------------------------------------------------------------------------------------------------");

        Vector3 position = totalTransform.GetColumn(3) / 1000f;
        Quaternion rotation = Quaternion.LookRotation(totalTransform.GetColumn(2), totalTransform.GetColumn(1));
        target.position = position;
        target.rotation = rotation;

        Debug.Log($"position of femur: {position.ToString("f6")}, rotation : {rotation.ToString("f6")}\n");

    }


    void UpdatePelvis()
    {
        //TransformationManager.FemurToSpryTrack = TransformationManager.idendity;
        Transform target = GameObject.Find("Pelvis").transform;
        if (target == null)
        {
            Debug.LogWarning($"target {"Pelvis"} not found");
            return;
        }

        Matrix4x4 totalTransform = spryTrackToWorld * PelvisToSpryTrack * flipX;
        //Debug.Log($"HololensMarkerToSpryTrack: \n {TransformationManager.HololensMarkerToSpryTrack}");
        //Debug.Log($"pvToWorld: \n {TransformationManager.pvToWorld}");
        //Debug.Log($"FemurToSpryTrack: \n {TransformationManager.FemurToSpryTrack}");
        //Debug.Log("---------------------------------------------------------------------------------------------------------");

        Vector3 position = totalTransform.GetColumn(3) / 1000f;
        Quaternion rotation = Quaternion.LookRotation(totalTransform.GetColumn(2), totalTransform.GetColumn(1));
        target.position = position;
        target.rotation = rotation;

        Debug.Log($"position of Pelvis: {position.ToString("f6")}, rotation : {rotation.ToString("f6")}\n");



    }

    void UpdateClarius()
    {
        //TransformationManager.FemurToSpryTrack = TransformationManager.idendity;
        Transform target = GameObject.Find("Clarius").transform;
        if (target == null)
        {
            Debug.LogWarning($"target {"Clarius"} not found");
            return;
        }

        Matrix4x4 totalTransform = spryTrackToWorld * ClariusToSpryTrack * flipX;
        //Debug.Log($"HololensMarkerToSpryTrack: \n {TransformationManager.HololensMarkerToSpryTrack}");
        //Debug.Log($"pvToWorld: \n {TransformationManager.pvToWorld}");
        //Debug.Log($"FemurToSpryTrack: \n {TransformationManager.FemurToSpryTrack}");
        //Debug.Log("---------------------------------------------------------------------------------------------------------");

        Vector3 position = totalTransform.GetColumn(3) / 1000f;
        Quaternion rotation = Quaternion.LookRotation(totalTransform.GetColumn(2), totalTransform.GetColumn(1));
        target.position = position;
        target.rotation = rotation;

        Debug.Log($"position of Pelvis: {position.ToString("f6")}, rotation : {rotation.ToString("f6")}\n");



    }


    void UpdateFemur()
    {

        Transform target = GameObject.Find("Femur").transform;
        if (target == null)
        {
            Debug.LogWarning($"target {"HoloLens"} not found");
            return;
        }

        Matrix4x4 totalTransform = spryTrackToWorld * FemurToSpryTrack * flipX;
        //Debug.Log($"HololensMarkerToSpryTrack: \n {TransformationManager.HololensMarkerToSpryTrack}");
        //Debug.Log($"pvToWorld: \n {TransformationManager.pvToWorld}");
        //Debug.Log($"FemurToSpryTrack: \n {TransformationManager.FemurToSpryTrack}");
        //Debug.Log("---------------------------------------------------------------------------------------------------------");

        Vector3 position = totalTransform.GetColumn(3) / 1000f;
        Quaternion rotation = Quaternion.LookRotation(totalTransform.GetColumn(2), totalTransform.GetColumn(1));
        target.position = position;
        target.rotation = rotation;


        Debug.Log($"position of femur: {position.ToString("f6")}, rotation : {rotation.ToString("f6")}\n");



    }


}

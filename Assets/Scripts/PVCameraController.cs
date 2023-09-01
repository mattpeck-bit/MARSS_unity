using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows.WebCam;
using UnityEngine.XR.ARSubsystems;

public class PVCameraController : MonoBehaviour
{
    private Matrix4x4 pvToWorld;



    #region Private members
    private PhotoCapture _captureObject = null;
    private bool isCapturing = false;
    private int frame_count = 0;
    // hololens2 support 3904x2196, 1952x1100, 1952x1100, 1920x1080, 1280x720 in photo mode
    private int photo_width = 1920;
    private int photo_height = 1080;
    private Texture2D targetTexture;
    private bool calibration_mode = false;

    #endregion




//#if ENABLE_WINMD_SUPPORT
//    private OpenCVRuntimeComponent.CvUtils _cvUtils;

//#endif

    void Start()
    {


#if ENABLE_WINMD_SUPPORT
        StartCoroutine(StartCameraCapture());
#endif

    }



    void Update()
    {
        if (isCapturing && TransformationManager.spryTrackCalibrated==false)
        {
            _captureObject.TakePhotoAsync(OnCapturedPhotoToMemory);

        }
        if(TransformationManager.spryTrackCalibrated==true)
        {
            Debug.Log($"Ready!!!!!!!!!!!!!!!!!!!!!!!!!");
        }

    }


    private IEnumerator StartCameraCapture()
    {
        yield return new WaitForSeconds(1);
        if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        }
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.Log("Creating PhotoCapture");
            PhotoCapture.CreateAsync(false, OnPhotoCaptureCreated);
        }
        else
        {
            Debug.Log("Webcam Permission not granted");
        }
    }

    private void OnPhotoCaptureCreated(PhotoCapture captureObject)
    {
        Debug.Log("OnPhotoCaptureCreated");

        _captureObject = captureObject;



        CameraParameters c = new CameraParameters();
        c.hologramOpacity = 0.0f;
        c.cameraResolutionWidth = photo_width;
        c.cameraResolutionHeight = photo_height;
        c.pixelFormat = CapturePixelFormat.BGRA32;

        captureObject.StartPhotoModeAsync(c, OnPhotoModeStarted);
    }

    private void OnPhotoModeStarted(PhotoCapture.PhotoCaptureResult result)
    {

        //Debug.Log("OnPhotoModeStarted");

        if (result.success)
        {
            isCapturing = true;
            Debug.Log("photo mode Started");
            _captureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
        }
        else
        {
            Debug.Log("Unable to start photo mode!");
            Debug.LogError("Unable to start photo mode!");
        }
    }

    void OnPhotoModeStopped(PhotoCapture.PhotoCaptureResult result)
    {
        Debug.Log("OnPhotoModeStopped");

        _captureObject.Dispose();
        _captureObject = null;
    }



    void OnCapturedPhotoToMemory(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    {

        TransformationManager.HololensMarkerToSpryTrackForCalibration = TransformationManager.HololensMarkerToSpryTrack;
        Debug.Log($"OnCapturedPhotoToMemory (success: {result.success})");

#if ENABLE_WINMD_SUPPORT
        if (result.success)
        {
            Debug.Log("photo to memory success");
            if (photoCaptureFrame.hasLocationData)
            {


                photoCaptureFrame.TryGetCameraToWorldMatrix(out Matrix4x4 pvToWorldBuff);

                TransformationManager.pvToWorld = pvToWorldBuff;
            }
            Debug.Log($"pv to world matrix:\n {TransformationManager.pvToWorld}");
        }

        if (TransformationManager.spryTrackCalibrated == true)
        {
            _captureObject.StopPhotoModeAsync(OnPhotoModeStopped);
        }
#endif

    }


}

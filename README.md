
# Speech Recognition and Image Streaming Example

Welcome to the Speech Recognition and Image Streaming example application. This repository contains a demonstration of how to integrate speech recognition and image streaming using two fundamental components: a Unity client and a Python server. These components communicate through ROS2, utilizing the [Unity-Technologies/ROS-TCP-Connector](https://github.com/Unity-Technologies/ROS-TCP-Connector), a TCP-based communication framework. In this configuration, the Python server operates on Clara AGX, streaming images to HoloLens2 and transcribing speech from HoloLens2 to text. The transcribed text can then be analyzed using Chat-GPT. The Unity client, running on HoloLens2, can visualize images from Clara AGX and record and transmit user speech to Clara AGX.

## Branch

If you are going to use optical tracking camera (spryTrack), please switch to the branch `feature/spryTrack`.

## Requirements

This application will run on HoloLens2. If you have no experience about building and deploying Unity project to HoloLens2, you can follow this tutorial [HoloLens 2 fundamentals: develop mixed reality applications - Training | Microsoft Learn](https://learn.microsoft.com/en-us/training/paths/beginner-hololens-2-tutorials/)

## Usage

To get started with this example application, follow these steps:

1.  **Ensure Python server is Running**
    
    -   Make sure the Python server script is running correctly. [organizers / ClaraAndSpryTrack_example_python · GitLab (tum.de)](https://gitlab.marss23.campar.in.tum.de/organizers/MARSS_python_AGX)
2.  **Network Configuration**
    
    -   Ensure that both your HoloLens2 and Clara AGX are connected to the same network to facilitate communication.
    -
3.  **Open the Project in Unity**
    
    -   We recommend opening this project using Unity version 2021.3.14f1. While it works with newer Unity versions, be prepared for additional configurations if necessary.
4.  **Configure ROS Settings in Unity**
    
    -   In Unity, navigate to the menu bar and select `Robotics` -> `ROS Setting`.
    -   Modify the protocol to `ROS2`, and set the `ROS IP Address` to match ClaraAGX's IP address.
    -   Keep the `ROS Port` as 10000. Ensure this port value matches the configuration in the Python server.
5.  **Build and Deploy the Project**
    
    -   Build the project and deploy it to your HoloLens2 device.
6.  **Interact with the Application**
    
    -   When the Python server is running, you will observe ultrasound images streaming from Clara AGX to the HoloLens2.
    -   In the application space, you will find a switch button. Select it to initiate speech recording, and deselect it to stop recording. The recorded audio will be sent to Clara AGX for processing.

## Questions

If you have any questions or require further assistance, please do not hesitate to contact [Luohong.wu@balgrist.ch](mailto:Luohong.wu@balgrist.ch). We are here to help you make the most of this example application.
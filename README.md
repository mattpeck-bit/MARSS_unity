# Example for visualizing optical tracking data  
  
This repository contains an example application for streaming and visualizing optical tracking data. The application comprises two essential components: a Unity client and a Python server. These components communicate via ROS2, facilitated by the [Unity-Technologies/ROS-TCP-Connector](https://github.com/Unity-Technologies/ROS-TCP-Connector), which serves as a TCP-based communication framework. In this setup, the Python server runs on a laptop, acquiring tracking data from an optical tracking camera (SpryTrack) and streaming it to the Unity client, which operates on a HoloLens2 device.



# Speech Recognition and Image Streaming Example

Welcome to the Speech Recognition and Image Streaming example application. This repository contains a demonstration of how to integrate speech recognition and image streaming using two fundamental components: a Unity client and a Python server. These components communicate through ROS2, utilizing the [Unity-Technologies/ROS-TCP-Connector](https://github.com/Unity-Technologies/ROS-TCP-Connector), a TCP-based communication framework. In this configuration, the Python server operates on Clara AGX, streaming images to HoloLens2 and transcribing speech from HoloLens2 to text. The transcribed text can then be analyzed using Chat-GPT. The Unity client, running on HoloLens2, can visualize images from Clara AGX and record and transmit user speech to Clara AGX.

## Branch

If you are going to use optical tracking camera (spryTrack), please switch to the branch `feature/spryTrack`.

## Requirements

This application will run on HoloLens2. If you have no experience about building and deploying Unity project to HoloLens2, you can follow this tutorial [HoloLens 2 fundamentals: develop mixed reality applications - Training | Microsoft Learn](https://learn.microsoft.com/en-us/training/paths/beginner-hololens-2-tutorials/)


 ## Usage

Follow these steps to set up and run the Unity example:


1.  **Open the Project in Unity**
    
    -   Ensure you are using Unity version 2021.3.14f1. While it might work with newer Unity versions, additional configurations may be required.
2.  **Configure ROS Settings**
    
    -   In Unity, navigate to the menu bar and select `Robotics` -> `ROS Setting`.
    -   Modify the protocol to `ROS2`, and set the `ROS IP Address` to match your computer's IP address.
    -   Keep the `ROS Port` as 10000. Ensure this port value matches the configuration in the Python server.
3.  **Build the Unity Application**
    
    -   Configure the building settings as followed ![Drag Racing](Pictures/Unity%20building%20setting.png)
    -   Open the built result in Visual Studio and deploy it to the HoloLens2. Refer to the [Deployment tutorial](https://learn.microsoft.com/en-us/training/modules/learn-mrtk-tutorials/1-7-exercise-hand-interaction-with-objectmanipulator), starting from the section "Build your application in Unity" for detailed instructions.
4.  **Start the Application**
    
    -   Launch the Python server.
    -   Run the Unity application on the HoloLens2 device.
    -   It is crucial that when you start the Unity application, the HoloLens2 device is tracked by the SpryTrack. Allow a few seconds for the HoloLens2 to establish a connection between its coordinate system and the SpryTrack's coordinate system.
    -   As a best practice, place the HoloLens2 on a stable surface (e.g., a table) and initiate the app either from Visual Studio or the HoloLens2 device portal (can be opened by visiting HL2's IP via a browser on a laptop)
   
## Game Objects

Within the Unity project, you will encounter the following game objects:

-   **ROS_center:** This object is responsible for setting up the ROS connection and receiving tracking data from the Python server.
    
-   **Pelvis:** Represents the model that the application visualizes.
    
-   **PV camera:** Retrieve HoloLens2's coordinate system and set up the transformation between it and spryTrack's frame
    
-   **TransformationManager:** Updates all objects' transformation information according to the tracking data from ROS.
    
# Trouble Shooting
If you have any questions or require further assistance, please do not hesitate to contact Luohong.wu@balgrist.ch. We are here to help you make the most of this example application.
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

# Example for visualizing optical tracking data  
  
This repository contains an example application for streaming and visualizing optical tracking data. The application comprises two essential components: a Unity client and a Python server. These components communicate via ROS2, facilitated by the [Unity-Technologies/ROS-TCP-Connector](https://github.com/Unity-Technologies/ROS-TCP-Connector), which serves as a TCP-based communication framework. In this setup, the Python server runs on a laptop, acquiring tracking data from an optical tracking camera (SpryTrack) and streaming it to the Unity client, which operates on a HoloLens2 device.


 # Usage

Follow these steps to set up and run the Unity example:

0. **Make sure you have a proper environment for developing HL2 application**
   - If you have never developed a HL2 application of your PC, you could follow this tutorial https://learn.microsoft.com/en-us/training/paths/beginner-hololens-2-tutorials/

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
   
# Game Objects

Within the Unity project, you will encounter the following game objects:

-   **ROS_center:** This object is responsible for setting up the ROS connection and receiving tracking data from the Python server.
    
-   **Pelvis:** Represents the model that the application visualizes.
    
-   **PV camera:** Retrieve HoloLens2's coordinate system and set up the transformation between it and spryTrack's frame
    
-   **TransformationManager:** Updates all objects' transformation information according to the tracking data from ROS.
    
# Trouble Shooting
Contact Luohong.wu@balgrist.ch

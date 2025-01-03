# ExternalCameraFeed

## Dependencies:

* TextMeshPro

## Guides and Resources:

* [Basic Tutorial](https://www.youtube.com/watch?v=yjg0EirmQjE)
* [WebCamTexture API Reference](https://docs.unity3d.com/ScriptReference/WebCamTexture-ctor.html)
* [Matching WebCam Resolution & Aspect Ratio](https://discussions.unity.com/t/webcamtexture-get-correct-resolution-and-ratio/114179/3)

## How to Use

1. Import the Unity package into your project.
2. Attach to any Game Object you wish to project the webcam feed onto. Alternatively, drag-and-drop the prefab `WebCamDisplay` into your project.
    * Highly recommended to be a Quad or Plane primitive type.
3. Use the Inspector on the following:
    * `Detect On Start`: Do you want  the script to immediately start detecting devices?
    * `Devices Textbox`: If you assign a `TextMeshProUGUI` element to this, the system will print out a list of detected devices. This is primarily for debugging purposes.
4. Three functions can be assigned as listeners from the main script, `WebcamSetup`:
    * `DetectDevices()`: conducts the detection method where any external cameras will be identified. Also called automatically if `Detect on Start` is checked.
    * `SelectDevice(int i)`: force a camera to be set as active. Requires that the provided index integer refers to an index in the list of possible devices detected.
    * `NextDevice()`: Deactivates the current device and sets the next device as the active camera. If it reaches the end of the detected list of devices, loops back to the first item in the list.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum CameraType { TopDown, Free }

    public CameraType currentCamera = CameraType.TopDown;
    public Camera topDownCamera;
    public Quaternion topDownCameraAngle;
    public float cameraSpeed = 10;
    void Start()
    {
        topDownCamera.transform.rotation = topDownCameraAngle;
    }
    void Update()
    {
        if (currentCamera == CameraType.TopDown) { Camera.SetupCurrent(topDownCamera); }
        if (Input.GetAxis("Horizontal")!=0) { topDownCamera.transform.position += new Vector3(Time.deltaTime * Input.GetAxis("Horizontal") * cameraSpeed,0,0); }
        if (Input.GetAxis("Vertical") != 0) { topDownCamera.transform.position += new Vector3(0,0,Time.deltaTime * Input.GetAxis("Vertical") * cameraSpeed); }
    }
}

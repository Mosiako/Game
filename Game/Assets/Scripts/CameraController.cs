using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum CameraType { TopDown, Free }

    public CameraType currentCamera = CameraType.TopDown;
    public Camera topDownCamera;
    public Camera freeCamera;
    public Quaternion topDownCameraAngle;
    public float cameraSpeed = 10;
    public float cameraSensitivity = 1;

    [SerializeField] private float rotationY = 0;
    [SerializeField] private float rotationX = 0;
    void Start()
    {
        topDownCamera.transform.rotation = topDownCameraAngle;
        
    }
    void Update()
    {
        if (currentCamera == CameraType.TopDown) {
            Cursor.lockState = CursorLockMode.None;
            freeCamera.gameObject.SetActive(false);
            topDownCamera.gameObject.SetActive(true);
            Camera.SetupCurrent(topDownCamera); 
            if (Input.GetAxis("Horizontal")!=0) { topDownCamera.transform.position += new Vector3(Time.deltaTime * Input.GetAxis("Horizontal") * cameraSpeed,0,0); }
            if (Input.GetAxis("Vertical") != 0) { topDownCamera.transform.position += new Vector3(0,0,Time.deltaTime * Input.GetAxis("Vertical") * cameraSpeed); }
        }
        if (currentCamera == CameraType.Free)
        {
            Cursor.lockState = CursorLockMode.Locked;
            freeCamera.gameObject.SetActive(true);
            topDownCamera.gameObject.SetActive(false);
            Camera.SetupCurrent(freeCamera);
            if (Input.GetAxis("Horizontal") != 0) { freeCamera.transform.position += freeCamera.transform.right * Time.deltaTime * Input.GetAxis("Horizontal") * cameraSpeed; }
            if (Input.GetAxis("Vertical") != 0) { freeCamera.transform.position += freeCamera.transform.forward * Time.deltaTime * Input.GetAxis("Vertical") * cameraSpeed; }
            rotationY += cameraSensitivity * Input.GetAxis("Mouse X");
            rotationX -= cameraSensitivity * Input.GetAxis("Mouse Y");

            rotationX = Mathf.Clamp(rotationX, -90, 90);

            freeCamera.transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }


    }
}

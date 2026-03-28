using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class handles camera rotation by getting the input from the mouse and converting it to 3D movement using Euler angels.
 * It also Lerps the camera to the current player position
 */
public class CameraController : MonoBehaviour
{
    private float x,y; //Mouse Coordinates

    [SerializeField] private float rotationSensitivity = -1f; 
    [SerializeField] private float lerpSpeed; 


    private Vector3 rotate; //Determines where the camera rotates to when reseting its rotation

    [SerializeField] private GameObject player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        RotateCamera();
        SetCameraRotationToPlayer();
        followPlayer();
    }
    public void RotateCamera()
    {

        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");

        rotate = new Vector3(x, y * rotationSensitivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;



    } 
    // Sets the cameras Z axis to the same as the players to prevent camera from rotating when getting out of vehicle
    public void SetCameraRotationToPlayer()
    {
        Vector3 cameraRotation = transform.eulerAngles;
        cameraRotation.z = player.transform.eulerAngles.z;
        transform.eulerAngles = cameraRotation;
    }
    public void followPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3 (player.transform.position.x, player.transform.position.y + player.transform.localScale.y -0.2f, player.transform.position.z), lerpSpeed);
    }
   

}

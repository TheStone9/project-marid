using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cameramove : MonoBehaviour
{
    private const float YMin = -50.0f; //min Y-axis rotation
    private const float YMax = 50.0f; //max Y-axis rotation

    public Transform lookAt; //object for camera to look at

    public Camera cam; //camera object

    public float distance = 2.0f; //distance between camera and target on z-axis
    private float currX = 2.5f; //starting x position
    private float currY = -0.5f; //starting y position
    public float sensivity = 250.0f; //camera move sensitivity
    public float minFOV = 35f; //min field of view for camera zoom
    public float maxFOV = 60f; //max field of view for camera zoom




    // Update is called once per frame
    void Update()
    {

            currX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime; //update camera position in relation to x axis
            currY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime; //update camera position in relation to y axis

            currY = Mathf.Clamp(currY, YMin, YMax); //limit vertical rotation to our max and min constraints

            Vector3 Direction = new Vector3(0, 2, -distance); //direction of camera from target object, negative z axis because it is always behind
            Quaternion rotation = Quaternion.Euler(currY, currX, 0); //calculate camera rotation
            transform.position = lookAt.position + rotation * Direction; //set camera position based on player and calculated rotation and Direction
            transform.LookAt(lookAt.position); //holds camera view on player during rotation
        
      
            float scrollInput = -Input.GetAxis("Mouse ScrollWheel"); //detect mouse scroll input, negative so that forward zooms in and back zooms out
            cam.fieldOfView += 5f * scrollInput; // Adjust zoom speed
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFOV, maxFOV); //adjust FOV to fit within min and max constraints

    }
   
}

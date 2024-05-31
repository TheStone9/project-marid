using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    public float zoomLevel = 1.85f;
    public float minDistance = 0.5f;
    public float maxDistance = 5.0f;
    public float distance = 2.0f;
    public float zoomSpeed = 300.0f;
    public float minZoomLevel = 0.5f;
    public float maxZoomLevel = 5.0f;

    public Transform lookAt;

    // Update is called once per frame
    void Update()
    {
        float scrollInput = -Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance + scrollInput * zoomSpeed * Time.deltaTime, minDistance, maxDistance);

        /*zoomLevel += scrollInput * zoomSpeed * Time.deltaTime;

       
        zoomLevel = Mathf.Clamp(zoomLevel, minZoomLevel, maxZoomLevel);
        Vector3 newPosition = lookAt.position + transform.forward * (distance + zoomLevel);
        transform.position = newPosition;

        transform.LookAt(lookAt.position);
        */
    }
}

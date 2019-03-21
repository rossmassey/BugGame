using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraMoveSpeed = 15f;

    [SerializeField] float cameraZoomSpeed = 5f;
    [SerializeField] float cameraMinZoom = 5f;
    [SerializeField] float cameraMaxZoom = 15f;


    private void Update()
    {
        MoveCamera();
        ZoomCamera();
    }

    private void ZoomCamera()
    {
        if (Input.GetKey("e"))
        {
            Camera.main.orthographicSize = Mathf.Clamp(
                Camera.main.orthographicSize - Time.deltaTime * cameraZoomSpeed,
                cameraMinZoom,
                cameraMaxZoom);
        }
        if (Input.GetKey("q"))
        {
            Camera.main.orthographicSize = Mathf.Clamp(
                Camera.main.orthographicSize + Time.deltaTime * cameraZoomSpeed,
                cameraMinZoom,
                cameraMaxZoom);
        }
    }


    private void MoveCamera()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * cameraMoveSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * cameraMoveSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * cameraMoveSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * cameraMoveSpeed * Time.deltaTime, Space.Self);
        }
    }
}

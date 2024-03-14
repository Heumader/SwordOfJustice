using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] 
    private Camera cam;

 

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    private Vector3 dragOrigin;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private void Awake()
    {
        //tilemap.CompressBounds();
        mapMinX = tilemap.transform.position.x - tilemap.size.x/2;
        mapMinY = tilemap.transform.position.y - tilemap.size.y/2;
        mapMaxX = tilemap.transform.position.x + tilemap.size.x/2;
        mapMaxY = tilemap.transform.position.y + tilemap.size.y/2;


    }

    public void Update()
    {
        PanCamera();

        ZoomCamera();
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position += difference;
            cam.transform.position = ClampCamera(cam.transform.position);
        }

    }

    private void ZoomCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            ZoomIn();
         }else if (Input.GetAxis("Mouse ScrollWheel") < 0f )
        {
            ZoomOut();
        }
    }

    public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
        cam.transform.position = ClampCamera(cam.transform.position);
    }

    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        cam.transform.position = ClampCamera(cam.transform.position);

    }


    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;

        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);


        return new Vector3(newX, newY, targetPosition.z);
    }
}

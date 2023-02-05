using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEdgeController : MonoBehaviour
{
    private void Awake()
    {
        AddColliderOnCamera();
    }

    private void AddColliderOnCamera()
    {
        if (Camera.main == null) 
        { 
            Debug.LogError("Camera not found"); 
            return; 
        }

        Camera cam = Camera.main;

        if (!cam.orthographic) 
        { 
            Debug.LogError("Camera is not Orthographic"); 
            return; 
        }

        var edgeCollider = gameObject.GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : GetComponent<EdgeCollider2D>();

        var leftBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        var leftTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        var rightTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        var rightBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

        

        var edgePoints = new[] { leftBottom, leftTop, rightTop, rightBottom, leftBottom };
        edgeCollider.points = edgePoints;

    }
  
}

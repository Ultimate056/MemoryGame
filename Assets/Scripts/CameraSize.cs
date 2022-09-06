using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private const float TargetSizeX = 1920.0f;
    private const float TargetSizeY = 1080.0f;

    private void Awake()
    {
        CameraResize();
    }

    private void CameraResize()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = TargetSizeX / TargetSizeY;
        
        if(screenRatio >= targetRatio)
        {
            Resize();
        }
        else
        {
            float differentSize = targetRatio / screenRatio;
            Resize(differentSize);
        }
    }

    private void Resize(float differentSize = 1.0f)
    {
        Camera.main.orthographicSize = TargetSizeY / 200 * differentSize;
    }
}

﻿using UnityEngine;
using System.Collections;

public class PixelPerfectCamera : MonoBehaviour {

    public static float pixelsToUnits = 1f;
    public static float scale = 1f;

    public Vector2 nativeResolution = new Vector2(160,144);

     void Awake()
    {
        var camera = GetComponent<Camera>();
        if (camera.orthographic)
        {
            var dir = Screen.height;
            var res = nativeResolution.y;

            scale = dir / res;
            pixelsToUnits *= scale;

            camera.orthographicSize = (dir/2.0f) / pixelsToUnits;
        }
    }


}

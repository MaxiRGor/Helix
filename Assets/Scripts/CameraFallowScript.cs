﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallowScript : MonoBehaviour
{
    public GameObject playerSphere;
    public float cameraOffsetY = 8f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, playerSphere.transform.position.y + cameraOffsetY, transform.position.z);
    }
}

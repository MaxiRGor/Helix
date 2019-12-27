using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float rotationBoost;
    public bool canMove = true;
    private float moveHorizontal;

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                rotationBoost = 10f;
                moveHorizontal = Input.GetAxis("Horizontal") * rotationBoost;
                if (moveHorizontal != 0) transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, moveHorizontal, 0));
            }
            else
            if (Input.touchCount > 0)
            {
                rotationBoost = 0.2f;
                moveHorizontal = Input.touches[0].deltaPosition.x * rotationBoost;
                if (moveHorizontal != 0) transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, moveHorizontal, 0));
            }

        }
    }


}

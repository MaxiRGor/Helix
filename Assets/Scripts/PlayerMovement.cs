using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public bool canMove = true;

    private void FixedUpdate()
    {
        if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Mouse X");
            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                speed = 10f;
                moveHorizontal = Input.GetAxis("Horizontal");
                transform.Rotate(new Vector3(0, speed * moveHorizontal, 0));

            }
            else
            if (Input.touchCount > 0)
            {
                speed = 0.1f;
                moveHorizontal = Input.touches[0].deltaPosition.x;
                transform.Rotate(new Vector3(0, speed * moveHorizontal, 0));
            }

        }
    }
}

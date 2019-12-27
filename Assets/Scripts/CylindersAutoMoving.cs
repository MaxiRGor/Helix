using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylindersAutoMoving : MonoBehaviour
{
    public GameObject cylinderPrefab;
    private int numberOfCylinders = 5;
    private float cylinderLength = 10f;
    private GameObject player;
    private float offset = 10f;

    private void Start()
    {
        player = GameObject.Find("PlayerSphere");
    }

    private void LateUpdate()
    {
        if (transform.position.y > player.transform.position.y + offset)
        {
            float nextCylinderYPosition = transform.position.y - (numberOfCylinders * cylinderLength);
            Vector3 nextCylinderPosition = new Vector3(0, nextCylinderYPosition, 0);
            Instantiate(cylinderPrefab, nextCylinderPosition, transform.rotation);
            Destroy(gameObject);
        }
    }

}


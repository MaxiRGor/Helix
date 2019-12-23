using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderAutoMoving : MonoBehaviour
{
    private int numberOfCylinders = 5;
    private float cylinderLength = 10f;
    private GameObject player;
    private float offset = 20f;

    private void Start()
    {
        player = GameObject.Find("PlayerSphere");
    }

    private void FixedUpdate()
    {
        if (transform.position.y > player.transform.position.y + offset)
        {
            Debug.Log("OnBecameHigh and Moved");
            float nextCylinderYPosition = transform.position.y - (numberOfCylinders * cylinderLength);
            transform.position = new Vector3(0, nextCylinderYPosition, 0);
            gameObject.GetComponent<ArchGenScript>().addCircles(nextCylinderYPosition);
        }
    }
/*
    private void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible");
        float nextCylinderYPosition = transform.position.y - (numberOfCylinders * cylinderLength);
        transform.position = new Vector3(0, nextCylinderYPosition, 0);
        gameObject.GetComponent<ArchGenScript>().addCircles(nextCylinderYPosition);
        
    }*/
}


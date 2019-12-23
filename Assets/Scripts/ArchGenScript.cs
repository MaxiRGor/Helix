using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchGenScript : MonoBehaviour
{
    public GameObject archPrefab;
    private int numberOfArches = 18;
    private float radius = 5.01f;
    private Material material;
    private bool isAtLeastObstacle = false;
    private float circleLength = 10f;
    private float circleStep = 10f;


    public void addCircles(float yPosition)
    {
        for(float i = 0; i<circleLength; i += circleStep)
        {
            addCircle(i + yPosition);
        }
    }
    private void addCircle(float yPosition)
    {
        for (int i = 0; i < numberOfArches - 1; i++)
        {
            // obstacle probability = 10%
            bool isObstacle = (UnityEngine.Random.Range(0, 9) == 0);

            if (!isObstacle)
            {
                addArch(i, yPosition);
            }
            else
            {
                isAtLeastObstacle = true;
            }

        }

/*        //to be sure there is as least 1 obstacle in a cylinder
        if (isAtLeastObstacle)
        {
            addArch(numberOfArches - 1, yPosition);
        }
        else Debug.Log("NoObstacles");*/

    }

    private void addArch(int i, float yPosition)
    {
        float angle = i * Mathf.PI * 2 / numberOfArches;
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        Vector3 pos = /*transform.position*/  new Vector3(x, yPosition, z);
        float angleDegrees = -angle * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(90, angleDegrees, 0);
        GameObject arch = Instantiate(archPrefab, pos, rot);
        setArchColor(arch, i);
    }

    private void setArchColor(GameObject arch, int i)
    {
        arch.name = "Arch " + i;

        // red probability = 20%
        bool isRed = (UnityEngine.Random.Range(0, 4) == 0);

        material = arch.GetComponent<Renderer>().material;
        if (isRed)
        {
            material.color = Color.red;
        }
        else
        {
            material.color = Color.blue;
        }
    }

}

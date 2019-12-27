using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchGenScript : MonoBehaviour
{
    public GameObject goodArchPrefab;
    public GameObject badArchPrefab;

    private int numberOfArches = 18;
    private float radius = 5.01f;
    private float circleLength = 10f;
    private float circleStep = 10f;

    private List<GameObject> arches;// = new List<GameObject>();
    private List<GameObject> goodArches;// = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(addCircles(transform.position.y));
        arches = new List<GameObject>();
        goodArches = new List<GameObject>();
    }

    public IEnumerator addCircles(float yPosition)
    {
        yield return new WaitForEndOfFrame();
        for (float i = 0; i < circleLength; i += circleStep)
        {
            yield return StartCoroutine(addCircle(i + yPosition));
        }
        yield return new WaitForEndOfFrame();
    }
    private IEnumerator addCircle(float yPosition)
    {

        for (int i = 0; i < numberOfArches; i++)
        {

            // obstacle probability = 10%
            bool isObstacle = (UnityEngine.Random.Range(0, 9) == 0);

            if (!isObstacle)
            {
                yield return StartCoroutine(addArch(i, yPosition));
            }

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
    }

    private IEnumerator addArch(int i, float yPosition)
    {
        // bad probability = 20%
        bool isBad = (UnityEngine.Random.Range(0, 4) == 0);
        float angle = i * Mathf.PI * 2 / numberOfArches;
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        Vector3 pos = new Vector3(x, yPosition, z);
        float angleDegrees = -angle * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(90, angleDegrees, 0);
        GameObject arch;
        if (isBad)
        {
            arch = Instantiate(badArchPrefab, pos, rot);
            arch.name = "Bad Arch";
        }
        else
        {
            arch = Instantiate(goodArchPrefab, pos, rot);
            arch.name = "Good Arch";
            goodArches.Add(arch);
        }

        
        arch.transform.parent = gameObject.transform;
        arches.Add(arch);

        yield return new WaitForEndOfFrame();
    }


    public void addRigidbodyToArches()
    {
        foreach (GameObject arch in goodArches)
        {
            int upMagnitude = UnityEngine.Random.Range(20, 100);
            int forwardMagnitude = UnityEngine.Random.Range(-100, 100);
            int destroyTime = UnityEngine.Random.Range(2, 4);
            if (arch != null)
                if (arch.GetComponent<Rigidbody>() == null)
                {
                    Rigidbody gameObjectsRigidBody = arch.AddComponent<Rigidbody>();
                    if (gameObjectsRigidBody != null)
                    {
                        gameObjectsRigidBody.mass = 5;
                        gameObjectsRigidBody.AddForce(arch.transform.up * upMagnitude, ForceMode.Impulse);
                        gameObjectsRigidBody.AddForce(arch.transform.forward * forwardMagnitude, ForceMode.Impulse);
                        StartCoroutine(DestroyInSeconds(destroyTime, arch));
                    }
                }
        }

    }

    private IEnumerator DestroyInSeconds(int destroyTime, GameObject gameObject)
    {
        arches.Remove(gameObject);
        yield return new WaitForSeconds(destroyTime);        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
/*        foreach (GameObject arch in arches)
        {
            if (arch)
                Destroy(arch);
            // arches.Clear();
        }*/


    }

}

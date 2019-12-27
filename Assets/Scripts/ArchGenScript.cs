using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ArchGenScript : MonoBehaviour
{

    public Material goodArchMaterial;
    public Material badArchMaterial;

    private int numberOfArches = 18;
    private float radius = 5.01f;

    private List<GameObject> arches = new List<GameObject>();
    private List<GameObject> goodArches = new List<GameObject>();

    private bool isObstacle;

    bool isBad;
    float angle;
    float x;
    float z;
    Vector3 position;
    float angleDegrees;
    Quaternion rotation;

    GameObject arch;

    private void OnEnable()
    {
        addCircle(transform.position.y);
    }


    private void addCircle(float yPosition)
    {
        for (int i = 0; i < numberOfArches; i++)
        {
            // obstacle probability = 10%
            isObstacle = (UnityEngine.Random.Range(0, 9) == 0);

            if (!isObstacle)
            {
                StartCoroutine(addArch(i, yPosition));
            }
        }
    }

    private IEnumerator addArch(int i, float yPosition)
    {
        // bad probability = 20%
        isBad = (UnityEngine.Random.Range(0, 4) == 0);
        angle = i * Mathf.PI * 2 / numberOfArches;
        x = Mathf.Cos(angle) * radius;
        z = Mathf.Sin(angle) * radius;
        position = new Vector3(x, yPosition, z);
        angleDegrees = -angle * Mathf.Rad2Deg;
        rotation = Quaternion.Euler(90, angleDegrees, 0);

        arch = ArchesPooler.SharedInstance.GetPooledObject();



        if (arch != null)
        {
            arch.transform.parent = gameObject.transform;

            arch.transform.position = position;
            arch.transform.rotation = rotation;
            arch.SetActive(true);
            if (isBad)
            {
                arch.GetComponent<Renderer>().material = badArchMaterial;
                arch.name = "Bad Arch";
            }
            else
            {
                arch.GetComponent<Renderer>().material = goodArchMaterial;
                arch.name = "Good Arch";
                goodArches.Add(arch);
            }
            arches.Add(arch);
        }

        yield return null;
    }

    public void addRigidbodyToArches()
    {
        foreach (GameObject arch in goodArches)
        {
            int upMagnitude = UnityEngine.Random.Range(20, 100);
            int forwardMagnitude = UnityEngine.Random.Range(-100, 100);
            float destroyTime = UnityEngine.Random.Range(1, 2);
            if (arch != null)
                if (arch.GetComponent<Rigidbody>() == null)
                {
                    Rigidbody gameObjectsRigidBody = arch.AddComponent<Rigidbody>();
                    if (gameObjectsRigidBody != null)
                    {
                        gameObjectsRigidBody.mass = 5;
                        gameObjectsRigidBody.AddForce(arch.transform.up * upMagnitude, ForceMode.Impulse);
                        gameObjectsRigidBody.AddForce(arch.transform.forward * forwardMagnitude, ForceMode.Impulse);
                        StartCoroutine(DisableInSeconds(destroyTime, arch));
                    }
                }
        }

    }

    private IEnumerator DisableInSeconds(float destroyTime, GameObject gameObject)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
    }

    public void DisableArches()
    {
        foreach (GameObject arch in arches)
        {
            Debug.Log(this.gameObject.name + "Arch " + arch.name + " disabled");
            arch.SetActive(false);
        }
        arches.Clear();
        goodArches.Clear();

    }

    private void OnDisable()
    {
        DisableArches();
    }


    /*
     *     private void addRigidbodiesToArches()
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
    */

}


/*
 *     public IEnumerator addCircles(float yPosition)
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
            isObstacle = (UnityEngine.Random.Range(0, 9) == 0);

            if (!isObstacle)
            {
                yield return StartCoroutine(addArch(i, yPosition));
            }

            yield return new WaitForEndOfFrame();
        }
        yield break;
    }

    private IEnumerator addArch(int i, float yPosition)
    {
        // bad probability = 20%
        isBad = (UnityEngine.Random.Range(0, 4) == 0);
        angle = i * Mathf.PI * 2 / numberOfArches;
        x = Mathf.Cos(angle) * radius;
        z = Mathf.Sin(angle) * radius;
        pos = new Vector3(x, yPosition, z);
        angleDegrees = -angle * Mathf.Rad2Deg;
        rot = Quaternion.Euler(90, angleDegrees, 0);
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

        yield break;
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
                        StartCoroutine(DisableInSeconds(destroyTime, arch));
                    }
                }
        }

    }

    private IEnumerator DisableInSeconds(int destroyTime, GameObject gameObject)
    {
        yield return new WaitForSeconds(destroyTime);
        gameObject.SetActive(false);
        yield break;
    }

    private void OnDestroy()
    {
        DestroyArches();
    }

    public void DestroyArches()
    {
        try { 
            foreach (GameObject arch in arches)
            {
                Debug.Log(this.gameObject.name + "Arch " + arch.name + " destroyed");
                Destroy(arch);
            }
            arches.RemoveAt(0);
        } catch (Exception e) { };
    }
*/

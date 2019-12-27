using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CylindersAutoMoving : MonoBehaviour
{
    // private Component objectPoolerComponent;
   // private int numberOfCylinders = 5;
    private float cylinderLength = 10f;
    private int nextCylinderYPosition = 0;
    
    
    private GameObject cylinder;

    private void Start()
    {       
        for (; nextCylinderYPosition > - CylindersPooler.SharedInstance.amountToPool;)
        {
            AddCylinderToScene();
        }
    }
/*

    private IEnumerator Replace(float nextCylinderYPosition, Quaternion rotation)
    {
        gameObject.GetComponent<ArchGenScript>().DestroyArches();
        yield return null;
        Vector3 nextCylinderPosition = new Vector3(0, nextCylinderYPosition, 0);
        //   Instantiate(cylinderPrefab, nextCylinderPosition, rotation);
        Destroy(gameObject);
        yield break;
    }*/

    public void AddCylinderToScene()
    {
        cylinder = CylindersPooler.SharedInstance.GetPooledObject();
        if (cylinder != null)
        {
            cylinder.transform.position = new Vector3(0, nextCylinderYPosition * cylinderLength, 0);
            cylinder.SetActive(true);
            nextCylinderYPosition--;
        }
        else Debug.Log("Fuck");
    }
    
}


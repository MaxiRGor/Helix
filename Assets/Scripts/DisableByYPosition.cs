using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableByYPosition : MonoBehaviour
{
    public float offset = 10f;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("PlayerSphere");
    }

    void Update()
    {
        if (transform.position.y > player.transform.position.y + offset)
        {
            gameObject.GetComponent<ArchGenScript>().DisableArches();
            gameObject.SetActive(false);
            Debug.Log("inactive");
            gameObject.GetComponentInParent<CylindersAutoMoving>().AddCylinderToScene();
            // StartCoroutine(Replace(transform.position.y - (numberOfCylinders * cylinderLength), transform.rotation));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialArchGenScript : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<ArchGenScript>().addCircles(transform.position.y);
    }

}

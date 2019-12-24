using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByYPosition : MonoBehaviour
{

    private GameObject player;
    private float offset = 20f;


    private void Start()
    {
        player = GameObject.Find("PlayerSphere");
    }
    private void LateUpdate()
    {       
        if (transform.position.y > player.transform.position.y + offset)
        {
            Destroy(gameObject);           
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            Debug.Log("Red");
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            GetComponentInParent<PlayerMovement>().canMove = false;
            StartCoroutine(reloadScene());
        }
        if (collision.gameObject.GetComponent<Renderer>().material.color == Color.blue)
        {
            Debug.Log("Blue");
        }
                
    }

    private IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

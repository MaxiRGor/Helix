using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public GameObject waterParticles;
    // Start is called before the first frame update
    
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(waterParticles, transform);
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

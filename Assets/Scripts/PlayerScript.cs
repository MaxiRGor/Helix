using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public GameObject waterParticles;
    private TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 60;
        text = GameObject.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void LateUpdate()
    {
        if (transform.position.y < 0)
            text.text = "Score " + (0 - (int)transform.position.y / 10);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Good Arch")
        {
            collision.gameObject.GetComponentInParent<ArchGenScript>().addRigidbodyToArches();
        }
        else
        {
            StartCoroutine(reloadScene());
            GameObject balloons = Instantiate(waterParticles, this.gameObject.transform);
            StartCoroutine(destroyBalloons(balloons));
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            GetComponentInParent<PlayerMovement>().canMove = false;
            gameObject.GetComponent<Renderer>().enabled = false;


            // GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            // GetComponentInParent<PlayerMovement>().canMove = false;
            // Destroy(this.gameObject);

        }

    }

    private IEnumerator destroyBalloons(GameObject balloons)
    {
        yield return new WaitForSeconds(1);
        Destroy(balloons);
    }

    private IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

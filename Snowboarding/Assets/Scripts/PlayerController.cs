using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float xMax = 20f;
    float speed = 10f;

    void Update()
    {
        // Vector2 controllerInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        // transform.Translate(new Vector3(controllerInput.x, 0, 0) * Time.deltaTime * speed, Space.World);

        float hInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(hInput, 0, 0) * Time.deltaTime * speed, Space.World);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xMax, xMax), transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            speed = 0f;
            GameManager.instance.playerCrash = true;
            StartCoroutine(nameof(GameOver));
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

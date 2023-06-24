using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xMax = 20f;
    float speed = 5f;

    void Update()
    {
        // Vector2 controllerInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        // transform.Translate(new Vector3(controllerInput.x, 0, 0) * Time.deltaTime * speed, Space.World);

        float hInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(hInput, 0, 0) * Time.deltaTime * speed, Space.World);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xMax, xMax), transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            Debug.Log("Gameover");
            GameManager.instance.playerCrash = true;
        }
    }
}

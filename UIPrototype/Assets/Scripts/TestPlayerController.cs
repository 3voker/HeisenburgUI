using UnityEngine;
using System.Collections;

public class TestPlayerController : MonoBehaviour
{

    // Use this for initialization
    Vector3 movement;

    Rigidbody rigidBody;
    float speed = 5;
    void Start()
    {

    }

    // Update is called once per frame

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;
        // movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

       rigidBody.AddForce(movement * speed * Time.deltaTime);
       playerInput();
    }
    private void playerInput()
    {
        if (Input.GetButton("aButton"))
        {
            transform.position += transform.up * speed * Time.deltaTime;
            Debug.Log("aButton was pressed!");
        }
    }
}

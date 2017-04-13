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
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {

        //Move back to player after finishing dialogue
        //Vector3.zero; 

        //transform.position += Vector3.forward * Time.deltaTime;
        playerInput();
    }
    private void playerInput()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;
        if (Input.GetButton("Jump"))
        {
            transform.position += transform.up * speed * Time.deltaTime;
            Debug.Log("aButton was pressed!");
        }
       movement = moveVertical * Vector3.forward + moveHorizontal * Vector3.right;
    }
}

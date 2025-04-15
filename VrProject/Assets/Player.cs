using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    public float speed = 5f;
    public Camera cam;

    float mouse_x = 0f, mouse_y = 0f;
    public float camsensitivity = 5f;

    public Transform orientation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Cursor.lockState = true;
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        float mx = Input.GetAxis("Mouse X")*Time.deltaTime* camsensitivity;
        float my = Input.GetAxis("Mouse Y")*Time.deltaTime* camsensitivity * -1;

        mouse_y += mx;
        mouse_x += my;

        mouse_x = Mathf.Clamp(mouse_x, -90f, 90f);
        transform.rotation = Quaternion.Euler(mouse_x, mouse_y, 0);
        rb.linearVelocity = inputH* orientation.right * speed +inputV * orientation.forward * speed;
// rb.velocity = new Vector3(inputH * orientation.right * speed, rb.velocity.y, inputV * orientation.forward * speed);// * speed;
        orientation.rotation = Quaternion.Euler(0, mouse_y, 0);


    }
}

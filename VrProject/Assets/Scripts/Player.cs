using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public bool fpsMode = true;

    Rigidbody rb;

    public float speed = 5f;
    public Camera cam;

    float mouse_x = 0f, mouse_y = 0f;
    public float camsensitivityHoriz = 5f, camsensitivityVert = 5f;

    public Transform orientation;
    public AudioClip footstepClip;
    public float footstepInterval = 0.5f;

    public AudioSource footstepAudio;
    private float footstepTimer = 0f;

    public static Player instance;
    private void Awake()
    {
        instance = this;//no more than 1 of these in a scene too lazy to make error message
    }
    void Start()
    {
        if (!fpsMode) { return; }
        rb = GetComponent<Rigidbody>();
        //footstepAudio = GetComponent<AudioSource>();

        Debug.Log("AudioSource found: " + (footstepAudio != null));

        //Screen.lockCursor = true;

        if (footstepAudio == null)
        {
            Debug.LogError("⚠️ No AudioSource found on Player GameObject!");
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fpsMode) { return; }

        print("Fuck ass game");

        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        float mx = Input.GetAxis("Mouse X") * Time.deltaTime * camsensitivityHoriz;
        float my = Input.GetAxis("Mouse Y") * Time.deltaTime * camsensitivityVert * -1;

        mouse_y += mx;
        mouse_x += my;

        mouse_x = Mathf.Clamp(mouse_x, -90f, 90f);
        transform.rotation = Quaternion.Euler(mouse_x, mouse_y, 0);
        rb.linearVelocity = inputH * orientation.right * speed + inputV * orientation.forward * speed;
        // rb.velocity = new Vector3(inputH * orientation.right * speed, rb.velocity.y, inputV * orientation.forward * speed);// * speed;
        orientation.rotation = Quaternion.Euler(0, mouse_y, 0);


        PlayFootsteps(inputH, inputV);

        KeyBoardControls();


    }

    void KeyBoardControls()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Screen.lockCursor = false;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MainMenu");
        }
    }


    void PlayFootsteps(float inputH, float inputV)
    {
        bool isMoving = new Vector3(inputH, 0, inputV).magnitude > 0.1f;
        bool grounded = IsGrounded();
        //footstepAudio.PlayOneShot(footstepClip);
        if (isMoving)
        {
            footstepTimer -= Time.deltaTime;

            if (footstepTimer <= 0f)
            {
                footstepAudio.PlayOneShot(footstepClip);
                footstepTimer = footstepInterval;
            }
    }
        else
        {
            footstepTimer = 0f;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
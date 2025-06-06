using UnityEngine;

public class Rat : MonoBehaviour
{
    public bool moving = false;
    public Animator animator;
    public float speed = 10f;
    public float angle = 0.5f;
    Rigidbody rb;

    public AudioSource explodeAudio;
    public GameObject explosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator.SetBool("Moving", moving);
        animator.SetTrigger("SetNewState");
    }

    // Update is called once per frame
    void Update()
    {
        if (moving) 
        {
            MovingMode();
        }
    }

    void MovingMode() 
    {
        if (rb.linearVelocity.magnitude <= 0.05f)
        {
            transform.Rotate(0f, 180f, 0f, Space.Self);
        }

        rb.linearVelocity = transform.forward * speed;
        transform.Rotate(0f, angle * Time.deltaTime, 0f, Space.Self);
    }

    public void OnCollisionEnter(Collision c) {
        if (c.gameObject.CompareTag("LaunchedObject")) 
        {
            LaunchableObject l = c.gameObject.GetComponent<LaunchableObject>();
            print(l.rb.linearVelocity.magnitude);
            if (l.rb.linearVelocity.magnitude >= 2f)
            {
                //Trigger add points
                UI.instance.ratKillNumber++;
                UI.instance.UpdateRatCounterText();

                explosion.SetActive(true);
                explosion.transform.SetParent(null);
                explosion.GetComponent<Animator>().SetTrigger("playBoom");
                explodeAudio.Play();
                Destroy(gameObject);
                
            }
        }
    }
}

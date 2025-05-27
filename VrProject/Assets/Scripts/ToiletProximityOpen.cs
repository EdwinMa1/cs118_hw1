using UnityEngine;

public class ToiletProximityOpen : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float distanceToOpen;
    bool isOpen = false;
    public AudioSource sfx;

    bool interactedBefore = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("LidOpen", !isOpen);
        float d = Vector3.Distance(player.position, transform.position);
        if (d < distanceToOpen)
        {
            if (!isOpen) 
            {
                isOpen = true;
                animator.SetTrigger("OpenLid");

                if (interactedBefore) //prevent overlapping with stairs
                {
                    sfx.Play();
                }
                interactedBefore = true;
            }
        }
        else 
        {
            if (isOpen)
            {
                isOpen = false;
                animator.SetTrigger("OpenLid");
            }
        }
    }
}

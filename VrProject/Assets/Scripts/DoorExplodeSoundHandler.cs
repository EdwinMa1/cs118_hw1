using UnityEngine;

public class DoorExplodeSoundHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource audio;
    bool triggered = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!triggered)
            {
                triggered = true;
                audio.Play();
            }
        }
        
    }

}

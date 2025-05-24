using UnityEngine;

public class PaintingProximity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player player;
    public float stareTime, distance;
    public AudioSource audio;

    bool staring = false;
    float internalStareTime = 0f;
    void Start()
    {
        
    }

    void OnBecameInvisible()
    {
        staring = false;
    }

    // Enable this script when the GameObject moves into the camera's view
    void OnBecameVisible()
    {
        staring = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (staring && Vector3.Distance(player.transform.position, transform.position) <= distance)
        {
            internalStareTime += Time.deltaTime;
            if (internalStareTime >= stareTime) 
            {
                internalStareTime = 0f;
                staring = false;
                audio.Play();
            }
        }


    }

    
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class vrInteractable: MonoBehaviour
{

    public float stareTime;
    public static float distance = 2;
    public AudioSource audio;

    bool staring = false;
    public GameObject lightSource;//Glow effect

    Player player;
    void Start()
    {
        player = Player.instance;
    }

    void OnBecameInvisible()
    {
        staring = false;
        lightSource.SetActive(false);
    }

    // Enable this script when the GameObject moves into the camera's view
    void OnBecameVisible()
    {
        staring = true;
        if (Vector3.Distance(player.transform.position, transform.position) <= distance)
        {
            lightSource.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

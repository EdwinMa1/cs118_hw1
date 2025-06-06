using UnityEngine;
using UnityEngine.UI;

public class VRUIBillboard : MonoBehaviour
{
    Camera main_playerCamera;
    public bool isButton;
    public Button clickableCounterpart;
    public bool destroy = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        main_playerCamera = Player.instance.cam;
    }

    // Update is called once per frame
    void FixedUpdate()//don't need to update as often
    {
        transform.LookAt(main_playerCamera.transform.position);
        if (destroy) { Destroy(gameObject); }
    }

    public void triggerButtonEffect() 
    {
        if (!isButton) { return; }
        clickableCounterpart.onClick.Invoke();
    }
}

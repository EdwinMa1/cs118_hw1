using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.InputSystem;

public class LaunchableObject: XRGrabInteractable{
    public float firePower = 10f;
    bool selected = false;
    IXRSelectInteractor interactor;
    public InputActionReference fireAction;

    Player player;
    //bool lookedAt;
    GameObject glowSource;

    public Rigidbody rb;

    public static float minGlowDist = 2f;

    

    public void Start(){
        fireAction.action.Enable();
        rb = GetComponent<Rigidbody>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args){
        base.OnSelectEntered(args);
        selected = true;
        interactor = args.interactorObject;
    }

    protected override void OnSelectExited(SelectExitEventArgs args){
        base.OnSelectExited(args);
        selected = false;
    }

    void FireObject()
    {
        throwOnDetach = false;
        interactionManager.SelectExit(interactor,this);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = interactor.GetAttachTransform(this).forward*firePower;
    }

    void Update()
    {

        if(selected)
        {
            if(fireAction.action.IsPressed())
            {
                FireObject();
            }
        }
       
    }
}
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // or any condition
        {
            anim.SetTrigger("ComeOut");
        }
    }
}

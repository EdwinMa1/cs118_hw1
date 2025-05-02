using UnityEngine;
public class StairRamp : MonoBehaviour
{
    public Animator anim;
    private bool played = false;

    void Update()
    {
        if (!played && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("ComeOut");
            played = true; // block further triggers
        }
    }
}
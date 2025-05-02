using UnityEngine;
public class StairRamp : MonoBehaviour
{
    public Animator anim;
    public Animator toiletAnim;
    private bool played = false;

    void Start()
{
        // Hard-code position to match animation's frame 0
        transform.position = new Vector3(25.32871f, 9.569587f, 51.03f); // Replace with actual "in" coordinates
    }
    void Update()
    {
        AnimatorStateInfo toiletState = toiletAnim.GetCurrentAnimatorStateInfo(0);

        if (!played && toiletState.IsName("OpenLid"))
        {
            anim.SetTrigger("ComeOut");
            played = true; // block further triggers
        }
    }
}
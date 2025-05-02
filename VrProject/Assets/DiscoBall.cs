using UnityEngine;

public class DiscoBall : MonoBehaviour
{

    public Light l;
    public float colorDuration = 2.5f, transitionTime = 0.5f;
    Color currentC, newC;
    int mode = 0;
    float transitionTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == 0) 
        {
            colorDuration -= Time.deltaTime;
            if (colorDuration <= 0f) 
            {
                colorDuration = 2.5f;
                mode = 1;
                currentC = newC;
                newC = new Color(Random.value , Random.value, Random.value );
                transitionTimer = 0f;
            }
        }
        else if (mode == 1) 
        {
            transitionTimer += Time.deltaTime;
            l.color = Color.Lerp(currentC, newC, transitionTimer / transitionTime);
            if (transitionTimer > transitionTime) 
            {
                mode = 0;
            }

        }
    }
}

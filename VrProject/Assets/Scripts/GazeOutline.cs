using UnityEngine;

public class GazeOutline : MonoBehaviour
{

    public Shader outlineShader, ogShader;
    public Material originalMat;

    public float gazeDistance = 10f;
    private GameObject currentGazedObject;
    public Color throwableOutlineColor;// = new Color(1f, 0f, 0f);
    public Color grabableOutlineColor;// = new Color(1f, 0f, 0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, gazeDistance))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject != currentGazedObject)
            {
                if (currentGazedObject != null) { ClearHighlight(); }
                if (hitObject.CompareTag("LaunchedObject"))
                {
                    HighlightObject(hitObject, throwableOutlineColor);
                    currentGazedObject = hitObject;
                }
                else if (hitObject.CompareTag("Grabable"))
                {
                    HighlightObject(hitObject, grabableOutlineColor);
                    currentGazedObject = hitObject;
                }
            }
        }
        else
        {
            if (currentGazedObject != null) { ClearHighlight(); }

        }
    }

    void HighlightObject(GameObject obj, Color c)
    {
        Renderer rend = obj.GetComponent<Renderer>();

        // Cache original material and shader only ONCE
        originalMat = rend.material;
        ogShader = originalMat.shader;

        // Make a copy of the material so we don’t overwrite the original
        Material outlineMat = new Material(originalMat);
        outlineMat.shader = outlineShader;
        outlineMat.SetColor("_OutlineColor", c);
        outlineMat.SetFloat("_Outline", 1.0f);
        rend.material = outlineMat;
    }

    void ClearHighlight()
    {
        ResetObjectMaterial(currentGazedObject);

        currentGazedObject = null;
    }




    void ResetObjectMaterial(GameObject obj)
    {
        Renderer rend = obj.GetComponent<Renderer>();
        rend.material = originalMat;
        obj.GetComponent<Renderer>().material.shader = ogShader;

    }


}

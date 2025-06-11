using UnityEngine;

public class GazeOutline : MonoBehaviour
{

    public Shader outlineShader, ogShader;
    public Material originalMat;

    public float gazeDistance = 10f;
    private GameObject currentGazedObject;
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
                ClearHighlight();
                if (hitObject.CompareTag("GazeHighlight"))
                {
                    HighlightObject(hitObject);
                    currentGazedObject = hitObject;
                }
            }
        }
        else
        {
            if (currentGazedObject != null) { ClearHighlight(); }
            
        }
    }

    void HighlightObject(GameObject obj)
    {
        originalMat = obj.GetComponent<Renderer>().material;
        ogShader = originalMat.shader;

        obj.GetComponent<Renderer>().material.shader = outlineShader;
        
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

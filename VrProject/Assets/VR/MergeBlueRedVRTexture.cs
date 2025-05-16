using UnityEngine;
using UnityEngine.UI;

public class AnaglyphCombiner : MonoBehaviour
{
    public RenderTexture leftTexture;
    public RenderTexture rightTexture;
    public RawImage outputImage;

    private Texture2D leftTex2D, rightTex2D, combinedTex;

    void Start()
    {
        int width = leftTexture.width;
        int height = leftTexture.height;

        leftTex2D = new Texture2D(width, height, TextureFormat.RGB24, false);
        rightTex2D = new Texture2D(width, height, TextureFormat.RGB24, false);
        combinedTex = new Texture2D(width, height, TextureFormat.RGB24, false);
    }

    void Update()
    {
        // Read left texture
        RenderTexture.active = leftTexture;
        leftTex2D.ReadPixels(new Rect(0, 0, leftTexture.width, leftTexture.height), 0, 0);
        leftTex2D.Apply();

        // Read right texture
        RenderTexture.active = rightTexture;
        rightTex2D.ReadPixels(new Rect(0, 0, rightTexture.width, rightTexture.height), 0, 0);
        rightTex2D.Apply();

        RenderTexture.active = null;

        // Combine into anaglyph
        Color[] leftPixels = leftTex2D.GetPixels();
        Color[] rightPixels = rightTex2D.GetPixels();
        Color[] finalPixels = new Color[leftPixels.Length];

        for (int i = 0; i < leftPixels.Length; i++)
        {
            float r = leftPixels[i].r;
            float g = rightPixels[i].g;
            float b = rightPixels[i].b;
            finalPixels[i] = new Color(r, g, b);
        }

        combinedTex.SetPixels(finalPixels);
        combinedTex.Apply();

        outputImage.texture = combinedTex;
    }
}

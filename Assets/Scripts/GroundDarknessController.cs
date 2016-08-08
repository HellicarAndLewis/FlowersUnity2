using UnityEngine;
using System.Collections;

public class GroundDarknessController : MonoBehaviour
{
    [Range(0, 1)]
    public float darkness;
    public Color emissive = Color.black;
    [Range(0, 1)]
    public float emissiveBright = 0;
    public Renderer[] renderers;
    
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }


    void Update()
    {
        foreach (Renderer rend in renderers)
        {
            //Color col = rend.material.GetColor("_Color");
            rend.material.SetColor("_Color", new Color(darkness, darkness, darkness));
            rend.material.SetColor("_EmissionColor", emissive * emissiveBright);

            //float scaleX = MathUtils.Map(Mathf.PerlinNoise(Time.time * 0.076f, 0), 0, 1, 1, 16);
            //float scaleY = MathUtils.Map(Mathf.PerlinNoise(Time.time * 0.11f, 0), 0, 1, 1, 16);
            //rend.material.mainTextureScale = new Vector2(scaleX, scaleY);
        }
    }
}

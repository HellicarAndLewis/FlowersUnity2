using UnityEngine;
using System.Collections;

public class TransparencyController : MonoBehaviour {

    public Renderer rend;
    // Use this for initialization
    [Range(0, 1)]
    public float saturation;
    [Range(0, 1)]
    public float hue;
    [Range(0, 1)]
    public float alpha;
    public bool blocking = false;
	void Start () {
        if (!rend)
            rend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Color col = Color.HSVToRGB(hue, saturation, 1.0f);
        if(blocking)
        {
            rend.material.SetColor("_Color", new Color(col.r, col.g, col.b, alpha));// = new Color(1.0f, 1.0f, 1.0f, alpha);
        }
        else
        {
            rend.material.SetColor("_Color", new Color(col.r * alpha, col.g * alpha, col.b * alpha));// = new Color(1.0f, 1.0f, 1.0f, alpha);
        }
    }
}

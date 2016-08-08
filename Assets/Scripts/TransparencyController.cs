using UnityEngine;
using System.Collections;

public class TransparencyController : MonoBehaviour {

    public Renderer rend;
    // Use this for initialization
    [Range(0, 1)]
    public float alpha;

    public bool blocking = false;

	void Start () {
        if (!rend)
            rend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(blocking)
        {
            Color col = rend.material.GetColor("_Color");
            rend.material.SetColor("_Color", new Color(col.r, col.g, col.b, alpha));// = new Color(1.0f, 1.0f, 1.0f, alpha);
        } else
        {
            rend.material.SetColor("_Color", new Color(alpha, alpha, alpha));// = new Color(1.0f, 1.0f, 1.0f, alpha);
        }
    }
}

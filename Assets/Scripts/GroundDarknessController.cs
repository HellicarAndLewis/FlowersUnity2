using UnityEngine;
using System.Collections;

public class GroundDarknessController : MonoBehaviour {

    [Range(0, 1)]
    public float darkness;

    public Renderer[] renderers;

	// Use this for initialization
	void Start () {
        renderers = GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach(Renderer rend in renderers)
        {
            Color col = rend.material.GetColor("_Color");
            rend.material.SetColor("_Color", new Color(darkness, darkness, darkness));
        }
	}
}

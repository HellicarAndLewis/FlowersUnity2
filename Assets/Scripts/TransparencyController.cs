﻿using UnityEngine;
using System.Collections;

public class TransparencyController : MonoBehaviour {

    public Renderer rend;
    // Use this for initialization
    [Range(0, 1)]
    public float alpha;
	void Start () {
        if (!rend)
            rend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Color col = rend.material.GetColor("_Color");
        rend.material.SetColor("_Color", new Color(col.r, col.g, col.b, alpha));// = new Color(1.0f, 1.0f, 1.0f, alpha);
	}
}
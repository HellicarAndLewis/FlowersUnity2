using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class NSDOSGuiController : MonoBehaviour {

    public Camera mainCam;
    public BloomOptimized bloom;
    public VignetteAndChromaticAberration vignette;
    public ColorCorrectionCurves colour;

    public float bloomTarget = 0;
    public float vignInensityTarget = 0;
    public float vignColourTarget = 0;
    public float colourTarget = 0;
    public float lerpAmount = 0.1f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bloom.intensity = Mathf.Lerp(bloom.intensity, bloomTarget, lerpAmount);
        vignette.intensity = Mathf.Lerp(vignette.intensity, vignInensityTarget, lerpAmount);
        vignette.chromaticAberration = Mathf.Lerp(vignette.chromaticAberration, vignColourTarget, lerpAmount);
        colour.saturation = Mathf.Lerp(colour.saturation, colourTarget, lerpAmount);
    }

    public void SetBloom(float value)
    {
        bloomTarget = value * 2.5f;
    }
    public void SetVignetteIntensity(float value)
    {
        vignInensityTarget = value;
    }
    public void SetVignetteColour(float value)
    {
        vignColourTarget = value * 50;
    }
    public void SetColourAmount(float value)
    {
        colourTarget = MathUtils.Map(value, 0, 1, 1, 5, true);
    }
}

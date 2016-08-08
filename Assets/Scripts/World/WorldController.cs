using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    public float lerpAmount = 0.1f;

    public GroundRotator ground;
    public float GroundSpeedMin = 0;
    public float GroundSpeedMax = 1;
    private float GroundSpeedTarget = 1;

    public Light worldLight;
    public float IntensityMin = 0;
    public float IntensityMax = 1;
    private float IntensityTarget = 1;
    public Vector3 LightRotMin;
    public Vector3 LightRotMax;
    private Quaternion LightRotTarget;
    //Sky Transparency
    public TransparencyController SkyTransparencyController;
    public float SkyTransparencyMin;
    public float SkyTransparencyMax;
    public float SkyTransparencyTarget;
    //Ground Brightness
    public GroundDarknessController GroundBrightnessController;
    public float GroundBrightnessMin;
    public float GroundBrightnessMax;
    public float GroundBrightnessTarget;

    // Use this for initialization
    void Start()
    {
        if (!ground)
            ground = gameObject.GetComponentInChildren<GroundRotator>();
        if (!worldLight)
            worldLight = gameObject.GetComponentInChildren<Light>();
    }

    void Update()
    {
        // ground speed
        if (ground) ground.speedX = Mathf.Lerp(ground.speedX, MathUtils.Map(GroundSpeedTarget, 0, 1, GroundSpeedMin, GroundSpeedMax, true), lerpAmount);

        // light intensity
        worldLight.intensity = Mathf.Lerp(worldLight.intensity, MathUtils.Map(IntensityTarget, 0, 1, IntensityMin, IntensityMax, true), lerpAmount);

        // light rotation
        var rot = worldLight.transform.localRotation;
        rot = Quaternion.Lerp(rot, LightRotTarget, lerpAmount);
        worldLight.transform.localRotation = rot;

        //Sky Transparency
        if(SkyTransparencyController)
        {
            SkyTransparencyController.alpha = Mathf.Lerp(SkyTransparencyController.alpha, SkyTransparencyTarget, lerpAmount);
        }

        if(GroundBrightnessController)
        {
            GroundBrightnessController.darkness = Mathf.Lerp(GroundBrightnessController.darkness, GroundBrightnessTarget, lerpAmount);
        }
    }

    public void Reset(float value = 0)
    {
        SetLightIntenseNorm(value);
        SetLightRotNorm(value);
    }

    public void SetGroundSpeedNorm(float value)
    {
        GroundSpeedTarget = MathUtils.Map(value, 0, 1, GroundSpeedMin, GroundSpeedMax, true);
    }

    public void SetLightIntenseNorm(float value)
    {
        IntensityTarget = MathUtils.Map(value, 0, 1, IntensityMin, IntensityMax, true);
    }

    public void SetLightRotNorm(float value)
    {
        LightRotTarget = Quaternion.Euler(Vector3.Lerp(LightRotMin, LightRotMax, value));
    }

    public void SetGroundBrightness(float value)
    {
        if(GroundBrightnessController)
        {
            GroundBrightnessTarget = MathUtils.Map(value, 0, 1, GroundBrightnessMin, GroundBrightnessMax);
        }
    }

    public void SetVideoOpacity(float value)
    {
        if(SkyTransparencyController)
        {
            SkyTransparencyTarget = MathUtils.Map(value, 0, 1, SkyTransparencyMin, SkyTransparencyMax);
        }
    }
}
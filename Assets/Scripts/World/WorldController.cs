using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    public float lerpAmount = 0.1f;

    public GroundRotator ground;
    public float GroundSpeedMin = 0;
    public float GroundSpeedMax = 0.5f;
    public float GroundSpeedTarget = 0.1f;
    public int GroundSpeedDirection = 1;

    public Light worldLight;
    public float IntensityMin = 0;
    public float IntensityMax = 1;
    public float IntensityTarget = 1;
    public Vector3 LightRotMin;
    public Vector3 LightRotMax;
    public Quaternion LightRotTarget;
    // Sky Transparency
    public TransparencyController SkyTransparencyController;
    public float SkyTransparencyMin;
    public float SkyTransparencyMax;
    public float SkyTransparencyTarget;
    // Ground Brightness
    public GroundDarknessController GroundBrightnessController;
    public float GroundBrightnessMin;
    public float GroundBrightnessMax;
    public float GroundBrightnessTarget;
    // Ground Emissive
    public float EmissiveMin;
    public float EmissiveMax;
    public float EmissiveTarget;
    // Sky Color
    public float SkyHueMin;
    public float SkyHueMax;
    public float SkyHueTarget;
    // Sky Color
    public float SkySatMin;
    public float SkySatMax;
    public float SkySatTarget;

    public WorldCamerasController worldCam;
    //public float camMinHeight = 36;
    //public float camMaxHeight = 42;
    public float camTargetHeight = -999;


    // Use this for initialization
    void Start()
    {
        if (!ground)
            ground = gameObject.GetComponentInChildren<GroundRotator>();
        if (!worldLight)
            worldLight = gameObject.GetComponentInChildren<Light>();
        worldCam = FindObjectOfType<WorldCamerasController>();
    }

    void Update()
    {
        // ground speed
        if (ground) ground.speedX = Mathf.Lerp(ground.speedX, GroundSpeedTarget * GroundSpeedDirection, lerpAmount) ;

        // light intensity
        worldLight.intensity = Mathf.Lerp(worldLight.intensity, IntensityTarget, lerpAmount);

        // light rotation
        var rot = worldLight.transform.localRotation;
        rot = Quaternion.Lerp(rot, LightRotTarget, lerpAmount);
        worldLight.transform.localRotation = rot;

        //Sky Transparency
        if(SkyTransparencyController)
        {
            SkyTransparencyController.alpha = Mathf.Lerp(SkyTransparencyController.alpha, SkyTransparencyTarget, lerpAmount);
            SkyTransparencyController.hue = Mathf.Lerp(SkyTransparencyController.hue, SkyHueTarget, lerpAmount);
            SkyTransparencyController.saturation = Mathf.Lerp(SkyTransparencyController.hue, SkyHueTarget, lerpAmount);
        }

        if(GroundBrightnessController)
        {
            GroundBrightnessController.darkness = Mathf.Lerp(GroundBrightnessController.darkness, GroundBrightnessTarget, lerpAmount);
            GroundBrightnessController.emissiveBright = Mathf.Lerp(GroundBrightnessController.emissiveBright, EmissiveTarget, lerpAmount);
        }
    }

    public void Reset(float value = 0)
    {
        GetComponent<SkyboxController>().UpdateMaterial();
        if (camTargetHeight != -999)
        {
            var cam = FindObjectOfType<WorldCamerasController>();
            if (cam) cam.targetHeight = camTargetHeight;
        }
    }

    public void SetGroundSpeedNorm(float value)
    {
        GroundSpeedTarget = MathUtils.Map(value, 0, 1, GroundSpeedMin, GroundSpeedMax, true);
    }

    public void SetWorldDirection(bool value)
    {
        GroundSpeedDirection *= (value) ? 1 : -1;
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

    public void SetVideoHue(float value)
    {
        if (SkyTransparencyController)
        {
            SkyHueTarget = MathUtils.Map(value, 0, 1, SkyHueMin, SkyHueMax);
        }
    }

    public void SetVideoSaturation(float value)
    {
        if (SkyTransparencyController)
        {
            SkySatTarget = MathUtils.Map(value, 0, 1, SkySatMin, SkySatMax);
        }
    }

    public void SetGroundEmissive(float value)
    {
        if (GroundBrightnessController)
        {
            EmissiveTarget = MathUtils.Map(value, 0, 1, EmissiveMin, EmissiveMax);
        }
    }

}
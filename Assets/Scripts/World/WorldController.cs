using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{

    public GroundRotator ground;
    public float GroundSpeedMin = 0;
    public float GroundSpeedMax = 1;
    
    public Light worldLight;
    public float IntensityMin = 0;
    public float IntensityMax = 1;
    public float LightRotMin = -75;
    public float LightRotMax = -25;
    
    // Use this for initialization
    void Start()
    {
        if (!ground)
            ground = gameObject.GetComponentInChildren<GroundRotator>();
        if (!worldLight)
            worldLight = gameObject.GetComponentInChildren<Light>();
    }

    public void SetGroundSpeedNorm(float value)
    {
        ground.speedX = MathUtils.Map(value, 0, 1, GroundSpeedMin, GroundSpeedMax, true);
    }

    public void SetLightIntenseNorm(float value)
    {
        worldLight.intensity = MathUtils.Map(value, 0, 1, IntensityMin, IntensityMax, true);
    }

    public void SetLightRotNorm(float value)
    {
        var rot = worldLight.transform.localRotation;
        var euler = rot.eulerAngles;
        rot.eulerAngles = new Vector3(MathUtils.Map(value, 0, 1, LightRotMin, LightRotMax, true), euler.y, euler.z);
        worldLight.transform.localRotation = rot;
    }
}
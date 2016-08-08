using UnityEngine;
using System.Collections;

public class WorldGuiController : MonoBehaviour
{
    
    public WorldCamerasController worldCams;
    public ShowController showControl;


    void Start()
    {
        if (!showControl) showControl = FindObjectOfType<ShowController>();
    }
    
    public void Reset(float value = 0)
    {
        // TODO store values and set them here
        worldCams.Reset(value);
        showControl.GetActiveWorld().Reset(value);
    }

    public void OnTerrainCamHeight(float value)
    {
        worldCams.SetNormHeight(value);
    }

    public void OnReverseWorldSpeed(bool value)
    {
        var world = showControl.GetActiveWorld();
        world.SetWorldDirection(value);
    }

    public void OnWorldSpeed(float value)
    {
        var world = showControl.GetActiveWorld();
        world.SetGroundSpeedNorm(value);
    }

    public void OnLightIntensity(float value)
    {
        var world = showControl.GetActiveWorld();
        world.SetLightIntenseNorm(value);
    }

    public void OnLightRotation(float value)
    {
        var world = showControl.GetActiveWorld();
        world.SetLightRotNorm(value);
    }

    public void OnVideoOpacity(float value)
    {
        var world = showControl.GetActiveWorld();
        world.SetVideoOpacity(value);
    }

    public void OnGroundDarkness(float value)
    {
        var world = showControl.GetActiveWorld();
        world.SetGroundBrightness(value);
    }

    public void OnBloom(float value)
    {
        worldCams.SetBloom(value);
    }

    public void OnGroundEmissive(float value)
    {
        var world = showControl.GetActiveWorld();
        world.SetGroundEmissive(value);
    }

    public void OnSkyHue(float value)
    {
        var world = showControl.GetActiveWorld();
        world.SetVideoHue(value);
    }

    public void OnSkySaturaton(float value)
    {
        var world = showControl.GetActiveWorld();
        world.SetVideoSaturation(value);
    }
}

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
        worldCams.Reset(value);
        showControl.GetActiveWorld().Reset(value);
    }

    public void OnTerrainCamHeight(float value)
    {
        worldCams.SetNormHeight(value);
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

}

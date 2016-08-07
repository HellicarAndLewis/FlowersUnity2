using UnityEngine;
using System.Collections;

public class WorldGuiController : MonoBehaviour
{
    
    public WorldCamerasController worldCams;
    public ShowController showControl;

    // Use this for initialization
    void Start()
    {
        if (!showControl) showControl = FindObjectOfType<ShowController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Terrain cam Controls
        /*
        Vector3 pos = TerrainCam.transform.position;
        TerrainCam.transform.position = new Vector3(pos.x, TerrainCamHeight, pos.z);
        TerrainCam.fieldOfView = TerrainCamFieldOfView;
        SecondaryTerrainCam.transform.position = TerrainCam.transform.position;
        SecondaryTerrainCam.fieldOfView = TerrainCam.fieldOfView;
        */
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

}

using UnityEngine;
using System.Collections;

public class WorldGuiController : MonoBehaviour
{
    
    //Terrain Camera Controls
    [Range(35, 41)]
    public float TerrainCamHeight;
    [Range(35, 100)]
    public float TerrainCamFieldOfView;
    public Camera TerrainCam;
    public Camera SecondaryTerrainCam;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        //Terrain cam Controls
        Vector3 pos = TerrainCam.transform.position;
        TerrainCam.transform.position = new Vector3(pos.x, TerrainCamHeight, pos.z);
        TerrainCam.fieldOfView = TerrainCamFieldOfView;
        SecondaryTerrainCam.transform.position = TerrainCam.transform.position;
        SecondaryTerrainCam.fieldOfView = TerrainCam.fieldOfView;
        
    }

    public void OnTerrainCamHeight(float _val)
    {
        float m = 1.0f;
        float b = 0.0f;
        TerrainCamHeight = m  *_val + b;
    }

    public void OnTerrainCamFOV(float _val)
    {
        float m = 1.0f;
        float b = 0.0f;
        TerrainCamFieldOfView = m * _val + b;
    }


}

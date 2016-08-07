using UnityEngine;
using System.Collections;

public class WorldCamerasController : MonoBehaviour
{

    public Camera primaryCam;
    public Camera secondaryCam;

    public float minHeight = 36;
    public float maxHeight = 42;
    public float minRotation = -7.6f;
    public float maxRotation = 5;

    void Start()
    {

    }
    
    public void SetNormHeight(float height)
    {
        var pos = primaryCam.transform.position;
        var rot = primaryCam.transform.rotation;
        pos.y = MathUtils.Map(height, 0, 1, minHeight, maxHeight, true);
        rot.eulerAngles = new Vector3(MathUtils.Map(height, 0, 1, minRotation, maxRotation, true), 0, 0);

        primaryCam.transform.position = pos;
        secondaryCam.transform.position = pos;
        primaryCam.transform.rotation = rot;
        secondaryCam.transform.rotation = rot;
    }
}
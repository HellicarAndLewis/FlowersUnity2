using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class WorldCamerasController : MonoBehaviour
{

    public float lerpAmount = 0.1f;

    public Camera primaryCam;
    public Camera secondaryCam;
    public BloomOptimized bloom;

    public float minHeight = 36;
    public float maxHeight = 42;
    public float targetHeight;
    public float minRotation = -7.6f;
    public float maxRotation = 5;
    public Quaternion targeRotation = Quaternion.identity;

    public float minBloom = 0;
    public float maxBloom = 2.4f;
    public float targetBloom;

    void Start()
    {

    }

    public void Reset(float value = 0)
    {
    }

    void Update()
    {
        var pos = primaryCam.transform.position;
        var rot = primaryCam.transform.rotation;
        pos.y = Mathf.Lerp(pos.y, targetHeight, lerpAmount);
        rot = Quaternion.Lerp(rot, targeRotation, lerpAmount);

        primaryCam.transform.position = pos;
        secondaryCam.transform.position = pos;
        primaryCam.transform.rotation = rot;
        secondaryCam.transform.rotation = rot;

        if (bloom) bloom.intensity = Mathf.Lerp(bloom.intensity, targetBloom, lerpAmount);
    }

    public void SetNormHeight(float height)
    {
        targetHeight = MathUtils.Map(height, 0, 1, minHeight, maxHeight, true);
        targeRotation = Quaternion.Euler(MathUtils.Map(height, 0, 1, minRotation, maxRotation, true), 0, 0);
    }

    public void SetBloom(float value)
    {
        targetBloom = MathUtils.Map(value, 0, 1, minBloom, maxBloom, true);
    }
}
using UnityEngine;
using System.Collections;

public class FlowerPopulator : MonoBehaviour
{

    public GameObject flowerModel;

    void Start()
    {
        var transforms = gameObject.GetComponentsInChildren<Transform>();
        foreach (var transform in transforms)
        {
            GameObject flowerClone = (GameObject)Instantiate(flowerModel, Vector3.zero, Quaternion.identity);
            flowerClone.transform.parent = transform;
            flowerClone.transform.localPosition = Vector3.zero;
            flowerClone.transform.localEulerAngles = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
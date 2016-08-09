using UnityEngine;
using System.Collections;

public class FlowerGardener : MonoBehaviour
{
    public int countPerMesh = 250;
    public float scaleMin = 0.5f;
    public float scaleMax = 1;
    public bool refresh = true;
    public GameObject[] flowerModels;
    public GameObject flowers;
    
    void Refresh()
    {
        if (flowers) DestroyImmediate(flowers);
        flowers = new GameObject();
        flowers.transform.parent = transform;
        var meshFilters = gameObject.GetComponentsInChildren<MeshFilter>();
        foreach (var meshFilter in meshFilters)
        {
            PopulateMesh(meshFilter);
        }
    }

    void Update()
    {
        if (refresh)
        {
            refresh = false;
            Refresh();
        }
    }
    
    void PopulateMesh(MeshFilter meshFilter)
    {
        var mesh = meshFilter.mesh;
        var baseVertices = mesh.vertices;
        var baseNormals = mesh.normals;
        var baseTriangles = mesh.triangles;
        
        int n = countPerMesh;
        for (int i = 0; i < n; i++)
        {
            /*
            var triangleI = Random.Range(0, baseTriangles.Length - 2);
                var vert1 = baseTriangles[triangleI];
                var vert2 = baseTriangles[triangleI + 1];
                var vert3 = baseTriangles[triangleI + 2];
                // points for this triangle
                var p1 = baseVertices[vert1];
                var p2 = baseVertices[vert2];
                var p3 = baseVertices[vert3];
                var avgNormal = (baseNormals[vert1] + baseNormals[vert2] + baseNormals[vert3]) / 3;

                // random point on the surface of the triangle
                var p1p2 = p2 - p1;
                var p1p32 = p3 - p1;
                
                var size = Random.Range(1, 1);
                var randomPos1 = Random.Range(0, 1);
                var randomPos2 = Random.Range(0, 1);

                var position = p1 + (p1p2 * randomPos1) + (p1p32 * (1 - randomPos2));
                */


            var position = baseVertices[Random.Range(0, baseVertices.Length)];
            position = transform.localToWorldMatrix.MultiplyPoint(position);

            var euler = (position - Vector3.zero).normalized;
            var rotation = Quaternion.FromToRotation(Vector3.up, euler);
            var flowerModel = flowerModels[Random.Range(0, flowerModels.Length)];
            GameObject flowerClone = (GameObject)Instantiate(flowerModel, position, rotation);
            //MeshRenderer renderer = flowerClone.GetComponentInChildren<MeshRenderer>();
            //renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            flowerClone.transform.parent = flowers.transform;
            var scale = Random.Range(scaleMin, scaleMax);
            flowerClone.transform.localScale = new Vector3(scale, scale, scale);
            //flowerClone.transform.localEulerAngles = Vector3.zero;
            //}
        }

        
    }
    
}
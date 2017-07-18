using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertTriangles : MonoBehaviour
{
	void Start () {
        MeshFilter mf = GetComponent<MeshFilter>();

        Mesh m = mf.mesh;
        int[] tri = m.triangles;
        for(int j = 0; j < tri.Length/3; j++)
        {
            int i = j * 3;
            int temp = tri[i + 1];
            tri[i + 1] = tri[i + 2];
            tri[i + 2] = temp;
        }

        m.triangles = tri;
        m.RecalculateBounds();

        mf.sharedMesh = m;
	}
}

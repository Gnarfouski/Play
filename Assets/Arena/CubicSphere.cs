using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicSphere : MonoBehaviour {


	// Use this for initialization
	void Start () {
        buildSphere();
	}

    private void buildSphere()
    {
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        mesh.Clear();

        float radius = 50f;
        int res = 6;

        #region Vertices		

        Vector3[] vertices = new Vector3[(res + 1) * (res + 1) * 6];

        for (int x = 0; x <= res; x++)
        {
            for (int y = 0; y <= res; y++)
            {
                vertices[y + y * x] = new Vector3(x, y, 0);
            }
        }
        for (int x = 0; x <= res; x++)
        {
            for (int y = 0; y <= res; y++)
            {
                vertices[y + y * x] = new Vector3(x, y, res);
            }
        }

        for (int z = 0; z <= res; z++)
        {
            for (int y = 0; y <= res; y++)
            {
                vertices[y + y * z] = new Vector3(0, y, z);
            }
        }
        for (int z = 0; z <= res; z++)
        {
            for (int y = 0; y <= res; y++)
            {
                vertices[y + y * z] = new Vector3(res, y, z);
            }
        }

        for (int z = 0; z <= res; z++)
        {
            for (int x = 0; x <= res; x++)
            {
                vertices[x + x * z] = new Vector3(x, 0, z);
            }
        }
        for (int z = 0; z <= res; z++)
        {
            for (int x = 0; x <= res; x++)
            {
                vertices[x + x * z] = new Vector3(x, res, z);
            }
        }


        #endregion

        #region Normales
        Vector3[] normales = new Vector3[vertices.Length];
        for (int n = 0; n < normales.Length; n++)
            normales[n] = Vector3.up;
        #endregion

        #region UVs		
        Vector2[] uvs = new Vector2[vertices.Length];
        for (int count = 0; count < 6; count++)
        {
            for (int v = 0; v <= res; v++)
            {
                for (int u = 0; u <= res; u++)
                {
                    uvs[u + v * u + count * res * res] = new Vector2(v / res, u / res);
                }
            }
        }
        #endregion

        #region Triangles
        int[] triangles = new int[res * res * 2 * 2 * 3 * 6];
        int t = 0;
        for (int face = 0; face < res * res; face++)
        {
            int i = face % res + (face / (res + 1) * res);

            triangles[t++] = i + res;
            triangles[t++] = i + 1;
            triangles[t++] = i;

            triangles[t++] = i + res;
            triangles[t++] = i + res + 1;
            triangles[t++] = i + 1;
        }
        #endregion

        mesh.vertices = vertices;
        mesh.normals = normales;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        filter.mesh = mesh;
    }
}

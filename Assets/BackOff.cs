using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackOff : MonoBehaviour {

    float count = 0;

    void Update () {
        if (count < 300)
        {
            Vector3 v = transform.localPosition;
            v.z -= 0.01f;
            transform.localPosition = v;
            count++;
        }
	}
}

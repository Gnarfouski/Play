using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    ExplosionMat mat;
    float count = 0;

	void Start () {
        mat = GetComponent<ExplosionMat>();
	}
	
	void Update () {
        if (count < 300)
        {
            if(count < 100)
            {
                mat._heat -= 0.01f;
            }
            else
            {
                mat._alpha -= 0.005f;
            }
            count++;
        }
	}
}

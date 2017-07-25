using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaFadeIn : MonoBehaviour {

    Material m;
    float count = 0;

	void Start () {
        m = GetComponent<MeshRenderer>().material;
        m.color = new Color(1, 1, 1, 0);
    }

    private void Update()
    {
        //*
        if(count < 100)
        {
            count++;
            m.color = new Color(1, 1, 1, count/100f);
        }
        //*/
    }

}

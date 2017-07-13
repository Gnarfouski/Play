using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderQueueSetter : MonoBehaviour {

	void Start () {
        GetComponent<Renderer>().material.renderQueue = 3000;
	}
}

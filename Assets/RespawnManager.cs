using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {

    public GameObject respawnObject;

	void Update () {
        if (Input.GetButtonDown("Start"))
        {
            GameObject g = GameObject.Instantiate(respawnObject, Vector3.zero, Quaternion.identity);
            g.GetComponentInChildren<Camera>().tag = "MainCamera";
            Destroy(gameObject);
        }
	}
}

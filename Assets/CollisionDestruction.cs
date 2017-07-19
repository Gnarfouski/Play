using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestruction : MonoBehaviour {

    public bool testEnter = true;
    public bool testExit = true;

    public GameObject destructionObject;

	void OnCollisionEnter (Collision col) {
        if (testEnter) ObjectDestroy(col.gameObject);
	}

    void OnCollisionExit(Collision col)
    {
        if (testExit) ObjectDestroy(col.gameObject);
    }

    private void ObjectDestroy(GameObject g)
    {
        GameObject res = GameObject.Instantiate(destructionObject, g.transform.position, g.transform.rotation);
        res.GetComponentInChildren<Camera>().tag = "MainCamera";
        Destroy(g);
    }
}

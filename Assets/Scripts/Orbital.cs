using UnityEngine;
using System.Collections;

public class Orbital : MonoBehaviour
{
    public GameObject target;
    Vector3 basePosition = new Vector3(0, 1, -3);
    public float distance = 3.0f;
    public float xStep = 1;
    public float yStep = 1;
    public float deltaSplit = 0.25f;

    bool resetOk = true;

    void LateUpdate()
    {
        if (target)
        {
            float xIn = Input.GetAxis("CamTestH");
            float yIn = Input.GetAxis("CamTestV");

            if (xIn != 0 || yIn != 0)
            {
                float x = -xIn * xStep;
                float y = yIn * yStep;

                float z = distance;

                Vector3 pos = (new Vector3(x, y, z)).normalized * distance;
                transform.localPosition = pos;
                transform.LookAt(target.transform);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);

                resetOk = false;
            }
            else 
            {
                if (!resetOk)
                {
                    resetOk = true;
                    transform.localPosition = basePosition;
                    transform.rotation = new Quaternion();
                }
            }
        }
    }
}
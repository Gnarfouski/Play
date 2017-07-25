using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

    public float rollSpeed = 1;
    public float pitchSpeed = 1;

    public float minSpeed = 0.01f;
    public float maxSpeed = 0.03f;

    public float accShift = 2;

    public GameObject target;
    public GameObject ps1, ps2;

    Image fuelGauge;
    Image plasmaGauge;

    float fuel = 100;
    float lastTimeFuelPressed = 0;
    float plasma = 100;

    public GameObject[] tailRefs;

    Vector3[] lastTail;
    float tailStartTime = 0;

    public Material mtail;

    private void Start()
    {
        fuelGauge = GameObject.FindGameObjectWithTag("Fuel").GetComponent<Image>();
        fuelGauge.fillAmount = fuel / 100;
        plasmaGauge = GameObject.FindGameObjectWithTag("Plasma").GetComponent<Image>();
        plasmaGauge.fillAmount = plasma / 100;
    }

    void Update () {
        transform.Rotate(Vector3.forward, -1 * Input.GetAxis("Horizontal") * rollSpeed);
        transform.Rotate(Vector3.left, -1 * Input.GetAxis("Vertical") * pitchSpeed);

        float accValue = Input.GetAxis("Accelerate");
        float forwardSpeed = minSpeed;

        float tailValue = Input.GetAxis("TailGen");
        if(tailValue > 0.2f)
        {
            if(lastTail == null)
            {
                lastTail = new Vector3[2];
                lastTail[0] = tailRefs[0].transform.position;
                lastTail[1] = tailRefs[1].transform.position;
                tailStartTime = Time.time;
            }
            else
            {
                if(Time.time - tailStartTime > 0.1)
                {
                    Vector3[] temp = new Vector3[4];
                    temp[0] = tailRefs[0].transform.position;
                    temp[1] = tailRefs[1].transform.position;
                    makeMesh(temp, lastTail);
                    tailStartTime = Time.time;
                    lastTail = temp;
                }
            }
        }
        else
        {
            lastTail = null;
        }

        ps1.transform.localScale = Vector3.one;
        ps2.transform.localScale = Vector3.one;

        target.transform.localPosition = new Vector3(0, 0.3f, 0);

        if (accValue != 0)
        {
            if (fuel > accValue)
            {
                fuel -= accValue;
                fuelGauge.fillAmount = fuel / 100;
                lastTimeFuelPressed = Time.time;

                ps1.transform.localScale = Vector3.one * (1 + 2 * accValue);
                ps2.transform.localScale = Vector3.one * (1 + 2 * accValue);

                target.transform.localPosition = new Vector3(0, 0.3f, -accValue * accShift);
                forwardSpeed += (maxSpeed - minSpeed) * accValue;
            }
        }
        else 
        {
            if (Time.time - lastTimeFuelPressed > 2 && fuel < 100)
            {
                fuel = Mathf.Clamp(fuel + 1, 0, 100);
                fuelGauge.fillAmount = fuel / 100;
            }
        }

        transform.Translate(Vector3.forward * forwardSpeed);
	}

    void makeMesh(Vector3[] start, Vector3[] end)
    {
        Vector3[] verts1 = new Vector3[] { start[0], start[1], end[0], end[1] };

        int[] triangles = new int[] { 0, 1, 2, 0, 2, 1, 1, 2, 3, 1, 3, 2};
        Vector2[] uv = new Vector2[] { Vector2.zero, Vector2.up, Vector2.right, Vector2.one };

        Mesh m = new Mesh();

        m.vertices = verts1;
        m.triangles = triangles;
        m.uv = uv;

        GameObject mTail = new GameObject();
        mTail.AddComponent<MeshRenderer>().material = mtail;
        mTail.AddComponent<MeshFilter>().sharedMesh = m;
        mTail.AddComponent<AlphaFadeIn>();
        GameObject.Instantiate(mTail);
    }
}

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

    public Image fuelGauge;
    public Image plasmaGauge;

    float fuel = 100;
    float lastTimeFuelPressed = 0;
    float plasma = 100;

    void Update () {
        transform.Rotate(Vector3.forward, -1 * Input.GetAxis("Horizontal") * rollSpeed);
        transform.Rotate(Vector3.left, -1 * Input.GetAxis("Vertical") * pitchSpeed);

        float accValue = Input.GetAxis("Accelerate");
        float forwardSpeed = minSpeed;

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
}

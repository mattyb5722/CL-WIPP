using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class Phase2 : MonoBehaviour {

    public static Phase2 instance = null;

    [Range(1.0f, 5.0f)]
    public float rotateRate;
    private float rotateRateScalingFactor = 25;

    private void Start() {
        if (instance == null) {
            instance = this;
        } else { Destroy(gameObject); }
    }

    public void Movement(GameObject focalPoint) {
        if (Input.GetKey(KeyCode.E)) {
            float temp = -1 * rotateRate / rotateRateScalingFactor;
            focalPoint.transform.Rotate(temp, 0f, 0f);
            float temp2 = focalPoint.transform.position.z + (temp / 2);
            float temp3 = focalPoint.transform.position.y + (temp / 2);

            focalPoint.transform.position = new Vector3(focalPoint.transform.position.x, temp3, temp2);
        }
        if (Input.GetKey(KeyCode.Q)) {
            float temp = rotateRate / rotateRateScalingFactor;
            focalPoint.transform.Rotate(temp, 0f, 0f);
            float temp2 = focalPoint.transform.position.z + (temp / 2);
            focalPoint.transform.position = new Vector3(focalPoint.transform.position.x, focalPoint.transform.position.y, temp2);
        }
        if (Input.GetKey(KeyCode.W)) {

        }
        if (Input.GetKey(KeyCode.S)) {

        }
        if (Input.GetKey(KeyCode.A)) {

        }
        if (Input.GetKey(KeyCode.D)) {

        }
    }

    public float getRotateRate() {
        return rotateRate;
    }

    public float getRotateRateScalingFactor() {
        return rotateRateScalingFactor;
    }
}

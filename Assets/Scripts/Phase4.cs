using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class Phase4 : MonoBehaviour {

    public static Phase4 instance = null;

    // private float originalCameraHeight;

    private float rotateRateScalingFactor = 25;


    private void Start() {
        if (instance == null) {
            instance = this;
        } else { Destroy(gameObject); }
    }

    public void Movement(GameObject focalPoint, float rotateRate) {
        if (focalPoint.transform.rotation.x >= -0.6427876) {
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
        } else {
            if (Input.GetKey(KeyCode.E)) {
                float temp = focalPoint.transform.position.y - (Phase2.instance.getRotateRate() / Phase2.instance.getRotateRateScalingFactor() * 4);
                float temp2 = focalPoint.transform.position.z + (Phase2.instance.getRotateRate() / Phase2.instance.getRotateRateScalingFactor() * 5);
                focalPoint.transform.position = new Vector3(focalPoint.transform.position.x, temp, temp2);
            }
            if (Input.GetKey(KeyCode.Q)) {
                float temp = focalPoint.transform.position.y + (Phase2.instance.getRotateRate() / Phase2.instance.getRotateRateScalingFactor() * 4);
                float temp2 = focalPoint.transform.position.z - (Phase2.instance.getRotateRate() / Phase2.instance.getRotateRateScalingFactor() * 5);
                focalPoint.transform.position = new Vector3(focalPoint.transform.position.x, temp, temp2);
            }
        }
    }

}

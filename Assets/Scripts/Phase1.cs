using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class Phase1 : MonoBehaviour {

    public static Phase1 instance = null;

    [Range(1.0f, 5.0f)]
    public float zoomRate;
    private float zoomRateScalingFactor = 250;

    [Range(1.0f, 5.0f)]
    public float scrollRate;
    private float scrollRateScalingFactor = 10000;

    public float maxZoom;
    public float minZoom;
    // Starting Zoom at 2

    private void Start() {
        if (instance == null) {instance = this; }
        else { Destroy(gameObject); }
    }


    public void Movement(AbstractMap mapVariable, Mapbox.Utils.Vector2d originalLatitudeLongitude) {
        float currentZoom = mapVariable.Zoom;
        float zoomDifference = 1 + (15 - currentZoom);
        Mapbox.Utils.Vector2d latitudeLongitude = mapVariable.CenterLatitudeLongitude;
        if (Input.GetKey(KeyCode.E)) {
            currentZoom += zoomRate / zoomRateScalingFactor;
            CameraMovement.instance.UpdateMap(currentZoom);
        }
        if (Input.GetKey(KeyCode.Q)) {
            currentZoom -= zoomRate / zoomRateScalingFactor;
            CameraMovement.instance.UpdateMap(currentZoom);
        }
        if (Input.GetKey(KeyCode.W)) {
            latitudeLongitude.x += scrollRate / scrollRateScalingFactor * Mathf.Pow(zoomDifference, 3);
            CameraMovement.instance.UpdateMap(latitudeLongitude);
        }
        if (Input.GetKey(KeyCode.S)) {
            latitudeLongitude.x -= scrollRate / scrollRateScalingFactor * Mathf.Pow(zoomDifference, 3);
            CameraMovement.instance.UpdateMap(latitudeLongitude);
        }
        if (Input.GetKey(KeyCode.A)) {
            latitudeLongitude.y -= scrollRate / scrollRateScalingFactor * Mathf.Pow(zoomDifference, 3);
            CameraMovement.instance.UpdateMap(latitudeLongitude);
        }
        if (Input.GetKey(KeyCode.D)) {
            latitudeLongitude.y += scrollRate / scrollRateScalingFactor * Mathf.Pow(zoomDifference, 3);
            CameraMovement.instance.UpdateMap(latitudeLongitude);
        }
        if (Input.GetKey(KeyCode.Space)) {
            CameraMovement.instance.UpdateMap(originalLatitudeLongitude);
        }
    }

    public float getMaxZoom() {
        return maxZoom;
    }

    public float getMinZoom() {
        return minZoom;
    }
}

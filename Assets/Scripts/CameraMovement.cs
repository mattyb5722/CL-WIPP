using Mapbox.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class CameraMovement : MonoBehaviour {

    public GameObject map;
    private AbstractMap mapVariable;
    public GameObject focalPoint;

    // Movement 1
    [Range(1.0f, 5.0f)]
    public float zoomRate;
    private float zoomRateScalingFactor = 250;

    [Range(1.0f, 5.0f)]
    public float scrollRate;
    private float scrollRateScalingFactor = 10000;

    public float maxZoom;
    public float minZoom;
    private Mapbox.Utils.Vector2d originalLatitudeLongitude = new Mapbox.Utils.Vector2d(32.371666666667, -103.79361111111);

    // Movement 2
    [Range(1.0f, 5.0f)]
    public float rotateRate;
    private float rotateRateScalingFactor = 25;

    // Movement 3
    private float originalCameraHeight;
    //[Range(1.0f, 5.0f)]
    //public float rotateRate;
    //private float rotateRateScalingFactor = 25;



    private int movement = 1;

    // -30

    private void Start () {
        mapVariable = map.GetComponent<AbstractMap>();
        originalCameraHeight = focalPoint.transform.position.y;
    }

    private void FixedUpdate() {
        if (movement == 1) {
            Movement1();
        } else if (movement == 2) {
            Movement2();
        } else if (movement == 3) {
            Movement3();
        }
        Transition();
    }


    private void Movement1() {
        float currentZoom = mapVariable.Zoom;
        float zoomDifference = 1 + (15 - currentZoom);
        Mapbox.Utils.Vector2d latitudeLongitude = mapVariable.CenterLatitudeLongitude;
        if (Input.GetKey(KeyCode.E)) {
            currentZoom += zoomRate / zoomRateScalingFactor;
            UpdateMap(currentZoom);
        }
        if (Input.GetKey(KeyCode.Q)) {
            currentZoom -= zoomRate / zoomRateScalingFactor;
            UpdateMap(currentZoom);
        }
        if (Input.GetKey(KeyCode.W)) {
            latitudeLongitude.x += scrollRate / scrollRateScalingFactor * Mathf.Pow(zoomDifference, 3);
            UpdateMap(latitudeLongitude);
        }
        if (Input.GetKey(KeyCode.S)) {
            latitudeLongitude.x -= scrollRate / scrollRateScalingFactor * Mathf.Pow(zoomDifference, 3);
            UpdateMap(latitudeLongitude);
        }
        if (Input.GetKey(KeyCode.A)) {
            latitudeLongitude.y -= scrollRate / scrollRateScalingFactor * Mathf.Pow(zoomDifference, 3);
            UpdateMap(latitudeLongitude);
        }
        if (Input.GetKey(KeyCode.D)) {
            latitudeLongitude.y += scrollRate / scrollRateScalingFactor * Mathf.Pow(zoomDifference, 3);
            UpdateMap(latitudeLongitude);
        }
        if (Input.GetKey(KeyCode.Space)) {
            latitudeLongitude = originalLatitudeLongitude;
            UpdateMap(latitudeLongitude);
        }
    }

    private void Movement2() {
        
        if (Input.GetKey(KeyCode.E)) {
            float temp = -1 * rotateRate / rotateRateScalingFactor;
            focalPoint.transform.Rotate(temp, 0f, 0f);
            float temp2 = focalPoint.transform.position.z + (temp/2);
            focalPoint.transform.position = new Vector3(focalPoint.transform.position.x, focalPoint.transform.position.y, temp2);
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

    private void Movement3() {

        if (Input.GetKey(KeyCode.E)) {
            float temp = focalPoint.transform.position.y - .1f;
            focalPoint.transform.position = new Vector3(focalPoint.transform.position.x, temp, focalPoint.transform.position.z);
        }
        if (Input.GetKey(KeyCode.Q)) {
            float temp = focalPoint.transform.position.y + .1f;
            focalPoint.transform.position = new Vector3(focalPoint.transform.position.x, temp, focalPoint.transform.position.z);
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

    private void UpdateMap(Mapbox.Utils.Vector2d latitudeLongitude) {
        mapVariable.SetCenterLatitudeLongitude(latitudeLongitude);
        mapVariable.UpdateMap();
    }

    private void UpdateMap(float currentZoom) {
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        mapVariable.SetZoom(currentZoom);
        mapVariable.UpdateMap();
    }

    private void UpdateMap(float currentZoom, Mapbox.Utils.Vector2d latitudeLongitude) {
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        mapVariable.SetZoom(currentZoom);
        mapVariable.SetCenterLatitudeLongitude(latitudeLongitude);
        mapVariable.UpdateMap();
    }

    private void Transition() {
        if (movement == 1) {
            if (mapVariable.Zoom >= maxZoom) {
                mapVariable.SetExtent(MapExtentType.RangeAroundCenter);
                movement = 2;
            }
        } else if (movement == 2) {
            if (focalPoint.transform.rotation.x >= 0) {
                movement = 1;
                mapVariable.SetExtent(MapExtentType.CameraBounds);
            } else if (focalPoint.transform.rotation.x <= -0.7071068) {
                movement = 3;
            }
        } else if (movement == 3) {
            if (originalCameraHeight <= focalPoint.transform.position.y) {
                movement = 2;
            }
        }
    }
}

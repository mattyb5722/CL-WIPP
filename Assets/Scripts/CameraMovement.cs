using Mapbox.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour {

    public static CameraMovement instance = null;

    public GameObject map;
    private AbstractMap mapVariable;

    public GameObject focalPoint;
    public GameObject frontCamera;
    public GameObject panoCamera;

    public Canvas fog;
    public GameObject boarder;

    private Mapbox.Utils.Vector2d originalLatitudeLongitude;
    
    private int phase = 1;

    private void Start () {
        if (instance == null) { instance = this;
        } else { Destroy(gameObject); }
        mapVariable = map.GetComponent<AbstractMap>();
        originalLatitudeLongitude = mapVariable.CenterLatitudeLongitude;
        // originalCameraHeight = focalPoint.transform.position.y;
        StartCoroutine(Transition());
    }

    private void FixedUpdate() {
        if (phase == 1) {
            Phase1.instance.Movement(mapVariable, originalLatitudeLongitude);
        } else if (phase == 2) {
            Phase2.instance.Movement(focalPoint);
        } else if (phase == 3) {
            Phase3.instance.Movement();
        } else if (phase == 4) {
            Phase4.instance.Movement(focalPoint, Phase2.instance.rotateRate);
        }
    }

    private IEnumerator Transition() {
        while (true) {
            if (phase == 1) {     
                if (mapVariable.Zoom >= Phase1.instance.getMaxZoom()) {                 
                    mapVariable.SetExtent(MapExtentType.RangeAroundCenter);
                    fog.GetComponent<ImageFade>().FadeImage();
                    yield return new WaitForSeconds(1);
                    frontCamera.gameObject.SetActive(!frontCamera.gameObject.activeSelf);
                    panoCamera.gameObject.SetActive(!panoCamera.gameObject.activeSelf);
                    fog.GetComponent<ImageFade>().FadeImage();
                    yield return new WaitForSeconds(1);
                    boarder.GetComponent<Animator>().SetTrigger("FadeIn");
                    phase = 2;
                }
            } else if (phase == 2) {
                // 90 degree:   -0.7071068
                // 80 degree:   -0.6427876
                // 70 degree:   -0.5735764
                // 60 degree:   -0.5
                if (focalPoint.transform.rotation.x <= -0.5) {
                    Phase3.instance.UI.gameObject.SetActive(!Phase3.instance.UI.gameObject.activeSelf);
                    Phase3.instance.berm.SetActive(!Phase3.instance.berm.activeSelf);
                    Phase3.instance.testbed.SetActive(!Phase3.instance.testbed.activeSelf);
                    Phase3.instance.thorns.SetActive(!Phase3.instance.thorns.activeSelf);

                    phase = 3;
                }
            } else if (phase == 3) {
                if (Phase3.instance.next == true) {
                    Phase3.instance.UI.gameObject.SetActive(!Phase3.instance.UI.gameObject.activeSelf);
                    Phase3.instance.berm.SetActive(!Phase3.instance.berm.activeSelf);
                    Phase3.instance.testbed.SetActive(!Phase3.instance.testbed.activeSelf);
                    Phase3.instance.thorns.SetActive(!Phase3.instance.thorns.activeSelf);


                    foreach (Transform child in map.transform) {
                        //child is your child transform
                        if (child.name == "15/6935/13268" || child.name == "15/6936/13268" || child.name == "15/6937/13268") {
                            child.gameObject.SetActive(false);
                        }
                    }
                    






                    phase = 4;
                }
            }
            yield return null;
        }
    }

    public void UpdateMap(Mapbox.Utils.Vector2d latitudeLongitude) {
        mapVariable.SetCenterLatitudeLongitude(latitudeLongitude);
        mapVariable.UpdateMap();
    }

    public void UpdateMap(float currentZoom) {
        currentZoom = Mathf.Clamp(currentZoom, Phase1.instance.getMinZoom(), Phase1.instance.getMaxZoom());
        mapVariable.SetZoom(currentZoom);
        mapVariable.UpdateMap();
    }

    public void UpdateMap(float currentZoom, Mapbox.Utils.Vector2d latitudeLongitude) {
        currentZoom = Mathf.Clamp(currentZoom, Phase1.instance.getMinZoom(), Phase1.instance.getMaxZoom());
        mapVariable.SetZoom(currentZoom);
        mapVariable.SetCenterLatitudeLongitude(latitudeLongitude);
        mapVariable.UpdateMap();
    }
}

using Mapbox.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MapboxAccess.Instance.ClearAllCacheFiles();
    }
    private void Update() {
        if (Input.GetKey("W")) {
            print("W");
        }
    }
}

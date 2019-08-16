using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class Phase3 : MonoBehaviour {

    public static Phase3 instance = null;

    public Canvas UI;

    public bool next = false;

    public GameObject berm;
    private List<GameObject> bermParts = new List<GameObject>();

    public GameObject testbed;
    private List<GameObject> testbedParts = new List<GameObject>();

    public GameObject thorns;
    private List<GameObject> thornsParts = new List<GameObject>();

    private string model = "";

    private void Start() {
        if (instance == null) { instance = this; } 
        else { Destroy(gameObject); }

        foreach (Transform child in berm.transform) {
            bermParts.Add(child.GetChild(0).gameObject);
        }

        foreach (Transform child in testbed.transform) {
            testbedParts.Add(child.GetChild(0).gameObject);
        }

        foreach (Transform child in thorns.transform) {
            thornsParts.Add(child.GetChild(0).gameObject);
        }
    }

    public void Movement() {
        if (Input.GetKey(KeyCode.E)) {
            if (model.Equals("Berm")) {
                Color color = bermParts [0].GetComponent<Renderer>().material.GetColor("_Color");
                color.a += .01f;

                foreach (GameObject temp in bermParts) {
                    Renderer r = temp.GetComponent<Renderer>();
                    if (color.a <= 255) {
                        r.material.SetColor("_Color", color);
                    }
                }
            }else if (model.Equals("Testbed")) {
                Color color = testbedParts [0].GetComponent<Renderer>().material.GetColor("_Color");
                color.a += .01f;

                foreach (GameObject temp in testbedParts) {
                    Renderer r = temp.GetComponent<Renderer>();
                    if (color.a <= 255) {
                        r.material.SetColor("_Color", color);
                    }
                }
            } else if (model.Equals("Thorns")) {
                Color color = thornsParts [0].GetComponent<Renderer>().material.GetColor("_Color");
                color.a += .01f;

                foreach (GameObject temp in thornsParts) {
                    Renderer r = temp.GetComponent<Renderer>();
                    if (color.a <= 255) {
                        r.material.SetColor("_Color", color);
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.Q)) {
            if (model.Equals("Berm")) {
                Color color = bermParts [0].GetComponent<Renderer>().material.GetColor("_Color");
                color.a -= .05f;

                foreach (GameObject temp in bermParts) {
                    Renderer r = temp.GetComponent<Renderer>();
                    if (color.a >= 0) {
                        r.material.SetColor("_Color", color);
                    }
                }
            } else if (model.Equals("Testbed")) {
                Color color = testbedParts [0].GetComponent<Renderer>().material.GetColor("_Color");
                color.a -= .05f;

                foreach (GameObject temp in testbedParts) {
                    Renderer r = temp.GetComponent<Renderer>();
                    if (color.a >= 0) {
                        r.material.SetColor("_Color", color);
                    }
                }
            } else if (model.Equals("Thorns")) {
                Color color = thornsParts [0].GetComponent<Renderer>().material.GetColor("_Color");
                color.a -= .05f;

                foreach (GameObject temp in thornsParts) {
                    Renderer r = temp.GetComponent<Renderer>();
                    if (color.a >= 0) {
                        r.material.SetColor("_Color", color);
                    }
                }
            }
        }
    }

    public void setModel(string model) {
        this.model = model;
    }

    public void setNext() {
        next = true;
    }
}

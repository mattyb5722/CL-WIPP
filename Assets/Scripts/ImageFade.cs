using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFade : MonoBehaviour {

    private Image [] imgs;
    private bool faded = false;

    public void Start() {
        imgs = GetComponentsInChildren<Image>();
    }

    public void FadeImage() {
        StartCoroutine(Fade(faded));
        faded = !faded;
    }

    public IEnumerator Fade(bool fadeAway) {
        // fade to transparent
        if (fadeAway) {
            for (float i = 1; i >= 0; i -= Time.deltaTime) {
                foreach (Image img in imgs) {
                    img.color = new Color(0, 0, 0, i);
                }
                yield return null;
            }
        }
        // fade from transparent
        else {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime) {
                foreach (Image img in imgs) {
                    img.color = new Color(0, 0, 0, i);
                }
                yield return null;
            }
        }
    }
}
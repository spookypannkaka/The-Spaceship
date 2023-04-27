using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualRestart : MonoBehaviour
{
    [SerializeField] Image timerImage;

    void Start() {
        timerImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("f")) {
            IncreaseTime(timerImage);
        }

        if (Input.GetKeyUp("f")) {
            ResetTime(timerImage);
        }
    }

    float IncreaseTime(Image image) {
        image.fillAmount += Time.deltaTime;
        return image.fillAmount;
    }

    float ResetTime(Image image) {
        image.fillAmount = 0;
        return image.fillAmount;
    }
}

using System.Collections;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

    public Transform[] transforms;
    public float lerpTime;

    private int length;
    private int curIndex;
    private Transform originalTransform;
    private bool lerping = false;

    void Start() {
        length = transforms.Length;
        curIndex = 0;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab) && !lerping) {
            SwitchPosition();
        }
    }

    void SwitchPosition() {
        originalTransform = this.gameObject.transform;
        Transform newTransform = transforms[curIndex];
        Debug.Log(newTransform.gameObject.name + ": " + newTransform.localPosition);
        lerping = true;
        StartCoroutine(LerpPosition(Time.time, originalTransform.localPosition, newTransform.localPosition));
        //Debug.Log(newTransform.position);
        StartCoroutine(LerpRotation(Time.time, originalTransform.rotation, newTransform.rotation));
        curIndex++;
        if (curIndex >= length) curIndex = 0;
    }

    IEnumerator LerpPosition(float startTime, Vector3 originalPosition, Vector3 newPosition) {
        while (Time.time - startTime <= lerpTime) {
            this.gameObject.transform.localPosition = Vector3.Lerp(originalPosition, newPosition, (Time.time - startTime) / lerpTime);
            yield return new WaitForSeconds(0.02f);
        }
        lerping = false;
    }
    IEnumerator LerpRotation(float startTime, Quaternion originalRotation, Quaternion newRotation) {
        while (Time.time - startTime <= lerpTime) {
            this.gameObject.transform.rotation = Quaternion.Lerp(originalRotation, newRotation, (Time.time - startTime) / lerpTime);
            yield return new WaitForSeconds(0.02f);
        }
        lerping = false;
    }


}

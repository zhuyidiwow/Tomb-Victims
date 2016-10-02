using UnityEngine;
using System.Collections;

public class DialogManager : MonoBehaviour {

	public GameObject[] dialog;

    void Awake() {
		foreach (GameObject gameObject in dialog) {
            gameObject.SetActive(false);
        }
    }

    IEnumerator DialogCoroutine() {
        dialog[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        dialog[0].SetActive(false);
        dialog[1].SetActive(true);
        yield return new WaitForSeconds(1f);
		foreach (GameObject gameObject in dialog) {
            gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    public void StartDialog() {
        StartCoroutine(DialogCoroutine());
    }

}

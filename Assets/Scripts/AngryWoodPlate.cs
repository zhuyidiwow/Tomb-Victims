using UnityEngine;

public class AngryWoodPlate : MonoBehaviour {


    void Update() {
        //
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            GetComponent<Rigidbody>().velocity = new Vector3 (0f, 130f, 0f);
            Debug.Log(gameObject + "ahh I found a human");
        }
    }
}

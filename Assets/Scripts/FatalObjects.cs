using UnityEngine;
using System.Collections;

public class FatalObjects : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Player>().Die();
        }
    }
}

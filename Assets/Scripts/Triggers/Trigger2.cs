using UnityEngine;


public class Trigger2 : MonoBehaviour{

    public SoundManager soundManager;

    private GameManager gm;

	void Start() {
        gm = Utility.GetGameManager();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            soundManager.SwitchToNormalBGM();
            gm.Win();
        }
    }
}

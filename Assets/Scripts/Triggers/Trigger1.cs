using UnityEngine;


public class Trigger1 : MonoBehaviour{

    public GameObject light;
    public GameObject spotLight;
    public Zombie[] zombies;
    public SoundManager soundManager;
    public GameObject dialogCanvas;
    public DialogManager dialogManager;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            light.SetActive(false);
            spotLight.SetActive(true);
            foreach (Zombie zombie in zombies) {
                zombie.WakeUp();
            }
            soundManager.SwitchToChasingBGM();
            dialogCanvas.SetActive(true);
            dialogManager.StartDialog();
        }
    }
}

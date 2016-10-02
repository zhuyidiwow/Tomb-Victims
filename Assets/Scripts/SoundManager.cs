using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip chasingBGM;
    public AudioClip normalBGM;
	
	public void SwitchToChasingBGM() {
        GetComponent<AudioSource>().clip = chasingBGM;
        GetComponent<AudioSource>().Play();
    }

    public void SwitchToNormalBGM() {
        GetComponent<AudioSource>().clip = normalBGM;
        GetComponent<AudioSource>().Play();
    }


}

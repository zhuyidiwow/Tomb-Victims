using System.Collections;
using UnityEngine;

public class Zombie : MonoBehaviour {
    public AudioClip roar;
    public bool canDetect = true;

	public float moveSpeed = 5f;
    private float moveForce = 100f;

    private Player player;
    private Transform playerTransform;

    private float detectionRange = 5f;

    private bool awake = false;

    void Awake() {
        player = Utility.GetPlayer();
        playerTransform = player.gameObject.transform;
        StartCoroutine(Roar());
    }

    void Update() {
        DetectPlayer();
    }

    void FixedUpdate() {
        if(awake) {
            ChasePlayer();
        }
    }

    void ChasePlayer() {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 moveDirection = (playerTransform.position - this.transform.position).normalized;
        if (rb.velocity.magnitude < moveSpeed) {
            rb.AddForce(moveDirection * moveForce);
        }
        this.transform.LookAt(playerTransform);
    }

    IEnumerator Roar() {
        while (true) {
            if (awake) {
                GetComponent<AudioSource>().clip = roar;
                GetComponent<AudioSource>().Play();
            }
            yield return new WaitForSeconds(Random.value * 5f);
        }
    }

    void DetectPlayer() {
        if (canDetect) {
            if ((playerTransform.position - this.transform.position).magnitude < detectionRange) {
                WakeUp();
            }
        }
    }
    public void WakeUp() {
        awake = true;
    }
}

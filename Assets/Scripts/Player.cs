using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    public float turnSpeed;
    public float turnForce;

    public float maxSpeed;
    public float moveForce;

    public AudioClip[] footStep;
    public AudioClip deathAudio;

    public GameManager gm;
    private bool alive = true;

    void Start() {
        gm = Utility.GetGameManager();
        StartCoroutine(FootStep());
    }

    void FixedUpdate() {
        MoveForward();
        Turn();
        Fall();
    }

    void MoveForward() {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb.velocity.z < maxSpeed) {
            rb.AddForce(Vector3.forward * moveForce);
        }

        if (rb.velocity.z >= maxSpeed) {
            rb.velocity =
            new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
        }
    }

    void Turn() {
        float h = Input.GetAxis("Horizontal");
        Rigidbody rb = GetComponent<Rigidbody>();

        if (h != 0 && Mathf.Abs(rb.velocity.x) < turnSpeed) {
            rb.AddForce(Vector3.right * h * turnForce);

        }

        if (Mathf.Abs(rb.velocity.x) >= turnSpeed) {
            rb.velocity =
            new Vector3(Mathf.Sign(rb.velocity.x) * turnSpeed, rb.velocity.y, rb.velocity.z);
        }
    }

    void Fall() {
        GetComponent<Rigidbody>().AddForce(Vector3.down * 100f);
    }

    IEnumerator FootStep() {
        while (alive) {
            GetComponent<AudioSource>().clip = footStep[Random.Range(0, footStep.Length)];
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.4f);
        }
    }
    IEnumerator DieCoroutine() {
        GetComponent<AudioSource>().clip = deathAudio;
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        gm.Defeat();
    }

    public void Die() {
        alive = false;
        StopCoroutine(FootStep());
        StartCoroutine(DieCoroutine());
    }

}

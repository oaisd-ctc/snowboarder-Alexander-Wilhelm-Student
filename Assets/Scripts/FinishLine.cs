using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{

    [SerializeField] float reloadDelay = 2;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] AudioClip finishSFX;

    [SerializeField] float slowFactor;
    bool finished = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (!finished && other.tag == "Player") {
            Debug.Log("LETS FUCKING GOOOOOOO");
            Invoke("ReloadScene", reloadDelay);
            finishEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(finishSFX);
            finished = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().alive = false;

            Rigidbody2D rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
            //rb.AddForce(rb.velocity * -slowFactor);

            rb.velocity = rb.velocity * slowFactor;
            Debug.Log($"POS: {rb.position} VEL: {rb.velocity} TOTAL: {rb.velocity * -slowFactor}");
        }
        
    }

    void ReloadScene() {
        SceneManager.LoadScene("Scenes/level1");
    }
}

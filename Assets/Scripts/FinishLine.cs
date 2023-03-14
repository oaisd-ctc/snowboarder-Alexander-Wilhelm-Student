using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{

    [SerializeField] float reloadDelay = 2;
    [SerializeField] ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("LETS FUCKING GOOOOOOO");
            Invoke("ReloadScene", reloadDelay);
            finishEffect.Play();
        }
        
    }

    void ReloadScene() {
        SceneManager.LoadScene("Scenes/level1");
    }
}

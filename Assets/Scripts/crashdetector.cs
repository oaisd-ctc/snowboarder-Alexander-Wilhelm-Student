using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crashdetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 2;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    public Collider2D crashTrigger;
    public LayerMask crashLayer;

    bool dying = false;

    private void OnTriggerEnter2D(Collider2D other) { //instead of using just the other object's tag, we specify a collider on the gameobject to get more precise information about the collision
        if (!dying && crashTrigger.IsTouchingLayers(crashLayer)) { // this also lets us specify exactly which trigger should do the colliding
            //Debug.Log("dumbass");
            
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", reloadDelay);
            dying = true;
            GetComponent<PlayerController>().alive = false;
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene("Scenes/level1");
    }
}

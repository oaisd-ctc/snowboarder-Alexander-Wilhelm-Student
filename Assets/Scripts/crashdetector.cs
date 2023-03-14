using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crashdetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 2;
    [SerializeField] ParticleSystem crashEffect;
    public Collider2D crashTrigger;
    public LayerMask crashLayer;

    private void OnTriggerEnter2D(Collider2D other) { //instead of using just the other object's tag, we specify a collider on the gameobject to get more precise information about the collision
        if (crashTrigger.IsTouchingLayers(crashLayer)) { // this also lets us specify exactly which trigger should do the collid
            Debug.Log("dumbass");
            Invoke("ReloadScene", reloadDelay);
            crashEffect.Play();
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene("Scenes/level1");
    }
}

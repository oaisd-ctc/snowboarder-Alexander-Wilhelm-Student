using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] Vector2 offset;
    [SerializeField] ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            particles.Play();
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        particles.transform.position = other.GetContact(0).point + offset; //send trail to contact point
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            particles.Stop();
        }
    }
}

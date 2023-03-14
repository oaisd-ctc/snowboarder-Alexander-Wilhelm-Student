using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    public float torqueMult;

    public Collider2D boostGroundTrigger;

    public Collider2D boostCheckGroundTrigger;

    public Collider2D boardCollider;

    public float boostForce;

    public float brakeDownforce;

    public float defaultMoveSpeed = 26;

    SurfaceEffector2D[] surfaceEffectors;

    LayerMask ground;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = LayerMask.GetMask("Ground");
        surfaceEffectors = FindObjectsOfType<SurfaceEffector2D>(); // don't get mad at me for using FindObjectsOfType instead of just FindObjectOfType, i NEED that loop-de-loop.
                                                                    // if anything it's COOLER because it works with arrays (and less performant but we don't talk about that)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddTorque(torqueMult * -Input.GetAxis("Horizontal"));

        if (boostGroundTrigger.IsTouchingLayers(ground) && boardCollider.IsTouchingLayers(ground) &! boostCheckGroundTrigger.IsTouchingLayers(ground) &! Input.GetKey(KeyCode.DownArrow)) { //phew!
            rb.AddForce(new Vector2(boostForce, 0));
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            foreach (SurfaceEffector2D i in surfaceEffectors) {
                i.speed = 0;
            }
        rb.AddForce(new Vector2(0, brakeDownforce));
        } else {
            foreach (SurfaceEffector2D i in surfaceEffectors) {
                i.speed = defaultMoveSpeed;
            }
        }
    }
}

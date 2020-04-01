using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float playerAngle = 0.0f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 lastMovement;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            lastMovement = movement;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        float angle = Mathf.Atan2(lastMovement.y, lastMovement.x) * Mathf.Rad2Deg - 90f;
        playerAngle = angle + 90f;
	}

    public float getAngle() {
        return playerAngle;
	}
}

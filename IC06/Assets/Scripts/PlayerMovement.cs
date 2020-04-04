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


    public string movUp = "z";
    public string movDown = "s";
    public string movRight = "d";
    public string movLeft = "q";


    // Update is called once per frame
    void Update()
    {
        // Input
        //movementFromAxis();
        movementFromKeys();

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

    public void movementFromAxis() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            lastMovement = movement;
	}

    public void movementFromKeys() {
        movement.x = (Input.GetKey(movRight) ? 1 : 0) - (Input.GetKey(movLeft) ? 1 : 0);
        movement.y = (Input.GetKey(movUp) ? 1 : 0) - (Input.GetKey(movDown) ? 1 : 0);
        if(Input.GetKey(movRight) || Input.GetKey(movLeft) || Input.GetKey(movUp) || Input.GetKey(movDown))
            lastMovement = movement;
	}
}

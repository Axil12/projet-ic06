using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum NumPlayer
    {
       P1,
       P2
    }

    public NumPlayer numPlayer;
    public float moveSpeed = 2.5f;
    public float playerAngle = 0.0f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 lastMovement;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        if (!GameManagerScript.instance.pause)
        {
            // Input P1
            if (numPlayer == NumPlayer.P1)
            {
                movement.x = Input.GetAxisRaw("P1 - Horizontal");
                movement.y = Input.GetAxisRaw("P1 - Vertical");
                if (Input.GetAxisRaw("P1 - Horizontal") != 0 || Input.GetAxisRaw("P1 - Vertical") != 0)
                    lastMovement = movement;

                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);
            }

            // Input P2
            if (numPlayer == NumPlayer.P2)
            {
                movement.x = Input.GetAxisRaw("P2 - Horizontal");
                movement.y = Input.GetAxisRaw("P2 - Vertical");
                if (Input.GetAxisRaw("P2 - Horizontal") != 0 || Input.GetAxisRaw("P2 - Vertical") != 0)
                    lastMovement = movement;

                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);
            }
        }

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

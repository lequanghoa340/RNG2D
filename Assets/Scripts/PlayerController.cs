using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public Rigidbody2D rb;
    [SerializeField] private Vector2 movement;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (movement.x > 0  || movement.y > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("isRun", true);

        }
        else if (movement.x < 0 || movement.y < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool facingRight = true;
    public bool facingUp = true;
    public Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Movement_X", movement.x);
        //anim.SetFloat("Movement_Y", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        Debug.Log(movement.sqrMagnitude);
      if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        if(movement.x < 0 && facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}

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
    public Quaternion right;
    public Quaternion left;
    public Quaternion up;
    public Quaternion down;
    public Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        up = new Quaternion(0f, 0f, 90f, 0f);
        down = new Quaternion(0f, 0f, -90f, 0f);
        left = new Quaternion(0f, 0f, 180f, 0f);
        right = new Quaternion(0f, 0f, 0f, 0f);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Movement_X", movement.x);
        anim.SetFloat("Movement_Y", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
/*        if (movement.x > 0)
        {

        }
        if(movement.x < 0)
        {

        }
        if(movement.y > 0)
        {

        }
        if(movement.y > 0)
        {

        }*/
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
    public void Flip()
    {
        transform.Rotate(0f, 0f, 180f);
        facingRight = !facingRight;
    }
    public void FacingUp()
    {
        transform.Rotate(0f, 0f, 90f);
        facingUp = !facingUp;
    }
}

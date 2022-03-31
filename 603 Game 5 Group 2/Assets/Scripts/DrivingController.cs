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
    // Start is called before the first frame update
    void Awake()
    {
        up = new Quaternion(0f, 0f, 90f, 0f);
        down = new Quaternion(0f, 0f, -90f, 0f);
        left = new Quaternion(0f, 0f, 180f, 0f);
        right = new Quaternion(0f, 0f, 0f, 0f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

/*        if (movement.x > 0)
        {
            transform.rotation = right;
        }
        if(movement.x < 0)
        {
            transform.rotation = left;
        }
        if(movement.y > 0)
        {
            transform.rotation = down;
        }
        if(movement.y > 0)
        {
            transform.rotation = up;
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

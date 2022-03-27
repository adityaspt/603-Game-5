using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float inputHorizontal;
    private float inputVertical;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if(inputHorizontal != 0 || inputVertical != 0)
        {
            rb.velocity = new Vector2 (inputHorizontal * speed, inputVertical * speed);
        }
        else
        {
            rb.velocity = new Vector2(0f,0f);
        }
    }
}

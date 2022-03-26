using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Variables")]
    [SerializeField]
    [Range(0f, 15f)]
    private float moveSpeed;

    public Animator playerAnimator;

    private Rigidbody2D rdb2;

    private Vector2 movement;

    private void Awake()
    {
        rdb2 = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    float x = 0;
    float y = 0;

    [SerializeField]
    float lastX = 0; //To check if current x value has changed from last
    [SerializeField]
    float lastY = 0; //To check if current y value has changed from last

    [SerializeField]
    bool isFacingUp, isFacingRight, isFacingLeft = false;

    bool isFacingDown = true;

    // Update is called once per frame
    void Update()
    {
        //Get x and y axis movement -1 to 1 range
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        //Animator with x and y values and speed of player movement
        playerAnimator.SetFloat("dirX", movement.x);
        playerAnimator.SetFloat("dirY", movement.y);
        playerAnimator.SetFloat("Speed", movement.sqrMagnitude);

        string LastKeyUsed = ""; //will know which axis was changed

        if (x != lastX) //if current x value has changed, we set the last used axis to X and set lastX to current x value
        {
            LastKeyUsed = "X";
            lastX = x;
        }
        if (y != lastY) //if current y value has changed, we set the last used axis to Y and set lastY to current y value
        {
            LastKeyUsed = "Y";
            lastY = y;     
        }
        if (x != 0 && y == 0) //In case you stop using the last key and have still an other key pressed, you come back to the other key axis
        {
            LastKeyUsed = "X";
        }
        if (x == 0 && y != 0)
        {
            LastKeyUsed = "Y";
        }

        if (LastKeyUsed == "X") //Then we check which axis was last used, and we set movement x and y value depending on the result
        {
            movement.x = x;
            movement.y = 0;
        }
        else if (LastKeyUsed == "Y")
        {
            movement.x = 0;
            movement.y = y;
        }
    }


    private void FixedUpdate()
    {
        //Movement code
        rdb2.MovePosition(rdb2.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

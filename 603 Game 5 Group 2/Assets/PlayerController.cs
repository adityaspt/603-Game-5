using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Variables")]
    [SerializeField]
    [Range(0f, 15f)]
    private float moveSpeed;

    private Rigidbody2D rdb2;

    private Vector2 movement;

    private void Awake()
    {
        rdb2 = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //Movement code
        rdb2.MovePosition(rdb2.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

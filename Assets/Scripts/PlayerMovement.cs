using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity = Vector2.zero;
    private Rigidbody2D rb;
    private void Awake()
    {
      rb = gameObject.GetComponent<Rigidbody2D>();  

    }
    // Start is called before the first frame update
    private void Start()
    {
        rb.velocity = initialVelocity;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x,10f);
        }

        float xVal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xVal * 7f, rb.velocity.y);
    }
}

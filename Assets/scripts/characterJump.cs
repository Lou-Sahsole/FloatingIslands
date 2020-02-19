using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterJump : MonoBehaviour
{
    public float fallMultiplier = 2f;
    public float lowJumpMultiplier = 5f;
    public float jumpVelocity = 20f;

    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public static bool isGrounded;
    public static int jumpProgress;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown ("Jump") && isGrounded == true)
        {
            rigidbody2d.velocity += (Vector2.up * jumpVelocity);
            jumpProgress = 1;
        }


        if (rigidbody2d.velocity.y < 0)
        {
            rigidbody2d.velocity += (Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
            jumpProgress = 2;
        }
        else if (rigidbody2d.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidbody2d.velocity += (Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
            jumpProgress = 2;
        }
    }
}

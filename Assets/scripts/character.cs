using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    //Character Stats
    public float speed = 50f;
    float currentDamage = 0;
    public float timeInvincible = 0.3f;
    bool isInvincible;
    float invincibleTimer;
    bool m_FacingRight = true;

    Rigidbody2D rigidbody2d;
    public Animator animator;

    float move = 0f;
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)]    [SerializeField]    private float m_MovementSmoothing = .05f;

    // Start is called before the first frame update
    void Awake()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        move = (Input.GetAxisRaw("Horizontal") * speed);

        if (move > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (move < 0 && m_FacingRight)
        {
            Flip();
        }

        // Animations
        animator.SetFloat("speed", Mathf.Abs(move));
        animator.SetInteger("jumpProgress", characterJump.jumpProgress);
        
        // Health
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }

    void FixedUpdate()
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f * Time.deltaTime, rigidbody2d.velocity.y);
        // And then smoothing it out and applying it to the character
        rigidbody2d.velocity = Vector3.SmoothDamp(rigidbody2d.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    public void ChangeDamage(int amount)
    {
        if (amount > 0)
        {
            if (isInvincible)
            {
                return;
            }

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        double roundedDamage = (Mathf.Round(currentDamage * 32 / 100)) / 32;
        UIDamageBar.instance.SetValue((float)roundedDamage);

        currentDamage = Mathf.Clamp(currentDamage + amount, 0, 100);
        Debug.Log(currentDamage + "%");
    }

    void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    internal static float GetComponent(float x)
    {
        throw new NotImplementedException();
    }
}

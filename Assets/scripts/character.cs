using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    public float speed = 5f;
    float currentDamage = 0;

    public float timeInvincible = 0.5f;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Awake()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalR = Input.GetAxis("Horizontal");

        Vector2 position = rigidbody2d.position;
        position.x += speed * horizontalR * Time.deltaTime;
        transform.position = position;

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
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

    internal static float GetComponent(float x)
    {
        throw new NotImplementedException();
    }
}

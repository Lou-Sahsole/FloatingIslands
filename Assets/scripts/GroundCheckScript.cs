using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        characterJump GroundCheck = other.GetComponent<characterJump>();
        if (GroundCheck == null)
        {
            characterJump.isGrounded = true;
            characterJump.jumpProgress = 3;
            //Debug.Log("Grounded");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        characterJump GroundCheck = other.GetComponent<characterJump>();
        if (GroundCheck == null)
        {
            characterJump.isGrounded = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public int campfireDamage = 30;

    void OnTriggerStay2D(Collider2D other)
    {
        character controller = other.GetComponent<character>();
        if (controller != null)
        {
            controller.ChangeDamage(campfireDamage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessCollision(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessCollision(collision.gameObject);
    }

    void ProcessCollision(GameObject collider)
    {
        if ( collider.CompareTag("Damage") )
        {
            DoDamageToPlayer();
        }
    }
    // Testing Collisions
    void DoDamageToPlayer()
    {
        Debug.Log("HIT!");
    }
}

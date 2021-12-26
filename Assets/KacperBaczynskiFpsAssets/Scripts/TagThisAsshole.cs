using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagThisAsshole : MonoBehaviour
{
    public float health = 50f;

    public void ThisALotDamage (float amountOf)
    {
        health -= amountOf;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die ()
    {
        Destroy(gameObject);
    }
  
}

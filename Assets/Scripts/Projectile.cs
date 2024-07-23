using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool grounded = false;
    private void OnCollisionEnter(Collision collision)
    {
        //If the projectile touches the Ground layer
        if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}

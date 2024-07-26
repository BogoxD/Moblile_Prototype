using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPiece : MonoBehaviour
{
    private Wall parent;
    private Rigidbody rb;

    void Start()
    {
        parent = transform.parent.GetComponent<Wall>();

        //setup RigidBody
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

    }
    private void LateUpdate()
    {
        if (parent.currentHp <= 0)
        {
            rb.isKinematic = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.impulse.magnitude >= parent.breakFroce && collision.transform.CompareTag("Projectile"))
        {
            Collider[] wallpieces = Physics.OverlapSphere(collision.transform.position, parent.breakRadius);

            for (int i = 0; i < wallpieces.Length; i++)
            {
                if (wallpieces[i].TryGetComponent<Rigidbody>(out Rigidbody piece))
                {
                    piece.isKinematic = false;
                    piece.AddForce(collision.impulse * 0.1f, ForceMode.Impulse);

                    Destroy(collision.gameObject, 0.1f);
                }
            }
        }

    }
}

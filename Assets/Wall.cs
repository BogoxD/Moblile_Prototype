using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float breakFroce = 1f;
    public float breakRadius = 0.2f;

    [SerializeField] public int maxHp;
    [HideInInspector] public int currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            currentHp--;
        }
    }
    private void FixedUpdate()
    {
        if(currentHp <= 0)
        {
            Destroy(gameObject, 10f);
        }
    }
}

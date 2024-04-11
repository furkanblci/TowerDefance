using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    public GameObject ımpactEffect;
    public float damageAmount;

    private bool hasDamaged;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * moveSpeed;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !hasDamaged)
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damageAmount);
            hasDamaged = true;

        }
        
        
        //Instantiate(ımpactEffect, transform.position, Quaternion.identity);  //ımpact effect şuanda yok ypaıldığında kod etkinleştirilecek
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

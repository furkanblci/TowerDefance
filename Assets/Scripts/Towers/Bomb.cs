using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform pivot,model;
    public float moveSpeed;
    //public Transform target;
    [HideInInspector] 
    public Vector3 targetPoint;

    public GameObject explodeEffect;
    public float damageAmount;
    public LayerMask whatIsEnemy;
    public float explodeRange;
    
    void Start()
    {
        Vector3 startPosition = transform.position;
        
        //targetPoint = target.position;

        Vector3 centerPosition = (transform.position + targetPoint) * 0.5f;
        transform.position = centerPosition;

        transform.right = targetPoint - transform.position;

        model.transform.position = startPosition;
    }


    void Update()
    {
        pivot.localRotation = Quaternion.RotateTowards(pivot.localRotation, Quaternion.Euler(0f, 0f, 180f),
            moveSpeed * Time.deltaTime);
        model.rotation=Quaternion.identity;

        if (Vector3.Distance(model.position,targetPoint) < 0.1f)
        {

           Collider[] collidersInRange = Physics.OverlapSphere(transform.position, explodeRange,whatIsEnemy);

           foreach (Collider col in collidersInRange)
           {
               col.GetComponent<EnemyHealthController>().TakeDamage(damageAmount);
           }
           
           if (explodeEffect != null)
           {
                Instantiate(explodeEffect, model.position, Quaternion.identity); 
           }
            
           Destroy(gameObject);
            
            
        }
    }
}

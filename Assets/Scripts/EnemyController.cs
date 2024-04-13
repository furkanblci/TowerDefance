using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private float moveSpeed=3.5f;
    [HideInInspector]
    public float speedMod=1f;
    [SerializeField]private float timeBetweenAttacks, damagePerAttack;
    [SerializeField]private Transform target;
    
    private int currentPoint;
    private Path thePath;
    private Castle theCastle;
    private bool reachedEnd =false;
    private float attackCounter;
    private int selectedAttackPoint;

    public bool isFlying;
    public float flyHeight;
    
    
    void Start()
    {
        target = GameObject.FindWithTag("Castle").GetComponent<Transform>();
        if (thePath == null)
        {
            thePath = FindObjectOfType<Path>();
        }
        if (theCastle == null)
        {
            theCastle = FindObjectOfType<Castle>();
        }

        attackCounter = timeBetweenAttacks;

        if (isFlying)
        {
            transform.position += Vector3.up * flyHeight;

            currentPoint = thePath.Points.Length - 1;
        }

    }
    
    void Update()
    {
        if (LevelManager.instance.levelActive)
        {
            if (!reachedEnd)
            {
                transform.LookAt(thePath.Points[currentPoint].position);

                if (!isFlying)
                {
                    transform.position=Vector3.MoveTowards(transform.position,thePath.Points[currentPoint].position,moveSpeed*Time.deltaTime*speedMod); //takip kodu

                    if (Vector3.Distance(transform.position,thePath.Points[currentPoint].position) < 0.1f)
                    {
                        currentPoint++;

                        if (currentPoint >= thePath.Points.Length)
                        {
                            reachedEnd = true;

                            selectedAttackPoint = Random.Range(0, theCastle.attackPoints.Length);
                        }
            
                    }   
                    
                }
                else
                {
                    transform.position=Vector3.MoveTowards(transform.position,thePath.Points[currentPoint].position+(Vector3.up*flyHeight),moveSpeed*Time.deltaTime*speedMod); //takip kodu

                    if (Vector3.Distance(transform.position,thePath.Points[currentPoint].position +(Vector3.up*flyHeight)) < 0.1f)
                    {
                        currentPoint++;

                        if (currentPoint >= thePath.Points.Length)
                        {
                            reachedEnd = true;

                            selectedAttackPoint = Random.Range(0, theCastle.attackPoints.Length);
                        }
            
                    }   
                }
                
            }
            else
            {
                if (!isFlying)
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        theCastle.attackPoints[selectedAttackPoint].position, moveSpeed * Time.deltaTime * speedMod);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        theCastle.attackPoints[selectedAttackPoint].position+(Vector3.up*flyHeight), moveSpeed * Time.deltaTime * speedMod);
                }
                
            
                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0 )
                {
                    attackCounter = timeBetweenAttacks;
                
                    theCastle.TakeDamage(damagePerAttack);
                }
            }
        }
        
    }

    public void Setup(Castle newCastle, Path newPath)
    {
        theCastle = newCastle;
        thePath = newPath;
    }
    
}

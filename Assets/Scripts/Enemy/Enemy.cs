using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyParameters
{
    [Header("Movements")]
    public float minRangeToAttack = 10f;
    public float stopDistance = 5f;
    public float minRangeToPursue = 20.0f;
    [Header("Attacks")]
    public float attackCooldown = 1.5f;
}

public class Enemy : Entity {

    private NavMeshAgent linkedAgent;

    public EnemyParameters enemyParam = new EnemyParameters();

    public Transform target;
    private Transform tr;

    private Animator animator;

    public GameObject bulletPrefab;

    public Transform weaponPivot;
    public SpriteRenderer weaponSprite;

    private float attackCooldown = 0f;

    // Use this for initialization
    void Awake () {
        if (target == null)
        {
            target = findTarget();
        }
        linkedAgent = this.GetComponent<NavMeshAgent>();
        tr = this.transform;
        animator = this.GetComponentInChildren<Animator>();
        Debug.Assert(animator != null);
        Debug.Assert(target != null);
    }
	
	// Update is called once per frame
	void Update () {
        moveToTarget();
        attackTarget();
        updateAnimations();
        updateCooldowns();
	}

    private void updateAnimations()
    {
       animator.SetBool("moving", linkedAgent.velocity.magnitude > 0.1f);
    }

    Transform findTarget()
    {
        return GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }
    

    public void moveToTarget()
    {
        Vector3 dir = (this.tr.position - target.position).normalized;
        float dist = Vector3.Distance(this.tr.position, target.position);
        if (dist < enemyParam.minRangeToPursue)
        {
            linkedAgent.SetDestination(target.position);
        }
        if(dist < enemyParam.stopDistance)
        {
            linkedAgent.Stop();
            linkedAgent.ResetPath();
        }
        tr.rotation = Quaternion.identity;
        //Weapon rotation
        Vector3 euler = Vector3.zero;
        euler.y = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg % 360f;
        if(weaponSprite)
        {
            weaponSprite.flipY = euler.y < 180f;
        }
        weaponPivot.rotation = Quaternion.Euler(euler);
    }

    public bool canAttack()
    {
        return attackCooldown <= 0f && bulletPrefab != null;
    }

    void attackTarget()
    {
        if (Vector3.Distance(this.tr.position, target.position) < enemyParam.minRangeToAttack) {
            if (canAttack())
            {
                GameObject go = Instantiate<GameObject>(bulletPrefab, tr.position, Quaternion.Euler(90f, 0f, 0f));
                go.GetComponent<Bullet>().direction = (target.position - this.tr.position).normalized;
                attackCooldown = enemyParam.attackCooldown;
            }
        }
    }
    
    private void updateCooldowns()
    {
        attackCooldown = Mathf.Max(attackCooldown - Time.deltaTime, 0f);
    }

    public override void die()
    {
        Destroy(this.gameObject);
    }

}

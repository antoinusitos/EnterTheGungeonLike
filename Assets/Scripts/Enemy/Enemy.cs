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

public class Enemy : MonoBehaviour {

    private NavMeshAgent linkedAgent;

    public EnemyParameters enemyParam;

    public Transform target;
    private Transform tr;

    private Animator animator;

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
	}

    private void updateAnimations()
    {
       animator.SetBool("moving", linkedAgent.velocity.magnitude > 0.05f);
    }

    Transform findTarget()
    {
        return GameObject.FindGameObjectsWithTag("player")[0].transform;
    }
    

    public void moveToTarget()
    {
        float dist = Vector3.Distance(this.tr.position, target.position);
        if (dist < enemyParam.minRangeToPursue)
        {
            linkedAgent.SetDestination(target.position);
        }
        if(dist < enemyParam.stopDistance)
        {
            linkedAgent.Stop();
        }
        tr.rotation = Quaternion.identity;
    }

    void attackTarget()
    {
        if (Vector3.Distance(this.tr.position, target.position) < enemyParam.minRangeToAttack) {
            //Attack

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyParameters
{
    public float minRangeToAttack = 10f;
    public float stopDistance = 5f;
    public float minRangeToPursue = 20.0f;
}

public class Enemy : MonoBehaviour {

    private NavMeshAgent linkedAgent;

    public EnemyParameters enemyParam;

    public Transform target;
    private Transform tr;

    // Use this for initialization
    void Awake () {
        if (target == null)
        {
            target = findTarget();
        }
        linkedAgent = this.GetComponent<NavMeshAgent>();
        Debug.Assert(target != null);
        tr = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        moveToTarget();
        attackTarget();
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
    }

    void attackTarget()
    {
        if (Vector3.Distance(this.tr.position, target.position) < enemyParam.minRangeToAttack) {
            //Attack
        }
    }

}

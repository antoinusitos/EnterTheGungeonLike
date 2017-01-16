using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletParameters
{
    public float bulletDamage = 1.0f;
    public float speed = 1.0f;
}

public class Bullet : MonoBehaviour {

    public BulletParameters bulletParams;

    public entityType possibleTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        Entity e = other.GetComponent<Entity>();
        if(e.type == possibleTarget)
        {
            e.takeDamage(bulletParams.bulletDamage);
        }
    }
}

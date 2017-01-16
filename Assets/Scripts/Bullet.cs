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

    public Vector3 direction;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 20f);	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += direction * Time.deltaTime * bulletParams.speed;
	}

    private void OnTriggerEnter(Collider other)
    {

        Entity e = other.GetComponent<Entity>();
        if(e && e.type == possibleTarget)
        {
            e.takeDamage(bulletParams.bulletDamage);
            Destroy(this.gameObject);
        }

    }
}

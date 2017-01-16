using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float bulletDamage = 1.0f;
    private Vector3 _dir;
    private float _speed = 10.0f;
    public float damage = 10.0f;

	void Start ()
    {
		
	}
	
    public void Shoot(Vector3 theDir)
    {
        _dir = theDir;
    }

	void Update ()
    {
        transform.position += _dir * Time.deltaTime * _speed;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().takeDamage(damage);
        }
    }
}

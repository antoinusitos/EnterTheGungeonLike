using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector3 _dir;
    private float _speed = 10.0f;

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
}

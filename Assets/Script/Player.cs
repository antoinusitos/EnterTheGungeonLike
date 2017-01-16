using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Weapon _weapon;
    private Rigidbody _rigidBody;
    private float _speed = 5.0f;

	void Start ()
    {
        _weapon = GetComponent<Weapon>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update ()
    {

        Vector3 dir = Vector3.zero;

		if(Input.GetKey(KeyCode.Q))
        {
            dir.x = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1.0f;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            dir.z = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.z = -1.0f;
        }

        dir = dir.normalized;

        _rigidBody.MovePosition(transform.position + dir * Time.deltaTime * _speed);

        if(Input.GetKey(KeyCode.Mouse0))
        {
            _weapon.Shoot();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Weapon _weapon;
    private Rigidbody _rigidBody;
    private float _speed = 5.0f;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    void Start ()
    {
        _weapon = GetComponent<Weapon>();
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void GetNewWeapon(System.Type aType, Sprite s)
    {
        GameObject bullet = _weapon.bullet;
        Destroy(_weapon);
        try
        {
            _weapon = gameObject.AddComponent(aType) as Weapon;
            _weapon.bullet = Resources.Load<GameObject>("Bullet");
            transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = s;
            transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = s;
        }
        catch
        {
            Debug.Log("it's not a weapon !");
        }
    }

    void Update ()
    {

        Vector3 dir = Vector3.zero;

        bool move = false;

		if(Input.GetKey(KeyCode.Q))
        {
            dir.x = -1.0f;
            move = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1.0f;
            move = true;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            dir.z = 1.0f;
            move = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.z = -1.0f;
            move = true;
        }

        if(move)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }

        if(_weapon.FindDirection().x < 0)
        {
            _spriteRenderer.flipX = true;
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            _spriteRenderer.flipX = false;
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
        }

        dir = dir.normalized;

        _rigidBody.MovePosition(transform.position + dir * Time.deltaTime * _speed);

        if(Input.GetKey(KeyCode.Mouse0))
        {
            _weapon.Shoot();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;

    protected float fireRate = 0.5f;
    protected float _currentReload = 0.0f;
    protected bool _canShoot = true;
    public float damage = 10.0f;
    
	void Start ()
    {
		
	}

    protected void SetFireRate(float newFireRate)
    {
        fireRate = newFireRate;
    }
	
	void Update ()
    {
		if(!_canShoot)
        {
            _currentReload += Time.deltaTime;
            if(_currentReload >= fireRate)
            {
                _currentReload = 0.0f;
                _canShoot = true;
            }
        }
	}

    public virtual void Shoot()
    {
        if(_canShoot)
        {
            _canShoot = false;
            GameObject aBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            float posY = aBullet.transform.position.y;
            aBullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            aBullet.GetComponent<BulletPlayer>().Shoot(FindDirection());
            aBullet.GetComponent<BulletPlayer>().damage = damage;
        }
    }

    public Vector3 FindDirection()
    {
        Vector3 dir = Vector3.zero;

        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 finalDir = transform.position - dir;

        finalDir.y = 0.0f;

        finalDir = finalDir.normalized;
        finalDir *= -1.0f;

        return finalDir;
    }
}

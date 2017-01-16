using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.5f;
    public GameObject bullet;

    private float _currentReload = 0.0f;
    private bool _canShoot = true;
    
	void Start ()
    {
		
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

    public void Shoot()
    {
        if(_canShoot)
        {
            _canShoot = false;
            GameObject aBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            float posY = aBullet.transform.position.y;
            aBullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            aBullet.GetComponent<Bullet>().Shoot(FindDirection());
        }
    }

    Vector3 FindDirection()
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

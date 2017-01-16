using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{

    public override void Shoot()
    {
        if (_canShoot)
        {
            _canShoot = false;
            GameObject aBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject aBullet2 = Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject aBullet3 = Instantiate(bullet, transform.position, Quaternion.identity);
            float posY = aBullet.transform.position.y;
            aBullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            aBullet2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            aBullet3.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            aBullet.GetComponent<BulletPlayer>().Shoot(FindDirection());
            aBullet2.GetComponent<BulletPlayer>().Shoot(FindDirection() + FindDirection() * 1.5f);
            aBullet3.GetComponent<BulletPlayer>().Shoot(FindDirection() + FindDirection() * 0.5f);
        }
    }
}

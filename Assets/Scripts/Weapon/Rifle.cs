using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
	void Start()
    {
        SetFireRate(fireRate / 5.0f);
    }
}

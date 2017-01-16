using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private int _life = 0;
    private int _maxLife = 100;

	void Start ()
    {
        _life = _maxLife;
    }

    public void TakeDamage(int amount)
    {
        _life -= amount;
        if(_life <= 0)
        {
            Dead();
        }
    }

    public virtual void Dead()
    {

    }
}

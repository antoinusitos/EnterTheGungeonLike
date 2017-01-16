using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class PickUp : MonoBehaviour
{

    private Weapon _toGive;
    System.Type t;

    private void Start()
    {
        _toGive = GetComponent<Weapon>();
        t = _toGive.GetType();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().GetNewWeapon(t);
            Destroy(gameObject);
        }
    }
}

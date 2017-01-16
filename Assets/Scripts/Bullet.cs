using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletParameters
{
    public float bulletDamage = 1.0f;
    public float speed = 1.0f;
}

public class Bullet : MonoBehaviour {

    public BulletParameters bulletParams;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Enemy>();
    }
}

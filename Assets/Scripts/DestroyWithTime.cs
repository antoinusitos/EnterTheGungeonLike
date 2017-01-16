using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithTime : MonoBehaviour
{
    private float _timeToDestroy = 2.0f;

	void Start ()
    {
        Invoke("DestroyObject", _timeToDestroy);
    }
	
	void DestroyObject()
    {
        Destroy(gameObject);
    }
}

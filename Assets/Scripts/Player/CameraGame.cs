using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGame : MonoBehaviour
{
    public float _speed = 3.0f;
    private GameObject _player;

	void Start ()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

    }
	
	void Update ()
    {
        Vector3 pos = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * _speed);
    }
}

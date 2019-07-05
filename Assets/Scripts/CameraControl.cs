using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	private Transform _target;
	private Vector3 _offset;
	private Vector3 _vector3Movement;

	[SerializeField]
	private float _speedMoving;

	private float _transition = 0f;
	private float _animationDuration = 1.5f;
	private Vector3 _offsetAnim = new Vector3(0, 5, 5);

	// Use this for initialization
	void Start()
	{
		_target = GameObject.FindGameObjectWithTag("Player").transform;
		_offset = transform.position - _target.position;
	}

	// Update is called once per frame
	void Update()
	{
		_vector3Movement = _target.position + _offset;

		Vector3 moveTo = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _speedMoving);

		_vector3Movement.x = moveTo.x;

		//mirar más sobre Mathf.Clamp
		_vector3Movement.y = Mathf.Clamp(_vector3Movement.y, 4, 6);

		if (_transition > 1.0f)
		{
			transform.position = _vector3Movement;
		}
		else
		{
			transform.position = Vector3.Lerp(_vector3Movement + _offsetAnim, _vector3Movement, _transition);
			transform.LookAt(_target.position);
			_transition += Time.deltaTime * 1 / _animationDuration;
		}

	}
}

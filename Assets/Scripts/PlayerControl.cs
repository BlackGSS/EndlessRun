using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	[SerializeField]
	private float _speed = 10;

	[SerializeField]
	private float _gravity = 12;

	[SerializeField]
	private float _jumpSpeed;

	public bool isDead = false;

	private CharacterController _control;
	private Vector3 _vector3Movement;

	private float _animationDuration = 1.8f;
	private float _startTime;

	[SerializeField]
	private Animator _anim;


	// Use this for initialization
	void Start()
	{
		_control = GetComponent<CharacterController>();
		_startTime = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		if (isDead || GameManager.instance.isPaused)
			return;

		if (Time.time - _startTime < _animationDuration)
		{
			_control.Move(Vector3.forward * _speed * Time.deltaTime);
			return;
		}

		_vector3Movement = Vector3.zero;

		if (_control.isGrounded)
		{
			_jumpSpeed = -0.5f;
		}
		else
		{
			_jumpSpeed -= _gravity * Time.deltaTime;
		}

		if (Input.GetMouseButton(0))
		{
			if (Input.mousePosition.y < Screen.height / 2)
			{
				if (Input.mousePosition.x > Screen.width / 2)
				{
					_vector3Movement.x = _speed;
				}
				else
				{
					_vector3Movement.x = -_speed;
				}
			}
		}

		_vector3Movement.y = _jumpSpeed;

		_vector3Movement.z = _speed;

		_control.Move(_vector3Movement * Time.deltaTime);
	}

	public void SetSpeed(float newLevel)
	{
		NewLevel();
		_speed = _speed + newLevel;
	}

	private void NewLevel()
	{
		_anim.SetTrigger("LevelUp");
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.point.z > transform.position.z + _control.radius && hit.collider.tag == "Enemy")
		{
			Debug.Log(hit.collider);
			Death();
		}
	}

	private void Death()
	{
		isDead = true;
		GetComponent<ScoreControl>().OnDeath();
	}
}

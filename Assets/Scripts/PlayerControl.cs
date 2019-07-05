using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float Speed = 5;
	public float Gravity = 12;
	public float JumpSpeed;

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
		if (isDead)
			return;

		if (Time.time - _startTime < _animationDuration)
		{
			_control.Move(Vector3.forward * Speed * Time.deltaTime);
			return;
		}

		_vector3Movement = Vector3.zero;

		if (_control.isGrounded)
		{
			JumpSpeed = -0.5f;
		}
		else
		{
			JumpSpeed -= Gravity * Time.deltaTime;
		}

		if (Input.GetMouseButton(0))
		{
			if (Input.mousePosition.x > Screen.width / 2)
			{
				_vector3Movement.x = Speed;
			}
			else
			{
				_vector3Movement.x = -Speed;
			}
		}

		_vector3Movement.y = JumpSpeed;

		_vector3Movement.z = Speed;

		_control.Move(_vector3Movement * Time.deltaTime);
	}

	public void SetSpeed(float newLevel)
	{
		NewLevel();
		Speed = Speed + newLevel;
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

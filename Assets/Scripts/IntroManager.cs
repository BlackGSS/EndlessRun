using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
	[SerializeField]
	private bool _changeScene;

	[SerializeField]
	private Animator _anim;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (_anim.GetBool("Start") == false)
			{
				_anim.SetBool("Start", true);
			}
		}

		if (_changeScene == true)
		{
			SceneManager.LoadScene("Menu");
		}
	}
}

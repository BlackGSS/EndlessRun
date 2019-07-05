using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
	public bool ChangeScene;
	public Animator Anim;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (Anim.GetBool("Start") == false)
			{
				Anim.SetBool("Start", true);
			}
		}

		if (ChangeScene == true)
		{
			SceneManager.LoadScene("Menu");
		}
	}
}

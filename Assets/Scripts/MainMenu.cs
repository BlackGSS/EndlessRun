﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void ToGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void SelectPlayer(int index)
	{
		GameManager.playerSelected = index;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
	public List<GameObject> players;
	public static int playerSelected = 0;

	//public GameObject powerUp;
	//private float _timeToPower;

	[SerializeField]
	private Image _fadeIn;

	[SerializeField]
	private int _fadeOffset;

	private float _transition;

	public TextMeshProUGUI score, highScore;
	public DeathMenu deathMenu;

	[SerializeField]
	private GameObject _pauseMenu;

	public bool isPaused;

	public static GameManager instance;

	// Use this for initialization
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}

		_pauseMenu.SetActive(false);
		_fadeIn.gameObject.SetActive(true);
		//_timeToPower = 0;
		GameObject player = Instantiate(players[playerSelected], transform.position, Quaternion.Euler(0, 0, 0));
	}

	// Update is called once per frame
	void Update()
	{
		if (_fadeIn.gameObject.activeSelf)
		{
			_transition += Time.deltaTime / _fadeOffset;
			Color tempColor = _fadeIn.color;
			tempColor.a -= _transition;
			_fadeIn.color = tempColor;

			if (_fadeIn.color.a <= 0)
			{
				_fadeIn.gameObject.SetActive(false);
			}
		}
	}

	public void Pause()
	{
		if (!_pauseMenu.activeSelf)
		{
			_pauseMenu.SetActive(true);
			isPaused = true;
		}
		else
		{
			_pauseMenu.SetActive(false);
			isPaused = false;
		}
	}

	public void Resume()
	{
		if (isPaused)
			_pauseMenu.SetActive(false);
			isPaused = false;
	}
}

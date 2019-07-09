using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreControl : MonoBehaviour
{
	private float _score = 0.0f;

	private int _difficultLevel = 1;
	private int _maxDifficultLevel = 10;
	private int _scoreToNextLevel = 10;

	private TextMeshProUGUI _scoreText, _highscoreText;
	private DeathMenu _deathMenu;

	private void Start()
	{
		_scoreText = GameManager.instance.score;
		_highscoreText = GameManager.instance.highScore;
		_deathMenu = GameManager.instance.deathMenu;
		_highscoreText.text = ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
	}

	// Update is called once per frame
	void Update()
	{
		if (GetComponent<PlayerControl>().isDead || GameManager.instance.isPaused)
			return;

		if (_score >= _scoreToNextLevel)
			LevelUp();

		_score += Time.deltaTime * _difficultLevel;
		_scoreText.text = ((int)_score).ToString();
	}

	void LevelUp()
	{
		if (_difficultLevel == _maxDifficultLevel)
			return;

		_scoreToNextLevel *= 2;
		print(_scoreToNextLevel);
		_difficultLevel++;

		GetComponent<PlayerControl>().SetSpeed(_difficultLevel);
	}

	public void OnDeath()
	{
		if(PlayerPrefs.GetFloat("Highscore") < _score)
			PlayerPrefs.SetFloat("Highscore", _score);

		_deathMenu.ToggleEndMenu(_score);
	}
}

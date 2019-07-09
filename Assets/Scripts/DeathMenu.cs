using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathMenu : MonoBehaviour
{
	public TextMeshProUGUI scoreText;
	public Image backgroundImg;

	[SerializeField]
	private bool _isShowed = false;

	private float _transition;

	// Use this for initialization
	void Start()
	{
		gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (!_isShowed)
			return;

		_transition += Time.deltaTime / 2;
		backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, _transition);
	}

	public void ToggleEndMenu(float score)
	{
		gameObject.SetActive(true);
		scoreText.text = ((int)score).ToString();
		_isShowed = true;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ReturnMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}

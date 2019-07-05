using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
	public List<GameObject> players;
	public static int playerSelected = 0;

	public GameObject powerUp;
	private float _timeToPower;

	public Image FadeIn;
	public int FadeOffset;
	private float _transition;
	public TextMeshProUGUI Score, Highscore;
	public DeathMenu DeathMenu;

	// Use this for initialization
	void Awake()
	{
		FadeIn.gameObject.SetActive(true);
		_timeToPower = 0;
		GameObject player = Instantiate(players[playerSelected], transform.position, Quaternion.Euler(0, 0, 0));
	}

	// Update is called once per frame
	void Update()
	{
		if (FadeIn.gameObject.activeSelf)
		{
			_transition += Time.deltaTime / FadeOffset;
			Color tempColor = FadeIn.color;
			tempColor.a -= _transition;
			FadeIn.color = tempColor;

			if (FadeIn.color.a <= 0)
			{
				FadeIn.gameObject.SetActive(false);
			}
		}

		//_timeToPower += Time.deltaTime;

		//if (_timeToPower > Random.Range(8, 15))
		//{

		//}
	}
}

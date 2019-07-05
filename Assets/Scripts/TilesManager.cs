using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
	public GameObject[] tilePrefabs;
	private List<GameObject> _savedTiles;

	private Transform	_playerTransform;
	private float		_spawnZ = 0.0f;
	private float		_tileLength = 20.5f;
	private float		_safeZone = 18f;
	private int			_amountTiles = 8;
	private int			_lastPrefabIndex = 0;

	// Use this for initialization
	void Start()
	{
		_savedTiles = new List<GameObject>();

		_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		//Sin obstaculos las primeras
		for (int i = 0; i < _amountTiles; i++)
		{
			if (i < 2)
				SpawnTiles(0);
			else
				SpawnTiles();
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (_playerTransform.position.z - _safeZone > (_spawnZ - _amountTiles * _tileLength))
		{
			SpawnTiles();
			DeleteTiles();
		}
	}

	private void SpawnTiles(int index = -1)
	{
		GameObject go;

		if (index == -1)
			go = Instantiate(tilePrefabs[RandomIndex()]);
		else
			go = Instantiate(tilePrefabs[index]);

		go.transform.SetParent(transform);
		go.transform.position = Vector3.forward * _spawnZ;
		_spawnZ += _tileLength;
		_savedTiles.Add(go);
	}

	private void DeleteTiles()
	{
		Destroy(_savedTiles[0]);
		_savedTiles.RemoveAt(0);
	}

	private int RandomIndex()
	{
		if (tilePrefabs.Length <= 1)
		{
			return 0;
		}

		int randomIndex = _lastPrefabIndex;
		while (randomIndex == _lastPrefabIndex)
		{
			randomIndex = Random.Range(0, tilePrefabs.Length);
		}

		_lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}

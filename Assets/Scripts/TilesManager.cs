using System;
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
				SpawnInitialTiles();
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

	private void SpawnInitialTiles()
	{
		//throw new NotImplementedException();
	}

	private void SpawnTiles()
	{
		GameObject go;

		go = PoolSystem.GetChunkFromPool(Dificulties.EASY);

		go.transform.SetParent(transform);
		go.transform.position = Vector3.forward * _spawnZ;
		_spawnZ += _tileLength;
		_savedTiles.Add(go);
	}

	private void DeleteTiles()
	{
		PoolSystem.AddChunkToPool(_savedTiles[0]);
		_savedTiles.RemoveAt(0);
	}

	
}

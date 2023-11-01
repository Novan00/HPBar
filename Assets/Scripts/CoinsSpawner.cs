using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            Instantiate(_coin, _spawnPoints[i].position, Quaternion.identity);
        }
    }
}

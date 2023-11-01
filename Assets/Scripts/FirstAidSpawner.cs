using System.Collections.Generic;
using UnityEngine;

public class FirstAidSpawner : MonoBehaviour
{
    [SerializeField] private FirstAidKit _firstAidKit;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
        FirstAidKitsSpawn();
    }

    private void FirstAidKitsSpawn()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            FirstAidKit _newFirstAidKit = Instantiate(_firstAidKit, _spawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]

public class FirstAidKitsPicker : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FirstAidKit>(out FirstAidKit firstAidKit))
        {
            if (_playerHealth.CurrentHealth < _playerHealth.MaxHealth)
            {
                _playerHealth.TakeHeal();

                Destroy(firstAidKit.gameObject);
            }
        }
    }
}

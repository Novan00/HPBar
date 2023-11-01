using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public event Action ChangeHealthValue;

    private int _currentHealth = 3;
    private int _maxHealth = 3;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public void TakeHeal()
    {
        _currentHealth++;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        ChangeHealthValue?.Invoke();
    }

    public void TakeDamage()
    {
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        _currentHealth--;

        ChangeHealthValue?.Invoke();
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healthButton;

    public event Action ChangeHealthValue;

    private int _currentHealth = 3;
    private int _maxHealth = 3;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(TakeDamage);
        _healthButton.onClick.AddListener(TakeHeal);
    }


    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(TakeDamage);
        _healthButton.onClick.RemoveListener(TakeHeal);
    }

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
        _currentHealth--;

        ChangeHealthValue?.Invoke();
    }
}

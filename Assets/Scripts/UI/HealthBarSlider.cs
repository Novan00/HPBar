using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private PlayerHealth _health;

    private void Awake()
    {
        _health = _player.GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _health.ChangeHealthValue += OnChangeHealthValue;
    }
    private void Start()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.value = _health.CurrentHealth;
    }

    private void OnDisable()
    {
        _health.ChangeHealthValue -= OnChangeHealthValue;
    }

    private void MoveSlider()
    {
        _slider.value = _health.CurrentHealth;
    }

    private void OnChangeHealthValue()
    {
        MoveSlider();
    }
}

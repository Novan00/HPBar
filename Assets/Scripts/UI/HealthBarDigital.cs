using UnityEngine;
using UnityEngine.UI;

public class HealthBarDigital : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Player _player;

    Slider _slider;

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
        ShowHealth();
    }

    private void OnDisable()
    {
        _health.ChangeHealthValue -= OnChangeHealthValue;
    }

    private void ShowHealth()
    {
        _text.text = _health.CurrentHealth.ToString() + "/" + _health.MaxHealth.ToString();
    }

    private void OnChangeHealthValue()
    {
        ShowHealth();
    }
}

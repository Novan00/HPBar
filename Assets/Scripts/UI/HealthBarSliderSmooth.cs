using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSliderSmooth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerHealth _health;

    private float _changeHealthSpeed = 1f;
    private Coroutine _coroutine;

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

    private IEnumerator MoveSlider()
    {
        while (_slider.value != _health.CurrentHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.CurrentHealth, _changeHealthSpeed * Time.deltaTime);
            
            yield return null;  
        }
    }

    private void OnChangeHealthValue()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(MoveSlider());
    }
}

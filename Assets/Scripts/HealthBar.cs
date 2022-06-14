using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Unit _unit;

    private Coroutine _changeHealthCoroutine;

    private void OnEnable()
    {
        _unit.HealthChanged += ChangeHealthValue;
    }

    private void OnDisable()
    {
        _unit.HealthChanged -= ChangeHealthValue;
    }

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void ChangeHealthValue()
    {
        if (_changeHealthCoroutine != null)
        {
            StopCoroutine(_changeHealthCoroutine);
        }
        _changeHealthCoroutine = StartCoroutine(ChangeSliderValue());
    }

    private IEnumerator ChangeSliderValue()
    {
        int changeStep = 50;

        while (_slider.value != _unit.Health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _unit.Health, changeStep * Time.deltaTime);
            yield return null;
        }
    }
}

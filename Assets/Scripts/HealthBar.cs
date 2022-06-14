using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
        float changeStep = 0.1f;

        while (_slider.value != _unit.CurrentHealthValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _unit.CurrentHealthValue, changeStep);
            yield return null;
        }
    }   
}

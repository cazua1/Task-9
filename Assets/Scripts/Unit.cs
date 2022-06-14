using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _minHealth = 0;
    
    public event UnityAction HealthChanged;

    public int CurrentHealthValue { get; private set; }

    private void Start()
    {
        CurrentHealthValue = _maxHealth;
    }

    public void TakeDamage()
    {
        int damageValue = -10;
        ChangeHealth(damageValue);

        if (CurrentHealthValue < _minHealth)
        {
            CurrentHealthValue = _minHealth;
        }            

        HealthChanged?.Invoke();
    }

    public void TakeHeal()
    {
        int healValue = 10;
        ChangeHealth(healValue);

        if (CurrentHealthValue > _maxHealth)
        {
            CurrentHealthValue = _maxHealth;
        }            

        HealthChanged?.Invoke();
    }

    private void ChangeHealth(int value)
    {
        CurrentHealthValue += value;
    }   
}

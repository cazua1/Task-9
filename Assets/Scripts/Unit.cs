using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _minHealth = 0;

    public event UnityAction HealthChanged;

    public int Health { get; private set; }

    private void Start()
    {
        Health = _maxHealth;
    }

    public void TakeDamage()
    {
        int damageValue = -10;
        ChangeHealth(damageValue);        
        HealthChanged?.Invoke();
    }

    public void TakeHeal()
    {
        int healValue = 10;
        ChangeHealth(healValue);        
        HealthChanged?.Invoke();
    }

    private void ChangeHealth(int value)
    {
        Health += value;
        Health = Mathf.Clamp(Health, _minHealth, _maxHealth);
    }
}

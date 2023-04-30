using System;
using UnityEditorInternal;
using UnityEngine;

namespace DefaultNamespace
{
    public class HeroController : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private float _currentHealth = 100f;
        [SerializeField] private float _heroDamage = 5;
        public float HeroDamage { get; set; }
        public float MaxHealth { get; private set; } 
        public float CurrentHealth { get; set; }
        public event Action<float> OnMaxHealthChanged;


        private void Start()
        {
            HeroDamage = _heroDamage;
            MaxHealth = _maxHealth;
            CurrentHealth = _currentHealth;
            OnMaxHealthChanged?.Invoke(MaxHealth);
        }
        
    }
    
    
}
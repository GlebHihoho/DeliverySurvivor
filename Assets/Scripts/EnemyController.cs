using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float _enemyDamage;
        [SerializeField] private float _enemyHealth;
        private HeroController _heroController;

        private void Start()
        {
            _heroController = FindObjectOfType<HeroController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("MainHero"))
            {
                // Take damage
                TakeDamage(_enemyDamage);
            }
        }
        
        private void TakeDamage(float damage)
        {
            _heroController.CurrentHealth -= damage;
        
            if (_heroController.CurrentHealth <= 0)
            {
                HeroDie();
            }
        }
        
        private void HeroDie()
        {
            // Destroy the enemy object
            Destroy(_heroController.gameObject);
        }
        
    }
}

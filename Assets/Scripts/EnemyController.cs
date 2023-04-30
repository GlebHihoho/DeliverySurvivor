using System;
using System.Collections;
using TMPro;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float _enemyDamage;
        [SerializeField] private float _enemyHealth;
        public float EnemyHealth;
        private HeroController _heroController;
        [SerializeField] private TextMeshProUGUI _damageText;

        private void Start()
        {
            EnemyHealth = _enemyHealth;
            _heroController = FindObjectOfType<HeroController>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("MainHero"))
            {
                TakeDamageHero(_enemyDamage);
            }
        }
        
        private void TakeDamageHero(float damage)
        {
            _heroController.CurrentHealth -= damage;
        
            if (_heroController.CurrentHealth <= 0)
            {
                HeroDie();
            }
        }
        
        private void HeroDie()
        {
            Destroy(_heroController.gameObject);
        }
        
        private void Die()
        {
            Destroy(gameObject);
        }
        
        public void TakeDamageEnemy(float damage)
        {
            _damageText.text = "-" + damage.ToString();
            _enemyHealth -= damage;
            if (_enemyHealth <= 0)
            {
                Die();
            }
        }
        
        
    }
}

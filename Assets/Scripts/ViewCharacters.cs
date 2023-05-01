using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ViewCharacters : MonoBehaviour
    {
        public TextMeshProUGUI _maxSpeed;
        public TextMeshProUGUI _maxHealth;
        public TextMeshProUGUI _maxDamage;

        private HeroController _heroController;


        private void Start()
        {
            _heroController = FindObjectOfType<HeroController>();
            _maxSpeed.text = _heroController.MaxHealth.ToString();
            _maxHealth.text = _heroController.CurrentHeroDamage.ToString();
            _maxDamage.text = _heroController.CurrentSpeed.ToString();
        }

        private void Update()
        {
            _maxSpeed.text = _heroController.MaxHealth.ToString();
            _maxHealth.text = _heroController.CurrentHeroDamage.ToString();
            _maxDamage.text = _heroController.CurrentSpeed.ToString();
        }
    }
    
    
}
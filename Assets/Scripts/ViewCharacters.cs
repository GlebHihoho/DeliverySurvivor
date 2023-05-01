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
        private Weapon _weapon;


        private void Start()
        {
            _weapon = FindObjectOfType<Weapon>();
            _heroController = FindObjectOfType<HeroController>();
            _maxHealth.text = _heroController.MaxHealth.ToString();
            _maxDamage.text = _weapon.CurrentDamage.ToString();
            _maxSpeed.text = _heroController.CurrentSpeed.ToString();
        }

        private void Update()
        {
            _maxHealth.text = _heroController.MaxHealth.ToString();
            _maxDamage.text = _weapon.CurrentDamage.ToString();
            _maxSpeed.text = _heroController.CurrentSpeed.ToString();
        }
    }
    
    
}
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


namespace DefaultNamespace
{
    public class CharacterUpButton : MonoBehaviour
    {
        private HeroController _heroController;
        [SerializeField] private TextMeshProUGUI _levelUpPrice;
        [SerializeField] private Image[] _changeSpriteLevelUp;
        [SerializeField] private float _baseLevelUpPrice;
        [SerializeField] private float _currentBaseLevelUpPrice;
        [SerializeField] private Button _button;
        private int _indexSpriteSpeed = 0;
        private int _indexSpriteHealth = 0;
        private int _indexSpriteDamage = 0;


        private void Start()
        {
            _heroController = FindObjectOfType<HeroController>();
            _levelUpPrice.text = _baseLevelUpPrice.ToString();
            _currentBaseLevelUpPrice = _baseLevelUpPrice;

        }

        public void ChangeHeroSpeed()
        {
            if (Balance.Instance._balanceValue >= _currentBaseLevelUpPrice && _indexSpriteSpeed <= _changeSpriteLevelUp.Length - 2)
            {
                _changeSpriteLevelUp[_indexSpriteSpeed].color = new Color(1f, 1f, 1f);
                _indexSpriteSpeed++;
                Balance.Instance._balanceValue -= _currentBaseLevelUpPrice;
                _currentBaseLevelUpPrice += 20f; 
                _levelUpPrice.text = _currentBaseLevelUpPrice.ToString();

            }
            else
            {
                _changeSpriteLevelUp[_indexSpriteSpeed].color = new Color(1f, 1f, 1f);
                Balance.Instance._balanceValue -= _currentBaseLevelUpPrice;
                _currentBaseLevelUpPrice += 20f; 
                _button.interactable = false;
                _levelUpPrice.text = "Max Level UP";
            }
        }
        public void ChangeHeroHealth()
        {
            
        }
        public void ChangeHeroDamage()
        {
            
        }
    }
}
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
        [SerializeField] private float _currentLevelUpPrice;
        [SerializeField] private Button _button;
        [SerializeField] private float _stepIncreasePrice = 5f;
        [SerializeField] private float _increaseSpeed;
        [SerializeField] private float _increaseHealth;
        [SerializeField] private float _increaseDamage;
        private int _indexSprite = 0;

        private ViewCharacters _viewCharacters;
        //private int _indexSpriteHealth = 0;
        //private int _indexSpriteDamage = 0;


        private void Start()
        {
            _viewCharacters = FindObjectOfType<ViewCharacters>();
            _heroController = FindObjectOfType<HeroController>();
            _levelUpPrice.text = _baseLevelUpPrice.ToString();
            _currentLevelUpPrice = _baseLevelUpPrice;





        }

        public void ChangeHeroSpeed()
        {
            if (Balance.Instance._balanceValue >= _currentLevelUpPrice && _indexSprite <= _changeSpriteLevelUp.Length - 2)
            {
                _changeSpriteLevelUp[_indexSprite].color = new Color(1f, 1f, 1f);
                _indexSprite++;
                Balance.Instance._balanceValue -= _currentLevelUpPrice;
                _currentLevelUpPrice += _stepIncreasePrice; 
                _levelUpPrice.text = _currentLevelUpPrice.ToString();
                _heroController.CurrentSpeed += _increaseSpeed;
                _viewCharacters._maxSpeed.text = _heroController.CurrentSpeed.ToString();

            }
            else
            {
                _changeSpriteLevelUp[_indexSprite].color = new Color(1f, 1f, 1f);
                Balance.Instance._balanceValue -= _currentLevelUpPrice;
                _currentLevelUpPrice += _stepIncreasePrice; 
                _button.interactable = false;
                _levelUpPrice.text = "Max Level";
                _heroController.CurrentSpeed += _increaseSpeed;
                _viewCharacters._maxSpeed.text = _heroController.CurrentSpeed.ToString();
            }
        }
        public void ChangeHeroHealth()
        {
            if (Balance.Instance._balanceValue >= _currentLevelUpPrice && _indexSprite <= _changeSpriteLevelUp.Length - 2)
            {
                _changeSpriteLevelUp[_indexSprite].color = new Color(1f, 1f, 1f);
                _indexSprite++;
                Balance.Instance._balanceValue -= _currentLevelUpPrice;
                _currentLevelUpPrice += _stepIncreasePrice; 
                _levelUpPrice.text = _currentLevelUpPrice.ToString();
                _heroController.MaxHealth += _increaseHealth;
                _heroController.CurrentHealth += _increaseHealth;
                _viewCharacters._maxHealth.text = _heroController.MaxHealth.ToString();
            }
            else
            {
                _changeSpriteLevelUp[_indexSprite].color = new Color(1f, 1f, 1f);
                Balance.Instance._balanceValue -= _currentLevelUpPrice;
                _currentLevelUpPrice += _stepIncreasePrice; 
                _button.interactable = false;
                _levelUpPrice.text = "Max Level";
                _heroController.MaxHealth += _increaseHealth;
                _heroController.CurrentHealth += _increaseHealth;
                _viewCharacters._maxHealth.text = _heroController.MaxHealth.ToString();
            }
        }
        public void ChangeHeroDamage()
        {
            if (Balance.Instance._balanceValue >= _currentLevelUpPrice && _indexSprite <= _changeSpriteLevelUp.Length - 2)
            {
                _changeSpriteLevelUp[_indexSprite].color = new Color(0.9433962f, 0.8178631f, 0.1201f);
                _indexSprite++;
                Balance.Instance._balanceValue -= _currentLevelUpPrice;
                _currentLevelUpPrice += _stepIncreasePrice; 
                _levelUpPrice.text = _currentLevelUpPrice.ToString();
                _heroController.CurrentHeroDamage = _increaseDamage;
                _viewCharacters._maxDamage.text = _heroController.CurrentHeroDamage.ToString();

            }
            else
            {
                _changeSpriteLevelUp[_indexSprite].color = new Color(0.9433962f, 0.8178631f, 0.1201f);
                Balance.Instance._balanceValue -= _currentLevelUpPrice;
                _currentLevelUpPrice += _stepIncreasePrice; 
                _button.interactable = false;
                _levelUpPrice.text = "Max Level";
                _heroController.CurrentHeroDamage = _increaseDamage;
                _viewCharacters._maxDamage.text = _heroController.CurrentHeroDamage.ToString();
            }
        }
    }
}
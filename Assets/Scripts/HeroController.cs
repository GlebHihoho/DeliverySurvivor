using System;
using DefaultNamespace.Delivery;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Serialization;

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
        private Trader _trader;
        
        //public GameObject _throwPrefab;
        

        private InventoryManager _inventoryManager;
        private bool _canDeliver = false;
        //private bool _closestItem = false;

        private void Start()
        {
            HeroDamage = _heroDamage;
            MaxHealth = _maxHealth;
            CurrentHealth = _currentHealth;
            OnMaxHealthChanged?.Invoke(MaxHealth);
            
            _inventoryManager = InventoryManager.instance;

            _trader = FindObjectOfType<Trader>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_inventoryManager.inventoryItems.Count > 0)
                {
                    GameObject item = _inventoryManager.inventoryItems[0];
                    _inventoryManager.RemoveItem(item);
                    
                    
                    //GameObject _itemObject = GameObject.FindWithTag("Item");
                    GameObject _itemObject = _trader.ItemPrefab;
                    Instantiate(_itemObject, transform.position, Quaternion.identity);
                }
                else if (_canDeliver)
                {
                    GameObject _itemObject = GameObject.FindWithTag("Item");
                    //GameObject _itemObject = _trader.ItemPrefab;
                    _inventoryManager.AddItem(_itemObject);
                    Destroy(_itemObject);
                    Debug.Log("hhhhhhhhhhhhhhhh");
                }
            }
        }
        
        
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Item"))
            {
                _canDeliver = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Item"))
            {
                _canDeliver = false;
            }
        }
        
    }
}
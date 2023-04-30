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
        [SerializeField] private float _changeSpeed;
        public float HeroDamage { get; set; }
        public float MaxHealth { get; private set; } 
        public float CurrentHealth { get; set; }
        public float ChangeSpeed { get; private set; }
        public event Action<float> OnMaxHealthChanged;
        private Trader _trader;
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _scale;
        [SerializeField] private Vector3 _originalScale;
        private InputController _inputController;

        
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
            
            
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _inputController = FindObjectOfType<InputController>();

        }

        private void Update()
        {
            

            

            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (_inventoryManager.inventoryItems.Count > 0)
                {


                    string ItemTag = _trader.ItemPrefab.tag;
                    GameObject item = _inventoryManager.inventoryItems[0];
                    _inventoryManager.RemoveItem(item);
                    
                    
                    //GameObject _itemObject = GameObject.FindWithTag("Item");
                    GameObject _itemObject = _trader.ItemPrefab;
                    Instantiate(_itemObject, transform.position, Quaternion.identity);
                    PaintTheHero(tag);
                }
                else if (_canDeliver)
                {
                    string ItemTag = _trader.ItemPrefab.tag;

                    GameObject _itemObject = GameObject.FindWithTag(ItemTag);
                    //GameObject _itemObject = _trader.ItemPrefab;
                    _inventoryManager.AddItem(_itemObject);
                    Destroy(_itemObject);
                    Debug.Log("hhhhhhhhhhhhhhhh");
                    PaintTheHero(ItemTag);
                }
            }

            // switch (tag)
            // {
            //     case "Item1":
            //             Debug.Log("Зеленый");
            //             break;
            //     case "Item2":
            //         Debug.Log("Красный");
            //         break;
            //     case "Item3":
            //         Debug.Log("Красный");
            //         break;
            //     default:
            //         return;
            // }
        }

        public void PaintTheHero(string ItemTag)
        {
            // if (tag == null)
            //     Debug.Log("цвет обычный");
            // else
            // {
            //     Debug.Log(tag);
            // }
            
            switch (ItemTag)
            {
                case "MainHero":
                    Debug.Log("Обычный");
                    _spriteRenderer.color = new Color(1f, 1f, 1f);
                    _spriteRenderer.transform.localScale = _originalScale;
                    _inputController.ReturnSpeed();
                    break;
                case "Item1":
                        Debug.Log("Зеленый");
                        _spriteRenderer.color = new Color(0.2880f, 1f, 0.1745f);
                        _spriteRenderer.transform.localScale *= (_scale / 100 + 1);
                        _inputController.ChangeSpeed(_changeSpeed);
                        break;
                case "Item2":
                    Debug.Log("Оранжевый");
                    _spriteRenderer.color = new Color(1f, 0.78f, 0f);
                    _spriteRenderer.transform.localScale *= (_scale / 100 + 1);
                    _inputController.ChangeSpeed(_changeSpeed);
                    break;
                case "Item3":
                    Debug.Log("Голубой");
                    _spriteRenderer.color = new Color(0f, 0.8832f, 1f);
                    _spriteRenderer.transform.localScale *= (_scale / 100 + 1);
                    _inputController.ChangeSpeed(_changeSpeed);
                    break;
                default:
                    return;
            }
        }
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Item1") || other.CompareTag("Item2") || other.CompareTag("Item3"))
            {
                _canDeliver = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Item1") || other.CompareTag("Item2") || other.CompareTag("Item3"))
            {
                _canDeliver = false;
            }
        }
        
    }
}
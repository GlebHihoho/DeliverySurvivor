using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.Delivery
{
    public class Trader : MonoBehaviour
    {
        private ItemDataConfig _itemDataConfig;
        public GameObject [] _itemPrefab;
        private bool _canDeliver = false;
        public GameObject ItemPrefab;

        private void Start()
        {
            // _itemDataConfig = new ItemDataConfig();

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("MainHero"))
            {
                _canDeliver = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("MainHero"))
            {
                _canDeliver = false;
            }
        }

        private void Update()
        {
            // if ((_canDeliver && Input.GetKeyDown(KeyCode.E)) && InventoryManager.instance.inventoryItems.Count < 1)
            // {
            //     //GameObject itemObject = Instantiate(_itemPrefab);
            //     InventoryManager.instance.AddItem(_itemPrefab);
            //     Debug.Log("Item added to inventory.");
            // }
            if (!GameObject.FindWithTag("Item"))
            {
                if ((_canDeliver && Input.GetKeyDown(KeyCode.E)) && InventoryManager.instance.inventoryItems.Count < 1)
                {
                    ItemPrefab = _itemPrefab[UnityEngine.Random.Range(0, _itemPrefab.Length)];
                    InventoryManager.instance.AddItem(ItemPrefab);
                    Debug.Log("Item added to inventory.");
                }
            }
        }
        
    }
}
using System;
using UnityEditor.UIElements;
using UnityEngine;

namespace DefaultNamespace.Delivery
{
    public class HomeBuyer : MonoBehaviour
    {
        [SerializeField] private string _runeColor;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(_runeColor))
            {
                Debug.Log(_runeColor);
                Destroy(other.gameObject, 1f);
            }
        }
    }
}
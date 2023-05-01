using DefaultNamespace;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float attackRate = 3f;
    public float CurrentDamage = 10f;
    public float colliderRadius = 1f;
    public LayerMask enemyLayer;

    private HeroController _heroController;

    private float nextAttackTime = 0f;
    [SerializeField] private Collider2D weaponCollider;

    private void Start()
    {
        _heroController = FindObjectOfType<HeroController>();
        weaponCollider = GetComponent<Collider2D>();
        //CurrentDamage = _heroController.CurrentHeroDamage;

    }

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, colliderRadius, enemyLayer);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                EnemyController enemy = collider.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    Debug.Log("Take Damage");
                    enemy.TakeDamageEnemy(CurrentDamage);
                }
            }
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, colliderRadius);
    }
}
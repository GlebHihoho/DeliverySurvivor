using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class ColliderKnife : MonoBehaviour
    {
        public float radius = 5f;
        public float arcAngle = 90f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            float startAngle = transform.eulerAngles.z - arcAngle / 2f;
            float endAngle = transform.eulerAngles.z + arcAngle / 2f;
            Handles.DrawWireArc(transform.position, Vector3.forward, Quaternion.Euler(0, 0, startAngle) * Vector3.up, arcAngle, radius);

            Vector3 startDir = Quaternion.Euler(0, 0, startAngle) * Vector3.up;
            Vector3 endDir = Quaternion.Euler(0, 0, endAngle) * Vector3.up;
            Gizmos.DrawLine(transform.position, transform.position + startDir * radius);
            Gizmos.DrawLine(transform.position, transform.position + endDir * radius);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("ha");
                Vector2 collisionPoint = other.ClosestPoint(transform.position);
                Vector2 direction = collisionPoint - (Vector2)transform.position;
                float angle = Vector2.Angle(transform.up, direction);
                if (angle < arcAngle / 2f && direction.magnitude < radius)
                {
                    Debug.Log("haafwafwafawfawf");
                }
            }
        }
    }

}
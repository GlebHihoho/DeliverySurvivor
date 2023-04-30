using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 5f;
    [SerializeField]private float _currentspeed; // movement speed
    private bool isFacingRight = true; // flag for character direction

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move the character in the direction of arrow keys or WASD keys
        Vector3 direction = new Vector3(horizontal, vertical, 0f);
        transform.position += direction * _currentspeed * Time.deltaTime;
        
        if ((horizontal > 0 && !isFacingRight) || (horizontal < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void ChangeSpeed(float _changeSpeed)
    {
        _currentspeed /= _changeSpeed / 100 + 1;
    }

    public void ReturnSpeed()
    {
        _currentspeed = _startSpeed;
    }
}

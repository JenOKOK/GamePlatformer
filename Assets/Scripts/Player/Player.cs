using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerJump), typeof(PlayerAttack))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _distnceOfKnockback;

    private Rigidbody2D _rigidbody;

    public event UnityAction Die;


    public Rigidbody2D RigidbodyPlayer { get => _rigidbody; private set => _rigidbody = value; }

    private void Awake()
    {
        RigidbodyPlayer = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _rigidbody.AddForce(-transform.right * _distnceOfKnockback * Time.deltaTime, ForceMode2D.Impulse);
        if (_health <= 0)
        {
            Die?.Invoke();
        }

    }

}

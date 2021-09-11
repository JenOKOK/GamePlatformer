using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, ITargetForDamage
{
    [SerializeField] private int _health;
    [SerializeField] private float _distnceOfKnockback;

    private Rigidbody2D _rigidbody;

    public Rigidbody2D RigidbodyEnemy { get => _rigidbody; private set => _rigidbody = value; }

    private void Awake()
    {
        RigidbodyEnemy = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        RigidbodyEnemy.AddForce(transform.right * _distnceOfKnockback * Time.deltaTime, ForceMode2D.Impulse);
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

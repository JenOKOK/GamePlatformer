using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMoveSystem : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _targetLeft;
    [SerializeField] private Transform _targetRight;

    private Enemy _enemy;
    private bool _isLeft = true;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isLeft = !_isLeft;
        transform.Rotate(0f, 180f, 0f);
    }

    public void MovetSetDirection()
    {
        if (_isLeft)
        {
            MoveToTarget(_targetLeft.position);
        }
        else if (!_isLeft)
        {
            MoveToTarget(_targetRight.position);
        }
    }

    private void MoveToTarget(Vector2 targetPosition)
    {
        Vector2 moveBetweenTarget = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.fixedDeltaTime);
        _enemy.RigidbodyEnemy.MovePosition(moveBetweenTarget);
    }
}

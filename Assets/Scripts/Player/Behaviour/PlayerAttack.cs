using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _rangeAttack;
    [SerializeField] private float _timeBetweenAttacks;
    [SerializeField] private Vector2 _attackOffset;

    private Player _player;
    private float _delayBetweenAttacks;

    public event UnityAction AnimationAttack;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    { 
        if (Input.GetMouseButtonDown(0) && Time.time >= _delayBetweenAttacks)
        {
            AnimationAttack?.Invoke();
            _delayBetweenAttacks = Time.time + _timeBetweenAttacks;
        }       
    }

    public void Attack()
    {
        ResetSpeedForAttack();
        foreach (Collider2D hit in HitsDetect(ComputePositionAttack()))
        {
            if (hit.TryGetComponent(out ITargetForDamage target))
            {
                target.TakeDamage(_damage);
            }
            
        }
    }
    private void ResetSpeedForAttack()
    {
        _player.RigidbodyPlayer.velocity = Vector2.zero;
    }

    private Collider2D[] HitsDetect(Vector2 attackPosition)
    {
        return Physics2D.OverlapCircleAll(attackPosition, _rangeAttack);
    }

    private Vector2 ComputePositionAttack()
    {
        Vector2 positionAttack = transform.position;
        positionAttack += (Vector2)transform.right * _attackOffset.x;
        return positionAttack;
    }


}

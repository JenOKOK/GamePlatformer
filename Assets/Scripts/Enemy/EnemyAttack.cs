using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _rangeAttack;
    [SerializeField] private int _damage;


    public void Attack()
    {
        foreach (Collider2D hit in HitsCheck())
        {
            if (hit.TryGetComponent(out Player player))
            {
                player.TakeDamage(_damage);
            }
        }
    }

    private Collider2D[] HitsCheck()
    {
        return Physics2D.OverlapCircleAll(transform.right + transform.position, _rangeAttack);
    }
}

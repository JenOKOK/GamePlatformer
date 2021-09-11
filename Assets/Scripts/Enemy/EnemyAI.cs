using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _distanceView;
    [SerializeField] private float _rangeAttack;

    public bool PlayerDetection()
    {
        foreach (RaycastHit2D item in ViewArea())
        {
            if (item.collider.TryGetComponent(out Player player))
            {
                return true;
            }
        }
        return false;
    }

    public void EnemyAttack(Player player, Animator animator)
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= _rangeAttack) 
        {
            animator.SetTrigger("Attack");
        }
    }


    private RaycastHit2D[] ViewArea() 
    {
        return Physics2D.RaycastAll(transform.position, transform.right, _distanceView);
    }

}

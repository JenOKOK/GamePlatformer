using UnityEngine;

public class AnimtionEventPlayerAttack : MonoBehaviour
{   
    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _playerAttack = GetComponentInParent<PlayerAttack>();
    }

    public void AttackInAnimation()
    {
        _playerAttack.Attack();
    }
}

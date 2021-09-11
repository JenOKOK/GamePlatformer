using UnityEngine;

[RequireComponent(typeof(PlayerRoll))]
public class PlayerAnimationSwither : MonoBehaviour
{
    private Animator _animator;
    private PlayerAttack _playerAttack;
    private PlayerJump _playerJump;
    private PlayerMovement _playerMovement;
    private PlayerRoll _playerRoll;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerJump = GetComponent<PlayerJump>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerRoll = GetComponent<PlayerRoll>();
    }

    private void OnEnable()
    {
        _playerAttack.AnimationAttack += Attack;
        _playerJump.AnimationJumpAndFall += JumpAndFall;
        _playerMovement.AnimationMove += Move;
        _playerRoll.AnimationRoll += Roll;
    }

    

    private void OnDisable()
    {
        _playerAttack.AnimationAttack -= Attack;
        _playerJump.AnimationJumpAndFall -= JumpAndFall;
        _playerMovement.AnimationMove -= Move;
        _playerRoll.AnimationRoll -= Roll;
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    private void JumpAndFall(bool check)
    {
        _animator.SetBool("PlayerIsGround", check);
    }

    private void Move(float speed)
    {
        _animator.SetFloat("Speed", speed);

    }
    private void Roll()
    {
        _animator.SetTrigger("Roll");
    }
}

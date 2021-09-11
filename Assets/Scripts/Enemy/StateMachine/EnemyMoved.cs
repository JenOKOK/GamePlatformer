using UnityEngine;

public class EnemyMoved : StateMachineBehaviour
{
    private EnemyMoveSystem _moveSystem;
    private EnemyAI _enemyAI;
    private Player _player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = FindObjectOfType<Player>();
        _moveSystem = animator.transform.parent.GetComponent<EnemyMoveSystem>();
        _enemyAI = animator.transform.parent.GetComponent<EnemyAI>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _moveSystem.MovetSetDirection();
        if (_enemyAI.PlayerDetection())
        {
            _enemyAI.EnemyAttack(_player, animator);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}

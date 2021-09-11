using UnityEngine;
using UnityEngine.Events;

public class PlayerJump : MonoBehaviour
{
    [Range(0f, 500f)][SerializeField] private float _forceJump;
    [SerializeField] private float _timeBetweenJump;
    [SerializeField] private float _distanceRayForChekConditionJump;

    private Player _player;
    private float _delayBetweenJump;
    
    public event UnityAction<bool> AnimationJumpAndFall;
    
    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        AnimationJumpAndFall?.Invoke(CheckJumpAndFallCondition());
    }

    private void FixedUpdate()
    {
        Jump(CheckJumpAndFallCondition());
    }
    private void Jump(bool condition)
    {
        if (condition && Input.GetButton("Jump") && Time.time >= _delayBetweenJump)
        {
            _player.RigidbodyPlayer.AddForce(Vector2.up * _forceJump * Time.deltaTime, ForceMode2D.Impulse);
            _delayBetweenJump = Time.time + _timeBetweenJump;
        }
    }
    private bool CheckJumpAndFallCondition()
    {
        foreach (RaycastHit2D hit in GroundCheck())
        {
            if (hit.collider.gameObject != gameObject)
            {    
                return true;
            }
            
        }
        return false;
    }
    private RaycastHit2D[] GroundCheck()
    {
        return Physics2D.RaycastAll(transform.position, Vector2.down, _distanceRayForChekConditionJump);
    }

    
}

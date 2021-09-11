using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimationSwither))]
public class PlayerMovement : MonoBehaviour
{
    [Range(1f, 10f)][SerializeField] private float _speed;
    [SerializeField] private float _smoothTime;
    [SerializeField] private float _maxSpeed;

    private Player _player;
    private float _horizontalDirectionMove;
    private bool _isRight = true;
    private Vector2 _velocity = Vector2.zero;
   
    public event UnityAction<float> AnimationMove;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _horizontalDirectionMove = Input.GetAxis("Horizontal");
        FlipSprite();
        AnimationMove?.Invoke(Mathf.Abs(TargetVelocity().x));
    }

    private void FixedUpdate()
    {
        Move(); 
    }

    private void Move()
    {
        _player.RigidbodyPlayer.velocity = Vector2.SmoothDamp(_player.RigidbodyPlayer.velocity, TargetVelocity(), ref _velocity, _smoothTime, _maxSpeed);     
    }

    private Vector2 TargetVelocity()
    {
        return Vector2.right * _horizontalDirectionMove * _speed;
    }

    private void FlipSprite()
    { 
        if (_horizontalDirectionMove > 0 && !_isRight)
        {
            RotateFlip();   
        }
        else if (_horizontalDirectionMove < 0 && _isRight)
        {
            RotateFlip();
        }
    }

    private void RotateFlip()
    {
        transform.Rotate(0f, 180f, 0f);
        _isRight = !_isRight;
    }



}

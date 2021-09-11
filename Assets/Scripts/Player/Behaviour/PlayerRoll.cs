using UnityEngine;
using UnityEngine.Events;

public class PlayerRoll : MonoBehaviour
{
    [SerializeField] private float _forceRoll;

    private Player _player;


    public event UnityAction AnimationRoll;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            AnimationRoll?.Invoke();
            _player.RigidbodyPlayer.AddForce(transform.right * _forceRoll * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}

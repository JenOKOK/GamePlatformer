using UnityEngine;

public class WaterDaeth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            Time.timeScale = 0f;
            
        }
    }
}

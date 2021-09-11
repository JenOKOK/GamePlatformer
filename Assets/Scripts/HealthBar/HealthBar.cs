using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;



    public void SetHealth(int health)
    {
        _slider.value = health;
    }
}

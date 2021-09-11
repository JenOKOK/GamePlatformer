using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float _parallaxStrenght;
    [SerializeField] private bool _disableVerticalParallax;

    private Vector3 _targetPreviusPosition;
    

    private void Awake()
    {

        _targetPreviusPosition = Camera.main.transform.position;

    }

    private void Update()
    {
        Vector3 delta = Camera.main.transform.position - _targetPreviusPosition;

        if (_disableVerticalParallax)
        {
            delta.y = 0;
        }

        _targetPreviusPosition = Camera.main.transform.position;
        transform.position += delta * _parallaxStrenght;
    }
}

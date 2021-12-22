using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneChanging : MonoBehaviour
{
    private float _reducingScalePerSecond = 3f;
    private Transform _currentTransform;
    private float _defaultZoneScale;

    void Start()
    {
        _currentTransform = GetComponent<Transform>();
        _defaultZoneScale = _currentTransform.localScale.x;
    }   

    // Update is called once per frame
    void Update()
    {
        if (_currentTransform.localScale.x > 0)
        {
            var scale = _reducingScalePerSecond * Time.deltaTime;
            _currentTransform.localScale -= new Vector3(scale, scale, scale);
        }
    }

    //add 10% for zone scale 
    public void Increase()
    {
        var scale = _defaultZoneScale * 10 / 100; 
        _currentTransform.localScale += new Vector3(scale, scale, scale);
    }
}

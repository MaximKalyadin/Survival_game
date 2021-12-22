using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointsManager : MonoBehaviour
{
    public float MaxHealthPointsValue = 100;
    public GameObject HealthBar;

    private RectTransform _healthBarRectTransform;
    private float _currentHealthPoints;
    private float _defaultHealthBarRectTransformAnchorMaxX;

    private void Start()
    {
        _currentHealthPoints = MaxHealthPointsValue;
        _healthBarRectTransform = HealthBar.GetComponent<RectTransform>();
        _defaultHealthBarRectTransformAnchorMaxX = _healthBarRectTransform.anchorMax.x;
    }
    
    public void AddHealthPoints(float healthPoints)
    {
        if (_currentHealthPoints + healthPoints > MaxHealthPointsValue)
            _currentHealthPoints = MaxHealthPointsValue;
        else
            _currentHealthPoints += healthPoints;

        SetupHealthBar();
    }

    /// <returns>true if character is dead</returns>
    public bool ReduceHealthPoints(float reduceHealthPoints)
    {
        _currentHealthPoints -= reduceHealthPoints;

        SetupHealthBar();

        return _currentHealthPoints <= 0;
    }

    private void SetupHealthBar()
    {
        _healthBarRectTransform.anchorMax = new Vector2(_defaultHealthBarRectTransformAnchorMaxX * _currentHealthPoints / MaxHealthPointsValue, _healthBarRectTransform.anchorMax.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ThisDestructibleItem : MonoBehaviour
{
    public DestructibleItemScriptableObject destructibleItemScriptableObject;
    public GameObject healthBarCanvasPrefab;

    private bool _showHealthBar;
    private bool _healthBarIsShowed;

    private float _healthPoints;
    private float _defaultHealthBarCanvasXScale;

    private GameObject _healthBarCanvas;

    private void Start()
    {
        _healthPoints = destructibleItemScriptableObject.healthPoints;

        SetupHealthBarCanvas();
    }

    private void SetupHealthBarCanvas()
    {
        var currentGameObjectTransform = GetComponent<Transform>();
        var currentGameObjectTriggerBoxCollider = GetComponent<BoxCollider>();

        _healthBarCanvas = PrefabUtility.InstantiatePrefab(healthBarCanvasPrefab) as GameObject;

        //установка позиции канваса над бокс коллайдером объекта
        _healthBarCanvas.transform.position = new Vector3(
           currentGameObjectTransform.position.x,
           currentGameObjectTriggerBoxCollider.size.y,
           currentGameObjectTransform.position.z - 0.5f
        );

        //установка ширины канваса равной ширине коллайдера
        _healthBarCanvas.transform.localScale = new Vector3( 
            currentGameObjectTriggerBoxCollider.size.x / 600,
            _healthBarCanvas.transform.localScale.y,
            _healthBarCanvas.transform.localScale.z
        );

        _defaultHealthBarCanvasXScale = _healthBarCanvas.transform.localScale.x;
        _healthBarCanvas.SetActive(false);
    }

    private void Update()
    {
        if (_showHealthBar && !_healthBarIsShowed)
        {
            _healthBarCanvas.SetActive(true);
            _healthBarIsShowed = true;
        }
    }

    public void ReduceHealthPoints(float damage)
    {
        if(_healthPoints - damage <= 0)
        {
            Destroy(this.gameObject);
            Destroy(this._healthBarCanvas);

            return;
        }

        _showHealthBar = true;
        _healthPoints -= damage;

        _healthBarCanvas.transform.localScale -= new Vector3(_defaultHealthBarCanvasXScale * damage / destructibleItemScriptableObject.healthPoints, 0f, 0f);
    }
}

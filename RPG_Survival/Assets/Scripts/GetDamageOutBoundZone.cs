using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetDamageOutBoundZone : MonoBehaviour
{
    public GameObject Canvas;

    private SphereCollider _currentGameObjectCollider;
    private HealthPointsManager _healthPointsManager;

    private bool _stopChecking;
    private float _time;

    public float _defaultDamage = 5;

    void Start()
    {
        _currentGameObjectCollider = GetComponent<SphereCollider>();
        _healthPointsManager = Canvas.GetComponent<HealthPointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_time > 0f)
        {
            _time -= Time.deltaTime;
        }
        else
        {
            float scale = _currentGameObjectCollider.transform.localScale.x;
            Transform tempTrans = _currentGameObjectCollider.transform.parent;
            while (tempTrans != null)
            {
                scale = scale * tempTrans.localScale.x;
                tempTrans = tempTrans.parent;
            }

            var intersectsColliders = Physics.OverlapSphere(_currentGameObjectCollider.transform.position, _currentGameObjectCollider.radius * scale);

            if (!intersectsColliders.Any(collider => collider.gameObject.tag.Equals("Player")) && !_stopChecking)
            {
                if (_healthPointsManager.ReduceHealthPoints(_defaultDamage))
                {
                    _stopChecking = true;
                    Debug.LogWarning("Ti umer");
                }
            }

            _time = 1;
        }
    }

    public void setDefaultDamage()
    {
        _defaultDamage = 5;
    }

    public void ChangeDamage(float damage)
    {
        _defaultDamage *= damage;
    }
}

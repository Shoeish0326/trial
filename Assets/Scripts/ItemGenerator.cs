using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] float _generateSpan = 5.0f;
    [SerializeField] GameObject _itemPrefab;
    Vector3 _popPoint;
    Transform _startPtInfo;
    Transform _goalInfo;
    void Start()
    {
        _startPtInfo = GameObject.Find("Start").transform;
        _goalInfo = GameObject.Find("Goal").transform;
        _popPoint = new Vector3(_goalInfo.position.x, _goalInfo.position.y+5, _startPtInfo.position.z);
        for (int i = 1; i < (_goalInfo.position.z - _startPtInfo.position.z) / _generateSpan; i++)
        {
            _popPoint.z += _generateSpan;
            Instantiate(_itemPrefab, _popPoint, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}

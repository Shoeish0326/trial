using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float _accerateMagnification = 1.0f;
    GameObject _target;
    Transform _myTransform;
    Rigidbody _rb;
    float[] _destination  = new float[3];
    
    bool _moving = false;

    void Awake()
    {
        
    }
    void Start()
    {
        _target = GameObject.Find("Goal");
        _rb = this.GetComponent<Rigidbody>();
        if (_target == null)
        {
            Debug.Log("_target is null");
        }
        _myTransform = this.GetComponent<Transform>();
        _destination[0] = _target.transform.position.x;
        _destination[1] = _target.transform.position.y;
        _destination[2] = _target.transform.position.z;
        if (_myTransform.position.x == _destination[0] && _myTransform.position.y == _destination[1] && _myTransform.position.z == _destination[2])
        {
            _moving = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float _rootX = _destination[0] - _myTransform.position.x;
        float _rootY = _destination[1] - _myTransform.position.y;
        float _rootZ = _destination[2] - _myTransform.position.z;
        Vector3 _root = new Vector3(_rootX*_accerateMagnification, _rootY * _accerateMagnification, _rootZ * _accerateMagnification);
        if(_root == Vector3.zero)
        {
            _moving = false;
        }
        if(_moving)
        {
            _rb.AddForce(_root, ForceMode.Impulse);
            Debug.Log("óÕÇÕê≥ÇµÇ≠â¡Ç¶ÇÁÇÍÇƒÇ¢Ç‹Ç∑");
        }
        Debug.Log($"_moving:{_moving}");
    }
}

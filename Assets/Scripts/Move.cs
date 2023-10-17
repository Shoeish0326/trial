using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float _accerateMagnification = 1.0f;
    GameObject _target;
    Transform _myTransform;
    Rigidbody _rb;
    
    [SerializeField] int _iniLaneNo = 1;
    int _gameScore = 0;
    int _nowlaneNo = 0;
    float[] _destination  = new float[3];
    float _axisH = 0f;
    float _axisV = 0f;
    bool _moveable = false;
    bool _sidemoveinterval = false;
    
    bool _moving = false;
    public int Score
    {
        get { return _gameScore; }
        set { _gameScore = value; }
    
    }


    void Awake()
    {
        
    }
    void Start()
    {
        _moveable = true;
        _target = GameObject.Find("Goal");
        _rb = this.GetComponent<Rigidbody>();
        _nowlaneNo = _iniLaneNo;
        if (_target == null)
        {
            Debug.Log("_target is null");
        }
        _myTransform = this.GetComponent<Transform>();
        _destination[0] = _target.transform.position.x;
        _destination[1] = _target.transform.position.y;
        _destination[2] = _target.transform.position.z;
        //if (_myTransform.position.x == _destination[0] && _myTransform.position.y == _destination[1] && _myTransform.position.z == _destination[2])
        //{
        //    _moving = false;
        //}
        //else
        //{
        //    _moving = true;
        //}

        //if (_myTransform.position.z == _destination[2])
        //{
        //    _moving = false;
        //}

    }

    // Update is called once per frame
    void Update()
    {
        _axisH = Input.GetAxisRaw("Horizontal");
        _axisV = Input.GetAxis("Vertical");
        Vector3 _position = _myTransform.position;
        if(_axisH < 0 && !_sidemoveinterval)
        {
            if(_position.x - 50 > -100)
            {
                _position.x -= 50;
            }
            
            _myTransform.position = _position;
            _sidemoveinterval = true;
        }
        else if(_axisH > 0 && !_sidemoveinterval)
        {
            if(_position.x + 50 < 100)
            {
                _position.x += 50;
            }
            
            _myTransform.position = _position;
            _sidemoveinterval = true;
        }
        if(_axisH == 0)
        {
            _sidemoveinterval = false;
        }
        //float _rootX = _destination[0] - _myTransform.position.x;
        //float _rootY = _destination[1] - _myTransform.position.y;
        //float _rootZ = _destination[2] - _myTransform.position.z;

        //Vector3 _root = new Vector3(0, _rootY , _axisV);
        //_root /= _root.magnitude;
        //if(_root == Vector3.zero)
        //{
        //    _moving = false;
        //    _rb.velocity = Vector3.zero;
        //}
        //if(_rootZ == 0)
        //{
        //    _moving = false;
        //    _rb.velocity = Vector3.zero;
        //}

        //if (_moving)
        //{
        //    _rb.velocity = _root*_accerateMagnification;
        //    //_rb.AddForce(_root, ForceMode.Acceleration);
        //    Debug.Log("力は正しく加えられています");
        //}
        //if(Input.GetAxisRaw("Horizontal") < 0)
        //{
        //    _nowlaneNo -= 1;
        //    -= -50;
        //}
        //else if(Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    _nowlaneNo += 1;
        //}
        //if(_nowlaneNo == 0)
        //{

        //}
        //Debug.Log($"_moving:{_moving}");
        //Debug.Log($"_root:{_root}");
        Debug.Log($"_movable{_moveable}");
    }
    private void FixedUpdate()
    {
        
        //_rb.AddForce(_root * _accerateMagnification, ForceMode.Force);
        if(_moveable)
        {
            _rb.velocity = new Vector3(0, 0, _axisV * _accerateMagnification);
            Debug.Log("現在、速度は適切に更新されています。");
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("colliderとの衝突は正常に感知されています。");
        if (other.gameObject.tag == "Goal")
        {
            _moving = false;
            _moveable = false;

            Debug.Log("目的地上にいます");
        }
        if (other.gameObject.tag == "Item")
        {
            Debug.Log("i");
            if (other.gameObject.GetComponent<ItemEffect>() != null)
            {
                Debug.Log("i2");
                ItemEffect item = other.gameObject.GetComponent<ItemEffect>();
                if (item.teachEffect == ItemEffectCategory.getscore)
                {
                    _gameScore += item.Score;
                }
                
            }
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
                
                    
    }
}

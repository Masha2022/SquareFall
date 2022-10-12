using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SquareFallrScript : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rightEnd;
    [SerializeField] private Vector3 _leftEnd;

    private float _currentTime;
    private bool _isMoveRight = true;
    private float _timeForDistance;
    
    void Start()
    {
        _sphere = Instantiate(_sphere, new Vector3(20, -80, 20), Quaternion.Euler(0, 0, 0));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isMoveRight = !_isMoveRight;
        }

        if (!_isMoveRight)
        {
            _currentTime -= Time.deltaTime;
        }

        if (_isMoveRight)
        {
            _currentTime += Time.deltaTime;
        }

        _timeForDistance = Vector3.Distance(_leftEnd, _rightEnd) / _speed;
        var countPingPong = Mathf.PingPong(_currentTime, _timeForDistance) / _timeForDistance;
       
        transform.position = Vector3.Lerp(_leftEnd, _rightEnd, countPingPong);
    }
}
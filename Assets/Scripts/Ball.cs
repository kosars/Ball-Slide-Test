using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public event Action OnBallDestroy;
    [SerializeField] private BallSettings _ballSettings;
    [SerializeField] private Rigidbody _rigidbody;

    private float _launchSpeed;
    private bool _isLaunched;
    private void Awake()
    {
        _isLaunched = false;
        _launchSpeed = _ballSettings.LaunchSpeed;
        if (null == _rigidbody)
            _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            OnBallDestroy?.Invoke();
            Destroy(gameObject);
        }
        else if (collision.gameObject.TryGetComponent<EnemyBlock>(out EnemyBlock block))
        {
            OnBallDestroy?.Invoke();
            block.DestroyBlock();
            Destroy(gameObject);
        }
    }
    public void Launch(Vector3 lauchPosition)
    {
        if (_isLaunched) return;

        Vector3 offset = lauchPosition - transform.position;
        _rigidbody.AddForce(offset * _launchSpeed, ForceMode.Force);
        _isLaunched = true;
        
    }
}

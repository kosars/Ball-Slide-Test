using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSettings _playerSettings;
    [SerializeField] private Rigidbody _rigidbody;

    private PlayerInput _playerInput;
    private float _speedModifier;

    private void Awake()
    {
        //initialization
        _playerInput = new PlayerInput(Camera.main);
        _rigidbody = GetComponent<Rigidbody>();
        _speedModifier = _playerSettings.SpeedModifier;
    }

    // Update is called once per frame
    private void Update()
    {
        _playerInput.ReadInput();
    }
    private void FixedUpdate()
    {
        Move(_playerInput.MoveDirection);
    }
    private void OnEnable() =>PlayerInput.OnDrop += HandleDrop;
    private void OnDisable() => PlayerInput.OnDrop -= HandleDrop;
    private void HandleDrop() => FindObjectOfType<Ball>()
        .GetComponent<Ball>()
        .Launch(transform.position);

    private void Move(Vector3 direction)
    {
        Vector3 velocity = new Vector3(direction.x - _rigidbody.position.x, 0, direction.z - _rigidbody.position.z);
        _rigidbody.velocity = velocity * _speedModifier;
    }
}

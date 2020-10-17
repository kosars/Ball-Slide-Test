using UnityEngine;

public class ArrowRenderer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _ballTransform;
    private float _radius;
    private void Awake()
    {
        if (null == _transform)
            _transform = transform;
        if (null == _renderer)
            _renderer = GetComponent<SpriteRenderer>();
        if (null == _playerTransform)
            _playerTransform = GameObject.Find("Player").transform;
        _radius = _transform.localPosition.z;
        HandleDrop();
    }
    private void Update()
    {
        if (_playerTransform == null)
            return;
        if(_ballTransform == null)
            _ballTransform = FindObjectOfType<Ball>().transform;

        Vector3 vector = _playerTransform.position - _ballTransform.position;
        float angle = Mathf.Atan2(vector.z, vector.x) * Mathf.Rad2Deg;
        _transform.localPosition = UpdateCirclePosition(angle,_radius);
        angle = -angle;
        _transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.up) * Quaternion.AngleAxis(90, Vector3.right);
    }

    private void OnEnable()
    {
        PlayerInput.OnDrag += HandleDrag;
        PlayerInput.OnDrop += HandleDrop;
    }

    private void OnDisable()
    {
        PlayerInput.OnDrag -= HandleDrag;
        PlayerInput.OnDrop -= HandleDrop;
    }

    private void HandleDrag() =>_renderer.enabled = true;
    private void HandleDrop() => _renderer.enabled = false;

    private Vector3 UpdateCirclePosition(float angle, float radius)
    {
        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        return new Vector3(x, 0f, y);
    }
}

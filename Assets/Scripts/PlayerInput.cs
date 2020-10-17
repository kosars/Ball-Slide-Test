using UnityEngine;
using System;

public class PlayerInput 
{
    public static event Action OnDrag;
    public static event Action OnDrop;

    private static bool _isLock;

    private Vector3 _deltaPosition;
    private Camera _mainCamera;
    private Plane _plane;
    public PlayerInput(Camera camera)
    {
        _mainCamera = camera;
        _plane = new Plane(Vector3.up, Vector3.zero);
    }

    public Vector3 MoveDirection { get; private set; }

    public static void LockInput() => _isLock = true;
    public static void UnlockInput() => _isLock = false;
    public void ReadInput()
    {
        if (_isLock)
            return;
#if UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            OnDrag?.Invoke();
        }
        else if (Input.GetMouseButton(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            float distance;
            if(_plane.Raycast(ray, out distance))
            {
                MoveDirection = ray.GetPoint(distance);
            }
           
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MoveDirection = Vector3.zero;
            OnDrop?.Invoke();
        }

#endif
#if UNITY_ANDROID
        //for mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Ray ray = _mainCamera.ScreenPointToRay(touch.position);
                float distance;
                if (_plane.Raycast(ray, out distance))
                {
                    MoveDirection = ray.GetPoint(distance);
                }
            }
            else if(touch.phase == TouchPhase.Began)
            {
                OnDrag?.Invoke();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                //MoveDirection = Vector3.zero;
                OnDrop?.Invoke();

            }
        }
#endif
    }
    

    
}

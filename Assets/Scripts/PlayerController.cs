using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _MinSpeed = 1.0f;
    [SerializeField]
    private float _MaxSpeed = 10.0f;
    [SerializeField]
    private float _SpeedupRate = 1.0f;
    [SerializeField]
    private float _StrafeSpeed = 0.8f;

    [SerializeField]
    private float _MouseSensitivity = 1.0f;

    private float _ForwardMotion = 0.0f;
    private float _StrafeMotion = 0.0f;
    private float _VerticalMotion = 0.0f;

    private float _RotateYawRoll = 0.0f;
    private float _RotatePitch = 0.0f;

    private float _CurrentSpeed = 0.0f;
    private int _CurrentDelta = 0;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _CurrentSpeed = _MinSpeed;
    }

    void Update()
    {
        _ForwardMotion = -Input.GetAxisRaw("Forward");
        _StrafeMotion = Input.GetAxisRaw("Right");
        _VerticalMotion = Input.GetAxisRaw("Up");
        _RotateYawRoll = Input.GetAxis("Mouse X");
        _RotatePitch = -Input.GetAxis("Mouse Y");
        _CurrentSpeed = Mathf.Clamp(_CurrentSpeed + Input.mouseScrollDelta.y * _SpeedupRate, _MinSpeed,  _MaxSpeed);

        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Roll"))
            transform.Rotate((Vector3.right * _RotatePitch + Vector3.forward * _RotateYawRoll) * _MouseSensitivity * Time.fixedDeltaTime);
        else
            transform.Rotate((Vector3.right * _RotatePitch + Vector3.up * _RotateYawRoll) * _MouseSensitivity * Time.fixedDeltaTime);

        transform.position += (-transform.forward * _ForwardMotion + transform.right * _StrafeMotion * _StrafeSpeed + transform.up * _VerticalMotion * _StrafeSpeed) * _CurrentSpeed * Time.fixedDeltaTime;
    }
}

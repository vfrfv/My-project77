using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]
public class Catapult : MonoBehaviour
{
    private SpringJoint _joint;
    private Rigidbody _rigidbody;
    private float _springForce = 9;

    private KeyCode _activation = KeyCode.Q;
    private KeyCode _deactivation = KeyCode.E;

    public event Action CameBack;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _joint = GetComponent<SpringJoint>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_activation))
        {
            _joint.spring = _springForce;
            _rigidbody.WakeUp();
        }

        if (Input.GetKeyDown(_deactivation))
        {
            _joint.spring = 0;
            _rigidbody.WakeUp();

            CameBack?.Invoke();
        }
    }
}

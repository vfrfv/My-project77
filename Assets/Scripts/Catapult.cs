using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]
public class Catapult : MonoBehaviour
{
    public Action CameBack;

    private SpringJoint _joint;
    private Rigidbody _rigidbody;
    private float _springForce = 9;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _joint = GetComponent<SpringJoint>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _joint.spring = _springForce;
            _rigidbody.WakeUp();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _joint.spring = 0;
            _rigidbody.WakeUp();

            CameBack?.Invoke();
        }
    }
}

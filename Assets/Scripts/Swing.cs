using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Swing : MonoBehaviour
{
    [SerializeField] private float _effort = 500f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           _rigidbody.AddForce(transform.forward * _effort);
        }
    }
}

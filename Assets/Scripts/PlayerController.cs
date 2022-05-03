using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;


    [SerializeField] private float _movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_fixedJoystick.Horizontal*_movementSpeed , _rigidbody.velocity.y, _fixedJoystick.Vertical * _movementSpeed );

        if (_fixedJoystick.Horizontal !=0 || _fixedJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetBool("started", true);
        }

        else
        {
            _animator.SetBool("started", false);
        }
    }
}

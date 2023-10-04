using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Tooltip("Control de velocidad de movimiento")]
    [SerializeField] private float _playerSpeed = 5f;
    [Tooltip ("Control de salto del personaje")]
    [SerializeField] private float _jumpForce = 5;
    private float _playerInputh;
    //private float _playerInputv;
    //private GroundSensor _sensor;
    private Rigidbody2D _rBody2D;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        //_sensor = GetComponentInChildren<GroundSensor>();
        _animator = GetComponentInChildren<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        Movement();

        if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        //_rBody2D.AddForce(new Vector2(_playerInputh * _playerSpeed, 0), ForceMode2D.Impulse);

        _rBody2D.velocity = new Vector2(_playerInputh * _playerSpeed, _rBody2D.velocity.y);
    }

    void Movement()
    {
        _playerInputh = Input.GetAxis("Horizontal");

        if(_playerInputh != 0)
        {
            _animator.SetBool("isRunning", true);
        }
        
        if(_playerInputh == 0)
        {
            _animator.SetBool("isRunning", false);
        }
        /*_playerInputv = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(_playerInputh, _playerInputv) * _playerSpeed * Time.deltaTime);*/
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        if(_playerInputh != 0)
        {
            _animator.SetBool("isJumping", true);
        }
        if(_playerInputh == 0)
        {
            _animator.SetBool("isJumping", false);
        }
    }
}

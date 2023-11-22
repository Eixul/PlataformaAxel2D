using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Tooltip("Control de velocidad de movimiento")]
    [SerializeField] private float _playerSpeed = 5f;
    [Tooltip ("Control de salto del personaje")]
    [SerializeField] private float _jumpForce = 5;
    private float _playerInputh;
    //private float _playerInputv;
    private GroundSensor _sensor;
    private Rigidbody2D _rBody2D;
    [SerializeField] private Animator _animator;
    bool facingRight = true;
    [SerializeField] private PlayableDirector _director;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private int health;
    [SerializeField] private int numDeVidas;

    public SoundManager soundManager;

    int _counterEstrellas;
    private StarCollect estrella;
    
    // Start is called before the first frame update
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        _sensor = GetComponentInChildren<GroundSensor>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        Debug.Log(GameManager.instance.vidas);
    }



    // Update is called once per frame
    void Update()
    {
        Movement();

        if(Input.GetButtonDown("Jump") && _sensor._isGrounded)
        {
            Jump();
        }

        if(Input.GetButtonDown("Fire2"))
        {
            _director.Play();
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

        if (_playerInputh < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (_playerInputh > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        if(_playerInputh != 0)
        {
            _animator.SetBool("isJumping", true);
            soundManager.JumpSound();
        }
        if(_playerInputh == 0)
        {
            _animator.SetBool("isJumping", false);
        }


        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameManager.instance.GameOver();
        if(other.gameObject.layer == 6)
        {
            SoundManager.instance.DeathSound();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "StarColl")
        {
            StarCollect estrella = collision.gameObject.GetComponent<StarCollect>();
            estrella.Coger();
            _counterEstrellas++;
            Debug.Log(_counterEstrellas);
            //contador.text = "Coiners" + _counterEstrellas;
        }
        
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}

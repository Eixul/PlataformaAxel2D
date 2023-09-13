using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    private float _playerInputh;
    private float _playerInputv;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        _playerInputh = Input.GetAxis("Horizontal");
        _playerInputv = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(_playerInputh, _playerInputv) * _playerSpeed * Time.deltaTime);
    }
}

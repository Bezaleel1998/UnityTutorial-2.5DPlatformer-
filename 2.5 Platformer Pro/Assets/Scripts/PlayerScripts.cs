using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{

    [Header("Player Variable")]
    private CharacterController _characterController;
    private float _horizontalInput;
    private Vector3 velocity;
    private float _dirY;
    [SerializeField]
    private bool _canDoubleJump = false;
    [Space(5)]
    [Header("Changeable Player Variable")]
    [SerializeField] private float _playerSpd = 10f;
    [SerializeField] private bool _isGrouded;
    [SerializeField] private float _gravityValue = 1;
    [SerializeField] private float _jumpSpeed = 15.0f;

    [Space(5)]
    [Header("GameObject Caller")]
    private GameManager _gM;

    void Awake()
    {

        _characterController = this.GetComponent<CharacterController>();
        _gM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    void Update()
    {

        PlayerController();

    }

    #region Player_Movement

    void PlayerController()
    {
        //check if player is on the ground
        _isGrouded = _characterController.isGrounded;

        PlayerMovement();

    }

    void PlayerMovement()
    {

        //Get Horizontal Input
        _horizontalInput = Input.GetAxis("Horizontal");

        //Define dir from that input
        Vector3 dir = new Vector3(_horizontalInput, 0f, 0f);
        //player Velocity
        velocity = dir * _playerSpd;

        //apply Gravity
        PlayerGravity();
        
        //temporary velocity.y value so it can remamber the value everytime
        velocity.y = _dirY;

        //move based on that direction
        _characterController.Move(velocity * Time.deltaTime);

    }

    void PlayerGravity()
    {

        if (_isGrouded)
        {

            //JumpFunction
            PlayerJump();

        }
        else
        {

            DoubleJump();
            //apply Gravity
            _dirY -= _gravityValue;

        }

    }

    void PlayerJump()
    {

        //you can Jump Here while pressing space on keyboard
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _dirY = _jumpSpeed;
            _canDoubleJump = true;
        }

    }

    void DoubleJump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (_canDoubleJump == true)
            {

                _dirY += _jumpSpeed;
                _canDoubleJump = false;
                
            }

        }

    }

    #endregion


    #region TriggerEnter, TriggerStay or TriggerExit

    private void OnTriggerEnter(Collider other)
    {
        


    }

    #endregion

}

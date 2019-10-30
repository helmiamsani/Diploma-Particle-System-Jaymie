using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    #region Public Variables
    public float runSpeed = 60f;
    public float moveSpeed = 50f;
    public float aimingSpeed = 25f;
    public float curSpeed;
    public float gravity = -10f;
    public float jumpHeight = 15f;
    public float walkMovement = 5f;
    #endregion

    #region Private Variables
    private PlayerInput _plyrInput;
    private CharacterController _charController;
    private Vector3 motion; // Is the movement offset per frame
    private bool _isJumping;
    private float _currentJumpHeight;

    private float _horizontal;
    private float _vertical;
    private float _walkMovement;
    private bool _fire1;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _plyrInput = GetComponent<PlayerInput>();
        _charController = GetComponent<CharacterController>();
        _walkMovement = walkMovement;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _horizontal = _plyrInput.moveToward; // get horizontal input.
        _vertical = _plyrInput.moveSide; // get vertical input.


        Vector3 inputDir = new Vector3(_horizontal, 0f, _vertical);
        inputDir = transform.TransformDirection(inputDir);

        if (_plyrInput.scope) // when scoping.
        {
            curSpeed = aimingSpeed; // current speed changes to aim
        }
        else // else
        {
            curSpeed = moveSpeed; // current speed changes to normal speed
        }

        if(!_plyrInput.scope && _plyrInput.run) // when run
        {
            curSpeed = runSpeed; // current speed changes to run speed
        }

        Move(inputDir.x, inputDir.z, curSpeed);

        // If is Grounded
        if (_charController.isGrounded)
        {
            // .. And jump?
            if (_plyrInput.jump)
            {
                Jump(jumpHeight);
            }

            // Cancel the y velocity
            motion.y = 0f;

            // Is jumping bool set to true
            if (_isJumping)
            {
                // Set jump height
                motion.y = _currentJumpHeight;
                // Reset back to false
                _isJumping = false;
            }


        }

        motion.y += gravity * Time.deltaTime;
        _charController.Move(motion * Time.deltaTime);
    }

    private void Move(float inputH, float inputV, float speed)
    {
        Vector3 direction = new Vector3(inputH, 0f, inputV);
        motion.x = direction.x * speed;
        motion.z = direction.z * speed;
    }

    public void Jump(float height)
    {
        _isJumping = true; // We are jumping!
        _currentJumpHeight = height;
    }
    #region Trash
    //private void Update()
    //{
    //    //DetailMovement();
    //}

    //void DetailMovement()
    //{
    //    if (curSpeed == moveSpeed)
    //    {
    //        Debug.Log("Time = " + Time.deltaTime);
    //        if (Time.time > walkMovement)
    //        {
    //            Debug.Log("Walk Movement = " + walkMovement);
    //            Debug.Log("Second Walk Movement = " + _walkMovement);
    //            if (this.gameObject.transform.localPosition.x <= 1.2f)
    //            {
    //                _rigid.AddForce(this.gameObject.transform.up * curSpeed);
    //                _rigid.useGravity = false;
    //            }
    //            else
    //            {
    //                _rigid.useGravity = true;
    //            }
    //            walkMovement = walkMovement + _walkMovement;
    //        }
    //    }
    //}
    #endregion
}

using UnityEngine;
using UnityEngine.InputSystem;
using KatamaryDamacy.Constant;
using UnityEngine.Events; 

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] GameObject playerShpere;
    [SerializeField] Camera playerCamera;

    [Header("Configuration")]
    [SerializeField] float rollSpeed = 10;
    [SerializeField] float lookSensitivity = 30;

    private bool _isInputEnabled;

    private Vector3 _forwardVector = Vector3.forward;
    private Vector3 _rightVector = Vector3.right;

    private float _horizontalDeltaMove;
    private float _verticalDeltaMove;
  
    private float _playerSize = 1.0f;
    public float PlayerSize
    {
        get => _playerSize;
        set  
        {
            _playerSize = value;
            OnPlayerSizeChanged.Invoke(_playerSize);
        }
    }
    public UnityEvent<float> OnPlayerSizeChanged;
 
    public void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.NewGame:
                PlayerSize = 0;
                _isInputEnabled = false;
                break;
            case GameState.ActiveGame:
                PlayerSize = transform.localScale.magnitude;
                _isInputEnabled = true;
                break;
            case GameState.Won:
                _isInputEnabled = false;
                break;
            case GameState.Lose:
                _isInputEnabled = false;
                break;
            default:
                break;
        }
    }

    private void Start()
    {
        //Get the rigidbody component
        playerRigidBody = GetComponent<Rigidbody>();
        if (playerRigidBody == null)
        {
            Debug.LogError($"Katameri {gameObject.name} does not have a rigidbody attached!");
            return;
        }
    }

    private void FixedUpdate()
    {
        if (!_isInputEnabled)
            return;

        // only move forward
        if (_verticalDeltaMove > 0)
        {
            transform.position = transform.position + _forwardVector * rollSpeed * _verticalDeltaMove * Time.fixedDeltaTime; ;
            transform.Rotate(_rightVector, rollSpeed * _verticalDeltaMove, Space.World);
        }

        // rotate camera in horizontal plane, to set where player moves
        if (_horizontalDeltaMove != 0)
        {
            _forwardVector = Quaternion.Euler(0.0f, lookSensitivity * _horizontalDeltaMove, 0.0f) * _forwardVector;
            _rightVector = Quaternion.Euler(0.0f, lookSensitivity * _horizontalDeltaMove, 0.0f) * _rightVector;
        }
    }

    // called by unity input system
    private void OnMove(InputValue movementValue)
    {
        var movementVector = movementValue.Get<Vector2>();
        _horizontalDeltaMove = movementVector.x;
        _verticalDeltaMove = movementVector.y;
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAGS.OBSTACLE_TAG))
        {
            // players can only attach objects smaller than playerSize
            if (collision.transform.localScale.magnitude > _playerSize)
                return;

            // stick to the player
            collision.transform.SetParent(transform);
            PlayerSize += collision.transform.localScale.magnitude;
        }
    }

    /// <summary>
    /// Gets the proxy forward vector of the object used for moving
    /// </summary>
    /// <returns>The proxy forward vector used for movement</returns>
    public Vector3 GetForwardVector()
    {
        return _forwardVector;
    }
}

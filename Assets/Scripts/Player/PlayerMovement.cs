using UnityEngine;

namespace Player
{
    /// <summary>
    ///    Class responsible for moving the player
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        // Move player in 2D space
        private Vector2 _movementDirection;
        private float _movementSpeed = 4f;

        private Rigidbody2D _playerBody;

        //Player Components
        private PlayerInput _playerInput;

        private void Start()
        {
            _playerInput = GetComponentInParent<PlayerInput>();
            _playerBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            _movementDirection.x = _playerInput.inputAxis.x;
            _movementDirection.y = _playerInput.inputAxis.y;

            _playerBody.MovePosition(_playerBody.position +
                                     _movementDirection * (_movementSpeed * Time.fixedDeltaTime));
        }

        public void SetSpeed(float characterDataCharacterSpeed)
        {
            _movementSpeed = characterDataCharacterSpeed;
        }
    }
}
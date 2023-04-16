using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        //Player Components
        private PlayerInput _playerInput;
        private Rigidbody2D _playerBody;

        // Move player in 2D space
        private Vector2 _movementDirection;
        private float _movementSpeed = 10f;

        void Start()
        {
            _playerInput = GetComponentInParent<PlayerInput>();
            _playerBody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            _movementDirection = new Vector2(_playerInput.Horizontal, _playerInput.Vertical);
            _playerBody.MovePosition(_playerBody.position +
                                     _movementDirection * (_movementSpeed * Time.fixedDeltaTime));
        }

        public void SetSpeed(float characterDataCharacterSpeed)
        {
            _movementSpeed = characterDataCharacterSpeed;
        }
    }
}
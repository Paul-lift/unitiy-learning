using UnityEngine;

namespace DefaultNamespace{
    public class PlayerController : MonoBehaviour{
        private CharacterController _characterController;
        
        public float MovementSpeed = 10f, RotationSpeed = 10f, JumpForce = 10f, GravityForce = -30f;
        
        private float _rotationY;
        private float _verticalVelocity;
        
        private void Start(){
            _characterController = GetComponent<CharacterController>();
        }

        public void Move(Vector2 movementVector){
            //transform.forward ist die richtung wo das Objekt hinschaut, Norden z.b (0,0,1), dann wird multipliziert mit 1 oder -1
            var move = transform.forward * movementVector.y + transform.right * movementVector.x;
            move = move * (MovementSpeed * Time.deltaTime);
            _characterController.Move(move);
            
            _verticalVelocity = _verticalVelocity + GravityForce * Time.deltaTime;
            _characterController.Move(new Vector3(0, _verticalVelocity, 0) *  Time.deltaTime);
        }

        public void Rotate(Vector2 rotationVector){
            _rotationY += rotationVector.x * RotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
        }

        public void Jump(){
            if (_characterController.isGrounded){
                _verticalVelocity = JumpForce;
            }
        }
        
        
    }
    
    
}
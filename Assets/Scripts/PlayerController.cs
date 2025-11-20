using UnityEngine;

namespace DefaultNamespace{
    public class PlayerController : MonoBehaviour{
        public float MovementSpeed = 10f, RotationSpeed = 10f, JumpForce = 10f, GravityForce = -30f;
        private CharacterController _characterController;

        private float _rotationY;
        private float _verticalVelocity;

        private void Start(){
            _characterController = GetComponent<CharacterController>();
        }

        /*  public void Move(Vector2 movementVector){
              //transform.forward ist die richtung wo das Objekt hinschaut, Norden z.b (0,0,1), dann wird multipliziert mit 1 oder -1
              var move = transform.forward * movementVector.y + transform.right * movementVector.x;
              move = move * (MovementSpeed * Time.deltaTime);
              _characterController.Move(move);

              _verticalVelocity = _verticalVelocity + GravityForce * Time.deltaTime;
              _characterController.Move(new Vector3(0, _verticalVelocity, 0) *  Time.deltaTime);
          }*/

        public void Move(Vector2 movementVector){
            //transform.forward ist Norden oder süden, alles zwischen 1 und -1 wird mit w(1) oder s(-1) multipliziert und ergibt die richtung des vektor
            var moveDir = transform.forward * movementVector.y + transform.right * movementVector.x;
            if (moveDir.sqrMagnitude > 1f) moveDir.Normalize();
            
            var horizontal = moveDir * MovementSpeed;


            if (_characterController.isGrounded && _verticalVelocity < 0) _verticalVelocity = 0f;
            
            _verticalVelocity += GravityForce * Time.deltaTime;
            
            Vector3 velocity = new Vector3(horizontal.x, _verticalVelocity, horizontal.z);
            _characterController.Move(velocity * Time.deltaTime);
        }

        public void Rotate(Vector2 rotationVector){
            _rotationY += rotationVector.x * RotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
        }

        public void Jump(){
            if (_characterController.isGrounded) _verticalVelocity = JumpForce;
        }
    }
}
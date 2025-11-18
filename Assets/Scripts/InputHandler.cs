using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace{
    public class InputHandler : MonoBehaviour{
        public PlayerController PlayerController;

        private InputAction _moveAction, _lookAction, _jumpAction;

        //Event is called once before the first Execution of Update Monobehavoiur is created
        private void Start(){
            _moveAction = InputSystem.actions.FindAction("Move");
            _lookAction = InputSystem.actions.FindAction("Look");
            _jumpAction = InputSystem.actions.FindAction("Jump");

            _jumpAction.performed += OnJumpPerformed;

            Cursor.visible = false;
        }

        private void Update(){
            var movementVector = _moveAction.ReadValue<Vector2>();
            PlayerController.Move(movementVector);

            var lookVector = _lookAction.ReadValue<Vector2>();
            PlayerController.Rotate(lookVector);
        }

        public void OnJumpPerformed(InputAction.CallbackContext ctx){
            PlayerController.Jump();
        }
    }
}
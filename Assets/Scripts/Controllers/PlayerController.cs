using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.Controllers
{

    public class PlayerController : MonoBehaviour
    {

        #region private fields
        [SerializeField]
        float maxSpeed;

        [SerializeField]
        float acceleration;

        [SerializeField]
        float maxAngularSpeed;

        CharacterController cc;
        Vector2 moveInput;
        bool moving = false;
        float speed = 0;

        #endregion

        #region private methods
        private void Awake()
        {
            cc = GetComponent<CharacterController>();
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
#if UNITY_EDITOR
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#endif
            // moveInput = VirtualJoystick.GetInput();

            moving = moveInput == Vector2.zero ? false : true;

            // Get direction
            Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y).normalized;

            // Get speed
            speed += (moving ? 1 : -1) * acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0, maxSpeed);

            // We only set direction if player is moving
            if (moving)
                transform.forward = Vector3.MoveTowards(transform.forward, direction, maxAngularSpeed * Time.deltaTime);

            // Move
            cc.Move(direction.normalized * speed * Time.deltaTime);
            
                
        }


#endregion

#region public methods
        
#endregion
    }

}

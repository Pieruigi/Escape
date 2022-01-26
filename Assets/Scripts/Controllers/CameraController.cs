using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoca.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        Transform target;

        [SerializeField]
        float height;

        [SerializeField]
        float smoothTime = 0.3f;

        Vector3 velocity;
        

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void LateUpdate()
        {
            // Smoothly move to the target position
            Vector3 targetPosition = target.position;
            targetPosition.y = height;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            //transform.position = Vector3.Lerp(transform.position, targetPosition, 15 * Time.deltaTime);
        }
    }

}

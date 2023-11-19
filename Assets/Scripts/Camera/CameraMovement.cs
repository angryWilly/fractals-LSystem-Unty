using UnityEngine;

namespace Camera
{
    public class CameraMovement : MonoBehaviour
    {
        private float _cameraSpeed = 50f;
        private float _scrollSpeed = 1000f;

        private void Update()
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
                transform.position += _cameraSpeed * Time.deltaTime
                                                   * new Vector3(Input.GetAxisRaw("Horizontal"), -Input.GetAxisRaw("Vertical"), 0);
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0) {
                transform.position += _scrollSpeed * Time.deltaTime
                                                   * new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel"));
            }
        }
    }
}

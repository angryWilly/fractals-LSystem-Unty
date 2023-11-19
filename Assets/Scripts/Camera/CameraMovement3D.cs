using UnityEngine;

namespace Camera
{
    public class CameraMovement3D : MonoBehaviour
    {
        [SerializeField] private Transform FractalToLook;
        private float _minFof = 35f;
        private float _maxFox = 100f;
        private float _sensitivity = 17;
        private float _speed = 5f;

        private void Update()
        {
            if (Input.GetMouseButton(1))
            {
                transform.RotateAround(FractalToLook.position, transform.up, Input.GetAxis(
                    "Mouse X") * _speed);
                transform.RotateAround(FractalToLook.position, transform.right, Input.GetAxis(
                    "Mouse Y") * -_speed);
            }

            float fov = UnityEngine.Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * -_sensitivity;
            fov = Mathf.Clamp(fov, _minFof, _maxFox);
            UnityEngine.Camera.main.fieldOfView = fov;
        }
    }
}

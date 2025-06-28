using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Camera resumeCamera;
    RectTransform _transform;

    Vector3 targetPosition, velocity;

    private void Start()
    {
        resumeCamera = Camera.main;
        _transform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, resumeCamera.transform.position);
        Vector2 anchoredPosition = transform.InverseTransformPoint(screenPoint);


        targetPosition = resumeCamera.transform.position;
        _transform.anchoredPosition = Vector3.SmoothDamp(_transform.anchoredPosition, targetPosition, ref velocity, 10 * Time.deltaTime);
    }
}

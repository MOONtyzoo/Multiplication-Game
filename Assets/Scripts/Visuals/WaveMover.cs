using UnityEngine;

public class WaveMover : MonoBehaviour
{
    [Header("Offset Settings")]
    [SerializeField] private float offsetAmplitude;
    [SerializeField] private float offsetFrequency;
    [SerializeField, Range(0.0f, 360.0f)] private float offsetAngle;

    [Space, Header("Rotation Settings")]
    [SerializeField] private float rotationAmplitude;
    [SerializeField] private float rotationFrequency;

    private Vector2 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float offsetMagnitude = offsetAmplitude * Mathf.Sin(offsetFrequency * 2f * Mathf.PI * Time.time);
        Vector2 offsetDirection = new Vector2(Mathf.Cos(offsetAngle * Mathf.Deg2Rad), Mathf.Sin(offsetAngle * Mathf.Deg2Rad));
        transform.position = initialPosition + offsetMagnitude * offsetDirection;

        float angle = rotationAmplitude * Mathf.Sin(rotationFrequency * 2f * Mathf.PI * Time.time);
        SetRotation(angle);
    }

    private void SetRotation(float newAngle)
    {
        Vector3 newRotationEuler = transform.eulerAngles;
        newRotationEuler.z = newAngle;
        transform.eulerAngles = newRotationEuler;
    }
}

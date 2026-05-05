using UnityEngine;
using UnityEngine.UI; // Needed to make the script work.

public class FloatingHealthBar : MonoBehaviour
{
    [Header("Assign In Inspector")]
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
        // Takes the slider value and divides the current value by the max value.
    }

    void Update()
    {
        transform.rotation = camera.transform.rotation;
        // Makes the object rotate the same as the camera.
        target.position = target.position + offset;
        // This find the current position and then allows you to move it by the offset.
    }
}

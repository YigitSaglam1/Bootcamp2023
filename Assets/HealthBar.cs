using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    [field: SerializeField] public Camera mainCamera { get; private set; }

    private void Start()
    {
        mainCamera = Camera.main;
    }
    public void UpdateHealthBar(float currentVal, float maxVal)
    {
        slider.value = currentVal / maxVal ;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCamera.transform.forward);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public InputActionReference action;

    private Light lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light>();

        action.action.Enable();

        action.action.performed += (ctx) =>
        {
            if (lightComponent.color == Color.white)
                lightComponent.color = Color.red;
            else
                lightComponent.color = Color.white;
        };
    }
}
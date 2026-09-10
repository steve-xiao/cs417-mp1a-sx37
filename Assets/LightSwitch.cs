using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public InputActionReference action;
    public FeedbackGroup feedback;

    private Light lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light>();

        action.action.Enable();

        action.action.performed += OnLightSwitch;
    }

    void OnDestroy()
    {
        if (action != null && action.action != null)
        {
            action.action.performed -= OnLightSwitch;
        }
    }

    private void OnLightSwitch(InputAction.CallbackContext ctx)
    {
        if (lightComponent.color == Color.white)
        {
            lightComponent.color = Color.red;
        }
        else
        {
            lightComponent.color = Color.white;
        }

        if (feedback != null)
        {
            feedback.PlayFeedback();
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class BreakOut : MonoBehaviour
{
    public InputActionReference action;

    [Header("Teleport Positions")]
    public Vector3 roomPosition = Vector3.zero;
    public Vector3 outsidePosition = new Vector3(0f, 0f, -25f);

    [Header("Feedback")]
    public FeedbackGroup breakOutFeedback;
    public FeedbackGroup returnFeedback;

    private bool outside = false;

    void Start()
    {
        if (action != null)
        {
            action.action.Enable();
            action.action.performed += OnTeleport;
        }
    }

    void OnDestroy()
    {
        if (action != null && action.action != null)
        {
            action.action.performed -= OnTeleport;
        }
    }

    void OnTeleport(InputAction.CallbackContext ctx)
    {
        Teleport();
    }

    void Teleport()
    {
        outside = !outside;

        if (outside)
        {
            // Move player first.
            transform.position = outsidePosition;

            // Then play feedback at outside destination.
            if (breakOutFeedback != null)
            {
                breakOutFeedback.PlayFeedback();
            }
        }
        else
        {
            // Move player back into room first.
            transform.position = roomPosition;

            // Then play feedback near room destination.
            if (returnFeedback != null)
            {
                returnFeedback.PlayFeedback();
            }
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class BreakOut : MonoBehaviour
{
    public InputActionReference action;

    public Vector3 roomPosition = Vector3.zero;
    public Vector3 outsidePosition = new Vector3(0f, 0f, -25f);

    private bool outside = false;

    void Start()
    {
        action.action.Enable();

        action.action.performed += (ctx) =>
        {
            outside = !outside;

            if (outside)
                transform.position = outsidePosition;
            else
                transform.position = roomPosition;
        };
    }
}
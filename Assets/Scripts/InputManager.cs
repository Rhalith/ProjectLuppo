using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using Unity.VisualScripting;

public class InputManager : MonoBehaviour {
    //[SerializeField] PlayerController playerController;

    PlayerInputs controls;
    PlayerInputs.PlayerInputActions playerInput;

    float movementInput;
    Vector2 mouseInput;

    public bool isMovable;
    public bool isMouseDown;

    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    private void Awake ()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        isMovable = true;
        isMouseDown = false;

        controls = new PlayerInputs();
        playerInput = controls.PlayerInput;

        // Horizontal player movement
        playerInput.Movement.started += ctx => movementInput = ctx.ReadValue<float>();
        playerInput.Movement.canceled += ctx => movementInput = 0f;

        // Updated after every mouse movement
        playerInput.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        playerInput.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        // Usage of started and canceled (KeyDown and KeyUp)
        playerInput.LeftClick.started += ctx => Clicked(ctx.action.name);
        playerInput.LeftClick.canceled += ctx => StopClicking(ctx.action.name);

        playerInput.RightClick.started += ctx => Clicked(ctx.action.name);
        playerInput.RightClick.canceled += ctx => StopClicking(ctx.action.name);

        // Usage of performed (KeyDown - same as started)
        playerInput.LeftClick.performed += _ => LeftClickPerformed();
        playerInput.RightClick.performed += _ => RightClickPerformed();

        // Has 0.4 seconds hold interaction in it
        playerInput.Shift.performed += _ => isMovable = !isMovable;
    }

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void Update ()
    {
        // Because of using only left and right sides to move, movementInput is a 1D Axis input.
        // Additionally, it can only has -1, 0 and 1 as input values
        if (isMovable)
        {
            playerController.ReceiveHorizontalInput(movementInput);
        }
        else
        {
            objectController.RotateObject(movementInput);
        }
    }

    void Clicked (string actionName)
    {
        //Debug.Log($"{actionName} CLICKED AND HOLDING");
        isMouseDown = true;
    }

    void LeftClickPerformed()
    {
        //ObjectController.Instance.CastRay();
    }

    void RightClickPerformed()
    {
        //ObjectController.Instance.ReleaseObject();
    }

    void StopClicking(string actionName)
    {
        //Debug.Log($"{actionName} RELEASED");
        isMouseDown = false;
    }

    private void OnEnable ()
    {
        controls.Enable();
    }

    private void OnDestroy ()
    {
        controls.Disable();
    }
}
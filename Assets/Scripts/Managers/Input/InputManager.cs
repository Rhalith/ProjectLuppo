using UnityEngine;

public class InputManager : MonoBehaviour {
    [SerializeField] PlayerCam playerCam;
    [SerializeField] KnifeMovement knifeMovement;

    PlayerInputs controls;
    PlayerInputs.PlayerInputActions playerInput;

    float movementInput;
    Vector2 mouseInput; 
    Ray ray;
    RaycastHit hit;

    public bool isMovable;
    public bool isMouseDown;
    public bool IsCutting;

    // Mouse click delegate and events
    public delegate void MouseClickHandler();
    public event MouseClickHandler OnLeftMouseDown;
    public event MouseClickHandler OnLeftMouseHolding;
    public event MouseClickHandler OnLeftMouseUp;
    public event MouseClickHandler OnRightMouseDown;
    public event MouseClickHandler OnRightMouseUp;

    // Mouse over delegate and events
    public delegate void MouseOverHandler(RaycastHit hit);
    public event MouseOverHandler OnLeftMouseDownOver;
    public event MouseOverHandler OnLeftMouseUpOver;

    public event MouseClickHandler OnLeftClickPerformed;

    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    public Vector2 MouseInput { get => mouseInput; }

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
        playerInput.LeftClick.started += _ => LeftMouseButtonDown();
        playerInput.LeftClick.canceled += _ => LeftMouseButtonUp();

        playerInput.RightClick.started += _ => RightMouseButtonDown();
        playerInput.RightClick.canceled += _ => RightMouseButtonUp();

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
            playerCam.ReceiveHorizontalInput(movementInput);
        }
        else
        {
            //objectController.RotateObject(movementInput);
        }
        if (IsCutting)
        {
            knifeMovement.ReceiveHorizontalInput(movementInput);
        }
        // Mouse holding trigger
        if (isMouseDown)
        {
            OnLeftMouseHolding?.Invoke();
        }
    }

    private void LeftMouseButtonDown()
    {
        OnLeftMouseDown?.Invoke();
        isMouseDown = true;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 50000.0f))
        {
            OnLeftMouseDownOver?.Invoke(hit);
        }
    }

    private void LeftMouseButtonUp()
    {
        OnLeftMouseUp?.Invoke();
        isMouseDown = false;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            OnLeftMouseUpOver?.Invoke(hit);
        }
    }

    private void RightMouseButtonDown()
    {
        OnRightMouseDown?.Invoke();
    }

    private void RightMouseButtonUp()
    {
        OnRightMouseUp?.Invoke();
    }

    private void RightClickPerformed()
    {

    }

    private void LeftClickPerformed()
    {

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
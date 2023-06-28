using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;

    public Vector3 MoveInput { get; private set; }
    public bool MenuOpenCloseInput { get; private set; }

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _menuOpenCloseAction;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        _playerInput = GetComponent<PlayerInput>();
        SetupInputAction();
    }

    void SetupInputAction()
    {
        _moveAction = _playerInput.actions["Move"];
        _menuOpenCloseAction = _playerInput.actions["MenuOpenClose"];
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
        MenuOpenCloseInput = _menuOpenCloseAction.WasPressedThisFrame();
    }


}

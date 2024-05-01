using Assets.Scripts.Data;
using Assets.Scripts.Player;
using Assets.Scripts.Player.InputServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMoveService : MonoBehaviour
{
    [Inject] private KeyboardInputService _keyboardInputService;
    [Inject] private UIButtonsInputService _buttonsInputService;
    [Inject] private PlayerObject _playerObject;
    [Inject] private PlayerData _playerData;

    private IInputService _currentInputService;

    private const int LEFT_DIRECTION_COFFICIENT = -1;
    private const int RIGHT_DIRECTION_COFFICIENT = 1;

    private void Awake()
    {
#if UNITY_EDITOR
        _currentInputService = _keyboardInputService;
#elif UNITY_ANDROID
        _currentInputService = _buttonsInputService;
#else
        _currentInputService = _keyboardInputService;
#endif

        _currentInputService.Init();
    }

    private void OnEnable()
    {
        _currentInputService.LeftButtonHold += OnLeftButtonHold;
        _currentInputService.RightButtonHold += OnRightButtonHold;
        _currentInputService.RightButtonUp += OnButtonUp;
        _currentInputService.LeftButtonUp += OnButtonUp;
    }

    private void OnDisable()
    {
        _currentInputService.LeftButtonHold -= OnLeftButtonHold;
        _currentInputService.RightButtonHold -= OnRightButtonHold;
        _currentInputService.RightButtonUp -= OnButtonUp;
        _currentInputService.LeftButtonUp -= OnButtonUp;
    }
    private void OnButtonUp()
    {
        _playerObject.MoveInDirection(Vector2.zero);
    }

    private void OnRightButtonHold()
    {
        _playerObject.MoveInDirection(new Vector2(_playerData.MoveSpeed * RIGHT_DIRECTION_COFFICIENT, _playerObject.RigidbodyVelocityY));
    }

    private void OnLeftButtonHold()
    {
        _playerObject.MoveInDirection(new Vector2(_playerData.MoveSpeed * LEFT_DIRECTION_COFFICIENT, _playerObject.RigidbodyVelocityY));
    }

}

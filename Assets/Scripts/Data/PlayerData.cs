using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [Range(0f, 100f)] [SerializeField] private float _moveSpeed;

        [SerializeField] private KeyCode _leftButtonKeyCode;
        [SerializeField] private KeyCode _rightButtonKeyCode;

        public KeyCode LeftButtonKeyCode => _leftButtonKeyCode;
        public KeyCode RightButtonKeyCode => _rightButtonKeyCode;
        public float MoveSpeed => _moveSpeed;
    }
}
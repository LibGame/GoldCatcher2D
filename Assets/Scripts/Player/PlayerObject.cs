using Assets.Scripts.Objects;
using UnityEngine;
using Object = Assets.Scripts.Objects.Object;

namespace Assets.Scripts.Player
{
    public class PlayerObject : Object
    {
        [SerializeField] private GameObject _explosion;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _coinsFullBagSprite;
        [SerializeField] private Sprite _coinsEmptyBagSprite;

        public void SetupCoinsBagSprite()
        {
            _spriteRenderer.sprite = _coinsFullBagSprite;
        }

        public void Explosion()
        {
            MoveInDirection(Vector2.zero);
            _explosion.SetActive(true);
        }

        public override void Enable()
        {
            _explosion.gameObject.SetActive(false);
            _spriteRenderer.sprite = _coinsEmptyBagSprite;
            base.Enable();
        }

    }
}
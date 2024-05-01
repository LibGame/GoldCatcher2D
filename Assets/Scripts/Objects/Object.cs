using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Object : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        public float RigidbodyVelocityX
        {
            get
            {
                if (_rigidbody2D == null)
                    return 0;
                return _rigidbody2D.velocity.x;
            }
        }

        public float RigidbodyVelocityY
        {
            get
            {
                if (_rigidbody2D == null)
                    return 0;
                return _rigidbody2D.velocity.y;
            }
        }

        private void Start()
        {
            if (transform.TryGetComponent(out Rigidbody2D rigidbody2D))
            {
                _rigidbody2D = rigidbody2D;
            }
            else
            {
                Debug.LogError("Object doesn't contain Rigidbody2D component");
            }
        }

        public void Disable()
        {
            gameObject.SetActive(false);            
        }

        public virtual void Enable()
        {
            gameObject.SetActive(true);
        }

        public virtual void MoveInDirection(Vector2 direction)
        {
            _rigidbody2D.velocity = direction;
        }
    }
}
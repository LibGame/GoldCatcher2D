using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Panel : MonoBehaviour
    {
        [SerializeField] private GameObject[] _objects;

        public virtual void Open()
        {
            foreach (var obj in _objects)
            {
                obj.SetActive(true);
            }
        }

        public virtual void Close()
        {
            foreach (var obj in _objects)
            {
                obj.SetActive(false);
            }
        }
    }
}
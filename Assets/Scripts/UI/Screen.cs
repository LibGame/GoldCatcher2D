using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] private GameObject[] _objects;

        public void Open()
        {
            foreach(var obj in _objects)
            {
                obj.SetActive(true);
            }
        }

        public void Close()
        {
            foreach (var obj in _objects)
            {
                obj.SetActive(false);
            }
        }
    }
}
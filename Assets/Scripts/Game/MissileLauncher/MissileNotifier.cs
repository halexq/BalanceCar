using System.Collections.Generic;
using UnityEngine;

namespace Game.MissileLauncher
{
    public class MissileNotifier : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> _notifyMarkers = new();

        private void Awake()
        {
            DeactivateAll();
        }

        public void Activate(int index)
        {
            _notifyMarkers[index].gameObject.SetActive(true);
        }

        public void Deactivate(int index)
        {
            _notifyMarkers[index].gameObject.SetActive(false);
        }

        public void DeactivateAll()
        {
            foreach (var notifyMarker in _notifyMarkers)
            {
                notifyMarker.gameObject.SetActive(false);
            }
        }
    }
}
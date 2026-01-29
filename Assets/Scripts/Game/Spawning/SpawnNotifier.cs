using System.Collections.Generic;
using Game.Spawning.Type;
using UnityEngine;

namespace Game.Spawning
{
    public class SpawnNotifier : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> _notifyMarkers = new();

        private readonly Dictionary<SpawnableType, Color> _notifyColors = new()
        {
            { SpawnableType.Missile, Color.red},
            { SpawnableType.Coin, Color.green},
        };

        private void Awake()
        {
            DeactivateAll();
        }

        public void Activate(int index, SpawnableType type)
        {
            _notifyMarkers[index].color = _notifyColors[type];
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
using System.Collections.Generic;
using UnityEngine;

namespace Game.MissileLauncher
{
    public class MissileNotifier : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> _notifyMarkers = new();
    }
}
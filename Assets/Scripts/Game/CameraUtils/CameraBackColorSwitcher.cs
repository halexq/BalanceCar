using Engine.UnityServices;
using UnityEngine;
using VContainer;

namespace Game.CameraUtils
{
    [RequireComponent(typeof(Camera))]
    public class CameraBackColorSwitcher : MonoBehaviour
    {
        private Camera _camera;
        
        [Inject] private readonly UnityRemoteConfigLoader _unityRemoteConfigLoader;

        private void Awake()
        {
            _camera = GetComponent<Camera>();

            SetColor();
        }

        private void SetColor()
        {
            var hexBackColor = _unityRemoteConfigLoader.Config.Value<string>(UnityRemoteConfigLoader.BackColorKey);

            if (ColorUtility.TryParseHtmlString($"#{hexBackColor}", out var color))
            {
                _camera.backgroundColor = color;
            }
        }
    }
}
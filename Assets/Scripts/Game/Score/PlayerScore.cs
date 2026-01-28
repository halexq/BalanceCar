using UnityEngine;
using VContainer.Unity;

namespace Game.Score
{
    public class PlayerScore : ScoreKeeper, ITickable
    {
        private const float _addScoreCooldown = 1f;
        private float _time;
        private float _lastAddTime;
        
        public void Tick()
        {
            _time += Time.deltaTime;

            if (_time >= _addScoreCooldown && _lastAddTime + _addScoreCooldown <= _time)
            {
                Add(1);
                _lastAddTime = _time;
            }
        }
    }
}
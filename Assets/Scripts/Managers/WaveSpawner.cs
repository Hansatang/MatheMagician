using UnityEngine;

namespace Managers
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] public Camera cam;
        public Wave[] waves;

        private Wave _currentWave;
        private int _currentWaveIndex;
        private float _negativeRange;
        private readonly float _offset = 10;
        private float _orthographicSize;
        private float _positiveRange;

        private bool _stopSpawning;

        private float _timeBetweenSpawns;

        private void Awake()
        {
            _currentWave = waves[_currentWaveIndex];
            _timeBetweenSpawns = _currentWave.TimeBeforeThisWave;
            _orthographicSize = cam.orthographicSize;
            _negativeRange = -_orthographicSize - _offset;
            _positiveRange = _orthographicSize + _offset;
        }

        private void Update()
        {
            if (_stopSpawning) return;

            if (Time.time >= _timeBetweenSpawns)
            {
                SpawnWave();
                IncWave();

                _timeBetweenSpawns = Time.time + _currentWave.TimeBeforeThisWave;
            }
        }

        private void SpawnWave()
        {
            for (var i = 0; i < _currentWave.NumberToSpawn; i++)
            {
                var num = Random.Range(0, _currentWave.EnemiesInWave.Length);
                var spawnPosition = SelectSpawningPoint();
                Debug.Log(spawnPosition);
                Instantiate(_currentWave.EnemiesInWave[num], spawnPosition, Quaternion.identity);
            }
        }

        private Vector3 SelectSpawningPoint()
        {
            var position = cam.transform.position;

            return _currentWave.AttackDirections[Random.Range(0, _currentWave.AttackDirections.Length)] switch
            {
                SpawnDirections.West => new Vector3(position.x - _orthographicSize - _offset,
                    Random.Range(_negativeRange, _positiveRange), 0f),
                SpawnDirections.East => new Vector3(position.x + _orthographicSize + _offset,
                    Random.Range(_negativeRange, _positiveRange), 0f),
                SpawnDirections.North => new Vector3(Random.Range(_negativeRange, _positiveRange),
                    _orthographicSize * cam.aspect + _offset, 0f),
                _ => new Vector3(Random.Range(_negativeRange, _positiveRange),
                    -_orthographicSize * cam.aspect - _offset, 0f)
            };
        }

        private void IncWave()
        {
            if (_currentWaveIndex + 1 < waves.Length)
            {
                _currentWaveIndex++;
                _currentWave = waves[_currentWaveIndex];
            }
            else
            {
                _stopSpawning = true;
            }
        }
    }
}
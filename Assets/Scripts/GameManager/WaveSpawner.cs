using UnityEngine;

namespace GameManager
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] public Camera camera;
        public Wave[] waves;

        private Wave _currentWave;

        private float _timeBetweenSpawns;
        private int _currentWaveIndex;
        private float _orthographicSize;

        private bool _stopSpawning;

        private void Awake()
        {
            _currentWave = waves[_currentWaveIndex];
            _timeBetweenSpawns = _currentWave.TimeBeforeThisWave;
            _orthographicSize = camera.orthographicSize;
        }

        private void Update()
        {
            if (_stopSpawning)
            {
                return;
            }

            if (Time.time >= _timeBetweenSpawns)
            {
                SpawnWave();
                IncWave();

                _timeBetweenSpawns = Time.time + _currentWave.TimeBeforeThisWave;
            }
        }

        private void SpawnWave()
        {
            for (int i = 0; i < _currentWave.NumberToSpawn; i++)
            {
                int num = Random.Range(0, _currentWave.EnemiesInWave.Length);
                Vector3 spawnPosition = SelectSpawningPoint();
                Debug.Log(spawnPosition);
                Instantiate(_currentWave.EnemiesInWave[num], spawnPosition, Quaternion.identity);
            }
        }

        private Vector3 SelectSpawningPoint()
        {
            var position = camera.transform.position;

            return _currentWave.AttackDirections[Random.Range(0, _currentWave.AttackDirections.Length)] switch
            {
                SpawnDirections.West => new Vector3(position.x - _orthographicSize - 10f,
                    Random.Range(-_orthographicSize, _orthographicSize), 0f),
                SpawnDirections.East => new Vector3(position.x + _orthographicSize + 10f,
                    Random.Range(-_orthographicSize, _orthographicSize), 0f),
                SpawnDirections.North => new Vector3(Random.Range(-_orthographicSize, _orthographicSize),
                    _orthographicSize * camera.aspect + 10f, 0f),
                _ => new Vector3(Random.Range(-_orthographicSize, _orthographicSize),
                    -_orthographicSize * camera.aspect - 10f, 0f)
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
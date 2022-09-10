using System.Collections;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Pool;

namespace codeBase.ui.particles
{
    public class UIParticleDots : MonoBehaviour
    {
        [SerializeField] private Particle _dotParticlePrefab;
        [SerializeField] private RectTransform _spawnTransform;
        [SerializeField] private int _maxParticleCount;
        [SerializeField] private int _maxParticleCountOnTick;
        [SerializeField] private Vector2 _lifeTimeRange;
        [SerializeField] private float _spawnTime;
        [SerializeField] private Canvas _canvas;

        private ObjectPool<Particle> _particlPool;
        private Coroutine _particleSystemRoutine;

        private void Awake()
        {
            initParticlePool();
        }

        private void initParticlePool()
        {
            _particlPool = new ObjectPool<Particle>(
                () => Instantiate(_dotParticlePrefab, _spawnTransform),
                actionOnGet: particle => particle.active(),
                actionOnRelease: particle => particle.gameObject.SetActive(false),
                actionOnDestroy: particle => Destroy(particle),
                collectionCheck: true, defaultCapacity: 10, maxSize: _maxParticleCount);
        }

        private void OnEnable()
        {
            _particleSystemRoutine = StartCoroutine(particleSystemRoutine());
        }

        private void OnDisable()
        {
            if (_particleSystemRoutine != null)
                StopCoroutine(_particleSystemRoutine);
        }

        private IEnumerator particleSystemRoutine()
        {
            while (true)
            {
                float randomParticleNum = Random.Range(1, _maxParticleCountOnTick);
                for (int i = 0; i < randomParticleNum; i++)
                {
                    Particle particle = _particlPool.Get();
                    particle.transform.position = getRandomPosition();
                    particle.transform.localScale = Vector3.one * Random.Range(particle.sizeRange.x, particle.sizeRange.y);
                    particle.image.DOFade(0, Random.Range(_lifeTimeRange.x, _lifeTimeRange.y))
                        .SetLink(particle.gameObject)
                        .OnComplete(() => _particlPool.Release(particle));
                }
                yield return new WaitForSeconds(_spawnTime);
            }
        }

        private Vector3 getRandomPosition()
        {
            Vector3 randomPosition = Vector3.one;
            randomPosition.x = Random.Range(0f, _canvas.renderingDisplaySize.x);
            randomPosition.y = Random.Range(0f, _canvas.renderingDisplaySize.y);

            return randomPosition;
        }

        [Button]
        private void printDebug()
        {
            Debug.Log(_canvas.renderingDisplaySize.y);
        }
    }
}
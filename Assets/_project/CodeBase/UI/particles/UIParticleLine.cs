using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;

namespace codeBase.ui.particles
{
    public class UIParticleLine : MonoBehaviour
    {
        [SerializeField] private Particle _lineParticlePrefab;
        [SerializeField] private RectTransform _spawnTransform;
        [SerializeField] private int _maxParticleCount;
        [SerializeField] private int _maxParticleCountOnTick;
        [SerializeField] private Vector2 _moveSpeedRange;
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
                () => Instantiate(_lineParticlePrefab, _spawnTransform),
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
                float randomParticleNum = Random.Range(0, _maxParticleCountOnTick);
                for (int i = 0; i < randomParticleNum; i++)
                {
                    Particle particle = _particlPool.Get();
                    particle.transform.position = getRandomPosition();
                    particle.transform.localScale = Vector3.one * Random.Range(particle.sizeRange.x, particle.sizeRange.y);
                    particle.transform.DOMoveY(_canvas.renderingDisplaySize.y * 2, Random.Range(_moveSpeedRange.x, _moveSpeedRange.y))
                        .SetLink(particle.gameObject)
                        .OnComplete(() => _particlPool.Release(particle));
                }
                yield return new WaitForSeconds(_spawnTime);
            }
        }

        private Vector3 getRandomPosition()
        {
            Vector3 randomPosition = Vector3.zero;
            randomPosition.x = Random.Range(0f, _canvas.renderingDisplaySize.x);

            return randomPosition;
        }
    }
}

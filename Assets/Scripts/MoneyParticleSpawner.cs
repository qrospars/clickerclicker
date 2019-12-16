using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MoneyParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPositionObject;
    [SerializeField] private GameObject targetPositionObject;
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private float moveTime;
    [SerializeField] private GameObject canvas;
    [SerializeField] private int maximumParticlesToSpawn = 100;

    private Vector3 spawnPosition;
    private Vector3 targetposition;

    public static MoneyParticleSpawner Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spawnPosition = spawnPositionObject.transform.position;
        targetposition = targetPositionObject.transform.position;
    }

    public void CreateParticleEffect(int number, bool addToTotalScore = false)
    {
        StartCoroutine(SpawnParticles(number, addToTotalScore));
    }

    private IEnumerator SpawnParticles(int number, bool addToTotalScore)
    {
        if (number <= maximumParticlesToSpawn)
        {
            for (int i = 0; i < number; ++i)
            {
                var offset = Random.Range(1, 15) / 100f;
                bool sign = Random.Range(0, 2) == 1;
                var newSpawn = new Vector3(spawnPosition.x + (sign ? 1 : -1) * offset * spawnPosition.x,
                    spawnPosition.y);
                var particle = Instantiate(particlePrefab, newSpawn, Quaternion.identity, canvas.transform);
                StartCoroutine(MoveParticle(particle.transform, addToTotalScore: addToTotalScore));
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            var DEBUGparticlesSpawned = 0;
            var particlesPerIteration = (float)number / maximumParticlesToSpawn;
            var integralPart = (int)particlesPerIteration;
            var decimals = (float)((decimal)particlesPerIteration % 1);
            var currentPartialTotal = 0f;
            for (int i = 0; i < maximumParticlesToSpawn; ++i)
            {
                var innerLoop = integralPart;
                currentPartialTotal += decimals;
                if (currentPartialTotal >= 0.99 && DEBUGparticlesSpawned + innerLoop < number)
                {
                    innerLoop++;
                    currentPartialTotal -= 0.99f;
                }

                for (var j = 0; j < innerLoop; ++j)
                {
                    if (j < 2)
                    {
                        var offset = Random.Range(1, 7) / 100f;
                        bool sign = Random.Range(0, 2) == 1;
                        var newSpawn = new Vector3(spawnPosition.x + (sign ? 1 : -1) * offset * spawnPosition.x,
                            spawnPosition.y);
                        var particle = Instantiate(particlePrefab, newSpawn, Quaternion.identity, canvas.transform);
                        StartCoroutine(MoveParticle(particle.transform, addToTotalScore: addToTotalScore));
                    }
                    else
                        StartCoroutine(MoveParticle(null, false, addToTotalScore));
                    DEBUGparticlesSpawned++;
                }

                yield return new WaitForSeconds(0.05f);
            }
            //Debug.Log("Number of particle to spawn: " + number);
            //Debug.Log("Particles spawned: " + DEBUGparticlesSpawned);
        }
    }

    private IEnumerator MoveParticle(Transform particleTransform, bool playAnimation = true,
        bool addToTotalScore = false)
    {
        yield return new WaitForSeconds(0.2f);
        if (playAnimation)
        {
            var tween = particleTransform.DOMove(targetposition, moveTime);
            var scaleTween = particleTransform.DOScale(0.4f, moveTime);
            tween.SetEase(Ease.InOutExpo);
            scaleTween.SetEase(Ease.InOutQuart);
            yield return tween.WaitForCompletion();
            //for (float t = 0; t < timeInFrames; ++t)
            //{
            //    particleTransform.position =
            //            Vector3.Lerp(particleTransform.position, targetposition, t / timeInFrames);

            //    yield return null;
            //}

            Destroy(particleTransform.gameObject);
        }
        else yield return new WaitForSeconds(moveTime);


        if (addToTotalScore)
        {
            GameManager.Instance.currentGold += 1;
            GameManager.Instance.UpdateGoldText();
        }

    }

    public void TestParticles(bool add = false)
    {
        CreateParticleEffect(Random.Range(150, 200), add);
    }
}

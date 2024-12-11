using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Packages;
using GameDevWithMarco.Managers;
using GameDevWithMarco.DesignPattern;

namespace GameDevWithMarco.Packages
{
    public class FallenObjectsSpawner : MonoBehaviour
    {
        [Header("Packages Spawn Position")]
        [SerializeField] GameObject[] spawners;
        [Header("Package Delay Variables")]
        [SerializeField] float initialDelay = 2.0f;
        [SerializeField] float minDelay = 0.5f;
        [SerializeField] float delayIncreaseRata = 0.1f;
        float currentDelay;
        [Header("Packages Drop Chance Percentages")]
        [SerializeField] float goodPackageDropPercentage = 70f;
        [SerializeField] float badPackageDropPercentage = 25f;
        [SerializeField] float lifePackageDropPercentage = 5f;
        [SerializeField] float minimum_GoodPackagePercentage;
        [SerializeField] float maximum_badPackageDropPercentage;
        [SerializeField] float percentageChangeRatio = 0.1f;



        void Start()
        {
            StartCoroutine(SpawningLoop());
        }
        private void CapThePercentages()
        {
            if (goodPackageDropPercentage <= minimum_GoodPackagePercentage && badPackageDropPercentage >= maximum_badPackageDropPercentage)
            {
                goodPackageDropPercentage = minimum_GoodPackagePercentage;
                badPackageDropPercentage = maximum_badPackageDropPercentage;
            }
        }

        public void GrowBadPercentage()
        {
            goodPackageDropPercentage -= percentageChangeRatio;
            badPackageDropPercentage += percentageChangeRatio;
            CapThePercentages();
        }

        public void GrowGoodPercentage()
        {
            goodPackageDropPercentage += percentageChangeRatio;
            badPackageDropPercentage -= percentageChangeRatio;
            CapThePercentages();
        }    

        private ObjectPoolingPattern.TypeOfPool GetPackageTypeBasedOnPercentage()
        {
            float randomValue = Random.Range(0f, 100.1f);

            if (randomValue <= goodPackageDropPercentage)
            {
                return ObjectPoolingPattern.TypeOfPool.Good;
            }
            else if (randomValue > goodPackageDropPercentage && randomValue <= (goodPackageDropPercentage + badPackageDropPercentage))

            {
                return ObjectPoolingPattern.TypeOfPool.Bad;
            }
            else
            {
                return ObjectPoolingPattern.TypeOfPool.Life;
            }
        }

        


        private void SpawnPackageAtRandomLocation(ObjectPoolingPattern.TypeOfPool typeOfPool)
        {
            GameObject spawnedPackage = ObjectPoolingPattern.Instance.GetPoolItem(typeOfPool);

            int randomInteger = Random.Range(0, spawners.Length - 1);

            Vector2 spawnPosition = spawners[randomInteger].transform.position;

            spawnedPackage.transform.position = spawnPosition;
        }

        private IEnumerator SpawningLoop()
        {
            SpawnPackageAtRandomLocation(GetPackageTypeBasedOnPercentage());

            yield return new WaitForSeconds(currentDelay);

            currentDelay -= delayIncreaseRata;

            if (currentDelay < minDelay) currentDelay = minDelay;

            StartCoroutine(SpawningLoop());
        }

    }
}

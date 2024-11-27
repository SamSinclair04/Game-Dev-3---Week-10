using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Managers;

namespace GameDevWithMarco.DesignPattern
{
    public class ObjectPoolingPattern : Singleton<ObjectPoolingPattern>
    {
        [SerializeField] PoolData goodPackagePoolData;
        [SerializeField] PoolData badPackagePoolData;
        [SerializeField] PoolData lifePackagePoolData;


        public List<GameObject> goodPool = new List<GameObject>();
        public List<GameObject> badPool = new List<GameObject>();
        public List<GameObject> lifePool = new List<GameObject>();
        public enum TypeOfPool
        {
            Good,
            Bad,
            Life
        }

        // Start is called before the first frame update
        protected override void Awake()
        {
            FillThePool(goodPackagePoolData, goodPool);
            FillThePool(badPackagePoolData, badPool);
            FillThePool(lifePackagePoolData, lifePool);
        }       
     

        private void FillThePool(PoolData poolData,List<GameObject> targetPoolContainer)
        {
            //Clears the pool
            GameObject container = CreateAContainerForThePool(poolData);

            //Goes as many time as we want the pool amount to be
            for (int i = 0; i < poolData.poolAmount; i++)
            {
                //Instantiates on item in the pool
                GameObject thingToAddToThePool = Instantiate(poolData.poolItem, container.transform);
                //Sets the patent to be what this script is attached to
                thingToAddToThePool.transform.parent = transform;
                //Deactivates it 
                thingToAddToThePool.SetActive(false);
                //Adds it to the pool container list
                targetPoolContainer.Add(thingToAddToThePool);
            }
        }

        public GameObject CreateAContainerForThePool(PoolData pooldata)
        {
            GameObject container = new GameObject();

            container.transform.SetParent(this.transform);

            container.name = pooldata.name;

            return container;   
        }

        public GameObject GetPoolItem(TypeOfPool typeOfPoolToUse)
        {
            List<GameObject> poolToUse = new List<GameObject>();

            switch (typeOfPoolToUse)
            {
                case TypeOfPool.Good:
                    poolToUse = goodPool;
                    break;
                    case TypeOfPool.Bad:
                    poolToUse = badPool;
                    break;
                case TypeOfPool.Life:
                    poolToUse = lifePool;
                    break;
            }

            int itemInPoolCount = poolToUse.Count;

            for (int i = 0; itemInPoolCount > 0; i++)
            {
                if (!poolToUse[i].gameObject.activeSelf)
                {
                    poolToUse[i].SetActive(true);
                    return poolToUse[i];
                }
            }

            Debug.LogWarning("No Availiable Items Found, Pool too small.");

            return null;
        }

    }

}

using UnityEngine;
using GameDevWithMarco.Interfaces;
using GameDevWithMarco.Managers;


namespace GameDevWithMarco.Packages
{
    public class GoodPackage : MonoBehaviour, ICollidable
    {
        [SerializeField] GameEvent goodPackageCollected;

        public void CollidedLogic()
        {
            goodPackageCollected.Raise();
        }
    }
}

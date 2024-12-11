using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Player;
using GameDevWithMarco.VFX;
using GameDevWithMarco.Managers;
using GameDevWithMarco.Interfaces;

namespace GameDevWithMarco.Player
{
    public class Player_Collision : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            ExecuteLogicBasedOnWhatWeHaveCollidedWith(collision);
            collision.gameObject.SetActive(false);
        }
        private void ExecuteLogicBasedOnWhatWeHaveCollidedWith(Collider2D collision)
        {
            ICollidable collidable = collision.GetComponent<ICollidable>();
            if (collidable != null)
            {
                collidable.CollidedLogic();
            }
        }
    }
}

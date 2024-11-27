﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.VFX;

namespace GameDevWithMarco.VFX
{
    public class ParticleSystemAutoDistructor : MonoBehaviour
    {
        private ParticleSystem system;


        // Update is called once per frame
        void Update()
        {
            if (system == null)
            {
                system = GetComponent<ParticleSystem>();
            }

            if (system != null && !system.IsAlive(true))
            {
                Destroy(gameObject);
            }
        }
    }
}
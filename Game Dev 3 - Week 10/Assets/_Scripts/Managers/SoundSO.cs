using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameDevWithMarco.DataSO
{
    [CreateAssetMenu(fileName = "New Sound Data", menuName = "Scriptable Objects/SoundsSO")]
    public class SoundSO : ScriptableObject
    {
        public float minPitchValue;
        public float maxPitchValue;
        public AudioClip clipToUse;
        public float soundVolume;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Particle/CreateDB")]
public class Particle_database : ScriptableObject {
    public List<ParticleData> PDList = new List<ParticleData>();
}

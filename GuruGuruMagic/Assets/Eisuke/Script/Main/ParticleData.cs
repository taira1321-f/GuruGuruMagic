using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName="Particle/CreateData")]
[System.Serializable]
public class ParticleData : ScriptableObject {

    public string NAME;
    public GameObject Particle_Prefab;
    
    public GameObject Get_PP() {
        return Particle_Prefab;
    }

    public void Instance() {
        GameObject PP;
        PP = Instantiate(Particle_Prefab);
        PP.transform.position = new Vector3(0, 0, 0);
        PP.GetComponent<ParticleSystem>().Play();
    }
    
}

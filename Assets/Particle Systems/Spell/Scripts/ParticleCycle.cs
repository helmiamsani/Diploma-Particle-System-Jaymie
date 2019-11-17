using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ParticleCycle : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject particle;
    public float existenceTime;

    private float _firstExistence = 0;
    private GameObject _particleClone;

    private void Start()
    {
        _particleClone = Instantiate(particle, spawnPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.deltaTime > _firstExistence)
        {
            _firstExistence = Time.deltaTime + existenceTime;
            _particleClone.SetActive(false);
        }
        else
        {
            _particleClone.SetActive(true);
        }
    }
}

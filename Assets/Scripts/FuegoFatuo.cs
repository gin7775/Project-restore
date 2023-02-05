using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoFatuo : MonoBehaviour
{
    public GameObject childFire;
    public bool deathFire;
    public float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        respawnTime = Random.Range(10, 21);
    }

    // Update is called once per frame
    void Update()
    {
        if (deathFire == true)
        {
            
            respawnTime -= Time.deltaTime;
            if (respawnTime <= 0)
            {
                deathFire = false;
                GameObject toInstantiate = GameObject.Instantiate(childFire, this.transform.position, Quaternion.identity);
                toInstantiate.transform.SetParent(this.transform);
             
            }
        }
    }
}

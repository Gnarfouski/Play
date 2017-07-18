using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

    public GameObject[] asteroidPrefabs;
    public int numberAsteroids;

	void Start () {
		for(int i = 0;i<numberAsteroids;i++)
        {
            Vector3 pos = getRandomV3();
            while (pos.magnitude < 15 || pos.magnitude > 45) pos = getRandomV3();

            GameObject.Instantiate(asteroidPrefabs[UnityEngine.Random.Range(0, asteroidPrefabs.Length)], pos, Quaternion.identity);
        }
	}

    Vector3 getRandomV3()
    {
        float x = UnityEngine.Random.Range(-45, 45);
        float y = UnityEngine.Random.Range(-45, 45);
        float z = UnityEngine.Random.Range(-45, 45);
        return new Vector3(x, y, z);
    }
}

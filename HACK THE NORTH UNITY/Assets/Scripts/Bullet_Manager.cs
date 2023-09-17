using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Manager : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    // This creates a bullet every 2.2 seconds
    IEnumerator SpawnBullet()
	{
        // Keep repeating
        while (true)
		{
            // This gets a random number betwween the min and max y allowed for this level.
            float randomY = Random.Range(-5f, 4f);

            // This creates a bullet from the prefab we assigned at the specific position
            Instantiate(bulletPrefab, new Vector3(34, randomY, 0), Quaternion.Euler(0, 0, 90));

            // Waits 2.2 seconds
            yield return new WaitForSeconds(2.2f);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject[] ObstaclePrefab = new GameObject[2];
    public PublicVariables Variables;
    private float Force, SpawnTimer = 1f;
    private int ObstacleIndex;
    private Vector2 ScreenBounds;
    // Start is called before the first frame update
    void Start()
    {
        SetForceAndSpawnTimer();
        StartCoroutine(ObstacleWave());
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        ObstacleIndex = Variables.GetBackground();
    }

    private void SpawnObstacle()
    {
        Rigidbody2D Rb;
        Random rndm = new Random();
        float x = 0f, y = 0f;
        GameObject a = Instantiate(ObstaclePrefab[ObstacleIndex]) as GameObject;
        Rb = a.GetComponent<Rigidbody2D>();
        while (x < ScreenBounds.x && x > -ScreenBounds.x)
        { x = Random.Range(-40, 40); }
        while (y < ScreenBounds.y && y > -ScreenBounds.y)
        { y = Random.Range(-40, 40); }

        a.transform.position = new Vector2(x, y);
        if (x-transform.position.x > 1)
        {
            x = -(Random.Range(0.5f*Force ,1.5f*Force));
        }
        else
        {
            x = (Random.Range(0.5f * Force, 1.5f * Force));
        }
        if (y - transform.position.y > 1)
        {
            y = -(Random.Range(0.5f * Force, 1.5f * Force));
        }
        else
        {
            y = (Random.Range(0.5f * Force, 1.5f * Force));
        }
        Rb.AddForce(new Vector2(x, y));
    }

    private void SetForceAndSpawnTimer()
    {
        switch (Variables.GetDifficulty())
        {
            case 0:
                Force = 300f;
                SpawnTimer = 0.6f;
                break;
            case 1:
                Force = 800f;
                SpawnTimer = 0.4f;
                break;
            case 2:
                Force = 1000f;
                SpawnTimer = 0.2f;
                break;
        }

    }

    IEnumerator ObstacleWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTimer);
            SpawnObstacle();
        }
    }
}

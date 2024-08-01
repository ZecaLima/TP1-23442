using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadTile;
    Vector3 nextSpawnPoint;

    public void spawnTile(bool spawnItems)
    {
        // o que quero spawnar, onde, e a rotaçao, neste caso, sem rotaçao
        GameObject temp = Instantiate(roadTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<RoadTile>().spawnObstacle();
            temp.GetComponent<RoadTile>().spawnCoins();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if(i < 3)
            {
                spawnTile(false);
            }
            else
            {
                spawnTile(true);
            }
        }
    }

}

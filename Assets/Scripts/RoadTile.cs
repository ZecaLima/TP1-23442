using Unity.VisualScripting;
using UnityEngine;

public class RoadTile : MonoBehaviour
{
    RoadSpawner roadSpawner;
    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GameObject.FindObjectOfType<RoadSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        roadSpawner.spawnTile(true);

        //destroi 2 segundos depois de passar pelo trigger
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    public void spawnObstacle ()
    {
        // escolher um sitio aleatorio para meter o obstaculo
        // o range inclui o primeiro input, mas exclui o outro ou seja, o random vai de 0 a 4
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform SpawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        
        // mete o obstaculo
        Instantiate(obstaclePrefab, SpawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

    public void spawnCoins ()
    {
        int coinsToSpawn = 10;

        for (int i = 0; i < coinsToSpawn; i++)
        {
            //o transform, junta a moeda ao tile, para serem apagadas quando o chao for tambem apagado
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = getRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 getRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        // verifica se o ponto esta dentro do collider, caso nao seja, gera outro
        // esta funcao nao deve ser utilizada
        if (point != collider.ClosestPoint(point))
        {
            point = getRandomPointInCollider(collider);
        }

        point.y = 1;

        return point;
    }
}

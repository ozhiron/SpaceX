using UnityEngine;
using Random = UnityEngine.Random;

public class Generator :MonoBehaviour
{
    public Transform[] positions;
    public GameObject breakShips;
    public GameObject breakBigShips;

    private bool spawned = false;

    void Start() => Spawn();

    void Update() => CheckSpawnBigShip();

    void Spawn()
    {
        for (int i = 0; i < positions.Length - 6; i++)
        {
            int posSpawnIndex = Random.Range(0, positions.Length);
            if (positions[posSpawnIndex] != null)
            {
                Instantiate(breakShips, positions[posSpawnIndex].transform.position, positions[posSpawnIndex].rotation);
                positions[posSpawnIndex] = null;
            }
            else i--;
        }
    }

    void CheckSpawnBigShip()
    {
        if(GameManger.instance.score == 7 && spawned == false)
        {
            int posSpawnIndex = Random.Range(0, positions.Length);
            Instantiate(breakBigShips, positions[posSpawnIndex].transform.position, positions[posSpawnIndex].rotation);
            spawned = true;
        }
    }
}

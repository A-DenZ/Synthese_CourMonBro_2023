using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpawnManagerNetwork : NetworkBehaviour
{

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject spawnEnemy;

    public static SpawnManagerNetwork Instance;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject spawnClown = Instantiate(spawnEnemy, randomPoint.position, randomPoint.rotation);
        spawnClown.GetComponent<NetworkObject>().Spawn(true);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void spawnWhiteClown()
    {
        StartCoroutine(waitForSpawn());

    }




    IEnumerator waitForSpawn()
    {
        yield return new WaitForSeconds(6f);
        Debug.Log("dans le wait for spawn");
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        SystemSoundsNetwork.Instance.playSpawnSound();

        GameObject Enemy = Instantiate(spawnEnemy, randomPoint.position, randomPoint.rotation);
        Enemy.GetComponent<NetworkObject>().Spawn(true);

        EnemyManagerNetwork.Instance.Spawn();
        

    }


}

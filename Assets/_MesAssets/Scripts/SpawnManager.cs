using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject spawnEnemy;

    public static SpawnManager Instance;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject spawnClown = Instantiate(spawnEnemy, randomPoint.position, randomPoint.rotation);
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

        SystemSounds.Instance.playSpawnSound();

        Instantiate(spawnEnemy, randomPoint.position, randomPoint.rotation);

    }


}

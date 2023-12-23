using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    
    
    [SerializeField] private float vitesse = 0.1f;
    [SerializeField] private AudioClip deathAudioClip;
    [SerializeField] private AudioClip spawnAudioClip;
    [SerializeField] private AudioClip iSeeYouClip;
    private float lifePoints; 
    private NavMeshAgent agent;
    private Animator animator;
    private AudioSource audioSource;
    private bool isDead = false;
    private bool iSeeYouPlaying = false;

    

    public static EnemyManager Instance;

   


    public bool isDying = false;

    private void Awake()
    {
        Instance = this;
    }


    [SerializeField] private GameObject _playerObject =  default;
    [SerializeField] private float _speed = 5f;

    private Transform _playerTransform;
    
    
 

    // Start is called before the first frame update
    void Start()
    {
        
        

        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        _playerTransform = FindObjectOfType<XROrigin>().transform;

        agent = GetComponent<NavMeshAgent>();


        lifePoints = GameManager.Instance.getLifePoints();

        vitesse = GameManager.Instance.getVitesse();

          

    }

    // Update is called once per frame
    void Update()
    {


        if(_playerTransform != null )
        {
            if (agent.enabled)
            {
                agent.SetDestination(_playerTransform.position);
                agent.speed = GameManager.Instance.getVitesse();
            }
            
            
        }

        if (Vector3.Distance(_playerTransform.position , transform.position)  <= 30f)
        {
            if (iSeeYouPlaying == false)
            {
                audioSource.loop = false;
                audioSource.clip = iSeeYouClip;
                audioSource.Play();
                iSeeYouPlaying = true;
            }
            if (iSeeYouPlaying == true)
            {
                iSeeYouPlaying = true;
                StartCoroutine(waitISeeYouSound());

            }



        }
        if(Vector3.Distance(_playerTransform.position, transform.position) <= 10f)
        {

            SystemSounds.Instance.playHeartBeat();
        }

        if (Vector3.Distance(_playerTransform.position, transform.position) <= 2f)
        {
            SceneManager.LoadScene(0);
        }

    }

    public void TakeDamage(int damageAmount)
    {
        if (isDying) return;

        if(isDead) return;

        lifePoints -= damageAmount;

        if(lifePoints <= 0)
        {
            Death();

            GameManager.Instance.IncrementLvlDifficulty();

            SpawnManager.Instance.spawnWhiteClown();
        }

    }


    public void Death()
    {
        agent.enabled = false;
        isDying = true;
        audioSource.loop = false;
        audioSource.clip = deathAudioClip;
        audioSource.Play();
        animator.SetBool("isDead", true);
        
        animator.SetTrigger("isDead");

        StartCoroutine(waitForDispawn());
    }


    public void EnemyStartMoving()
    {
        agent.enabled = true;
    }

    IEnumerator waitForDispawn()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
        isDying = false; 
        

    }

    IEnumerator waitISeeYouSound()
    {
        yield return new WaitForSeconds(4f);
        iSeeYouPlaying = true;


    }


}

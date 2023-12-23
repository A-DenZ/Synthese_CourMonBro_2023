using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor;
using UnityEngine;

public class SystemSoundsNetwork : NetworkBehaviour
{
    [SerializeField] private AudioClip heartBeat;
    [SerializeField] private AudioClip spawnClip;

    private AudioSource audioSource;

    public AudioClip[] soundClips;

    private bool hearbeatIsPlaying = false;

    private bool spawnSoundIsPlaying = false;

    public static SystemSoundsNetwork Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomSound());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playHeartBeat () 
    {
        if (hearbeatIsPlaying == false)
        {
            audioSource.clip = heartBeat;
            audioSource.Play();
            hearbeatIsPlaying = true;
            StartCoroutine(waitForHeathBeat());
        }


        IEnumerator waitForHeathBeat()
        {
            yield return new WaitForSeconds(15f);

            hearbeatIsPlaying = false;
            Debug.Log("Fin de la couroutine");
        }

        
    }

     public void playSpawnSound ()
    {
        if(spawnSoundIsPlaying == false)
        {
            audioSource.clip = spawnClip;
            audioSource.Play();
            spawnSoundIsPlaying = true;
            StartCoroutine(waitForSpawnSound());


        }

        IEnumerator waitForSpawnSound()
        {
            yield return new WaitForSeconds(8f);

            spawnSoundIsPlaying = false;
        }
;
    }

    IEnumerator PlayRandomSound()
    {
        while (true)
        {
            if(hearbeatIsPlaying == false && spawnSoundIsPlaying == false)
            {
            
                // Attendre un temps aléatoire entre 1 et 2 minutes avant de jouer un son
                float randomTime = Random.Range(60f, 120f);
                yield return new WaitForSeconds(randomTime);

                // Sélectionner un clip audio aléatoire dans la liste
                int randomIndex = Random.Range(0, soundClips.Length);

                // Jouer le son sélectionné
                audioSource.clip = soundClips[randomIndex];
                audioSource.Play();
            }
        }
    }


}

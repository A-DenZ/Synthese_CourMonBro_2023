using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class GunScript : MonoBehaviour
{

    [SerializeField] private GameObject RayCastSpawnPoint; 

    private int dmg = 10;

    private Animator animator;
    private AudioSource audioSource;

    private bool isShooting = false;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if(!isShooting)
        {

            RaycastHit hit;
            Physics.Raycast(RayCastSpawnPoint.transform.position, RayCastSpawnPoint.transform.forward, out hit);
            if (Physics.Raycast(RayCastSpawnPoint.transform.position, RayCastSpawnPoint.transform.forward, out hit))
            {
                if (hit.transform.tag == "Enemy")
                {

                    EnemyManager.Instance.TakeDamage(dmg);
                }
            }
            animator.SetTrigger("Fire");
            audioSource.Play();
            StartCoroutine(resetShoot());
            isShooting=true;
        }
    }

    IEnumerator resetShoot()
    {
        yield return new WaitForSeconds(0.3f);
        animator.ResetTrigger("Fire");
        isShooting = false;
    }
}

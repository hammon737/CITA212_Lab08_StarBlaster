using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Base Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectilelifetime = 5f;
    [SerializeField] float baseFireRate = 0.2f;

    [Header("Enemy Variables")]
    [SerializeField] bool EnemyFire;
    [SerializeField] float minFireRate = 0.2f;
    [SerializeField] float fireVariance = 0f;

    [HideInInspector] public bool isFiring;

    Coroutine fireCoroutine;

    void Start()
    {
        if (EnemyFire)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            projectile.transform.rotation = transform.rotation;

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();

            projectileRB.linearVelocity = transform.up * projectileSpeed;

            Destroy(projectile, projectilelifetime);

            float waitTime = Random.Range(baseFireRate - fireVariance, baseFireRate + fireVariance);
            waitTime = Mathf.Clamp(waitTime, minFireRate, float.MaxValue);

            yield return new WaitForSeconds(baseFireRate);
        }
    }
}

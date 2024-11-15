using UnityEngine;

public class BulletCollision : Singleton<BulletCollision>
{
    [SerializeField] private ParticleSystem hitFx;
    [SerializeField] private TrailRenderer trail;

    public void OnTriggerEnter(Collider other)
    {
        // Controlla se il proiettile ha colliso con un nemico
        if (other.gameObject.CompareTag("Enemy"))
        {
            Vector3 collisionPoint = other.ClosestPointOnBounds(transform.position);
            other.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBase);
            Instantiate(hitFx, collisionPoint, Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("EnemyBoss"))
        {
            Vector3 collisionPoint = other.ClosestPointOnBounds(transform.position);
            other.GetComponent<EnemyHealth>().TakeDamage(Status.Instance.damageBoss);
            Instantiate(hitFx, collisionPoint, Quaternion.identity);
        }
        trail.Clear();
        gameObject.SetActive(false);
    }
}


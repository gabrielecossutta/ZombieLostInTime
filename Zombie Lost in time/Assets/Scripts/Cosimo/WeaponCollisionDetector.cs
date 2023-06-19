using UnityEngine;

public class WeaponCollisionDetector : Singleton<WeaponCollisionDetector>
{
    [SerializeField] private string[] weaponTags = { "Ak-47", "ShotgunDB", "Minigun" };
    public bool akOwned = false;
    public bool shotgunDBOwned = false;
    public bool MinigunOwned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(weaponTags[0]))
        {
            akOwned = true;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag(weaponTags[1]))
        {
            shotgunDBOwned = true;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag(weaponTags[2]))
        {
            MinigunOwned = true;
            other.gameObject.SetActive(false);
        }
    }
}


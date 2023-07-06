using UnityEngine;

public class WeaponCollisionDetector : Singleton<WeaponCollisionDetector>
{
    private string[] weaponTags = { "Revolver", "Ak-47", "ShotgunDB", "Minigun" };
    public bool revolver = false;
    public bool akOwned = false;
    public bool shotgunDBOwned = false;
    public bool MinigunOwned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(weaponTags[0]))
        {
            revolver = true;
            other.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("WeaponPickup");
        }
        else if (other.CompareTag(weaponTags[1]))
        {
            akOwned = true;
            other.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("WeaponPickup");
        }
        else if (other.CompareTag(weaponTags[2]))
        {
            shotgunDBOwned = true;
            other.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("WeaponPickup");
        }
        else if(other.CompareTag(weaponTags[3]))
        {
            MinigunOwned = true;
            other.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("WeaponPickup");
        }
    }
}


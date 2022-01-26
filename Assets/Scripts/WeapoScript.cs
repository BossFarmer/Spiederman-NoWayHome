using UnityEngine;

public class WeapoScript : MonoBehaviour
{
    [SerializeField] private Camera cam; 
    [SerializeField] private ParticleSystem muzzleFlash; 
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bullet;
    private float damage = 10f;
    private float range = 100f;
    // Update is called once per frame
    void Update()
    {
        PlayerShooting();
    }

    void PlayerShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //ShootRayCast();
            ShootOrigin();
        }
    }
    void ShootRayCast()
    {
        muzzleFlash.Play(); 
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            } 
        }
    }

    void ShootOrigin()
    {
        muzzleFlash.Play();
        GameObject _bullet = Instantiate(bullet,spawnPoint.position,Quaternion.identity);
    }
}

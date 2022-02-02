using UnityEngine;

public class WeapoScript : MonoBehaviour
{
    #region private Variables
    [SerializeField] private Camera cam; 
    [SerializeField] private ParticleSystem muzzleFlash; 
    [SerializeField] private GameObject bullet;
    private ConnectWeapon cws;
    private float damage = 10f;
    private float range = 100f;
    private int currenMag = 0;
    #endregion

    #region public Variables
    public Transform spawnPoint;
    #endregion 

    private void Start()
    {
        cws = GetComponent<ConnectWeapon>();
        cam = Camera.main;
        currenMag = cws.wMagazineSize;
    }
    void Update()
    {
        PlayerShooting();
    }

    void PlayerShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(cws.name + "schieﬂt");
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
        if (true)
        {
            muzzleFlash.Play();
            GameObject _bullet = Instantiate(bullet,spawnPoint.position,Quaternion.identity);
            currenMag--;
            Destroy(_bullet, 5f);
        }
        else
        {
            Debug.Log("Mag is empty!");
        }
    }
}

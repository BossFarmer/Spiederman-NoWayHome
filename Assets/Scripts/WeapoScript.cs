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
    private bool temp, temp2 = true;
    private int indxTemp;
    private float shootDelay;
    #endregion

    #region public Variables
    public Transform spawnPoint;
    #endregion

    private void Start()
    {
        cws = GetComponent<ConnectWeapon>();
        cam = Camera.main;
        indxTemp = cws.WIndex;
    }
    void Update()
    {
        LoadGun();
        PlayerShooting();
 
    }

    void PlayerShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootGunSemi();
            Debug.Log(cws.name + "schieﬂt" + currenMag);
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

    void ShootGunSemi()
    {
        if (currenMag >= 0)
        {
            muzzleFlash.Play();
            GameObject _bullet = Instantiate(bullet,spawnPoint.position,Quaternion.identity);
            currenMag--;
            Destroy(_bullet, 5f);
            shootDelay = cws.WShootDelay;
        }
        else
        {
            Debug.Log("Mag is empty!");
        }
    }

    void LoadGun()
    {
        if (temp)
        {
            currenMag = cws.WMagazineSize;
            Debug.Log(cws.name + " MagazineSize: " + currenMag);
            temp = false;
        }

        if (temp2)
        {
            shootDelay = cws.WShootDelay;
            Debug.Log("WeaponScript : Shootdelay = " + shootDelay);
            temp2 = false;
        }
    }


  
}

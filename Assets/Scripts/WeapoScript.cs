using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class WeapoScript : MonoBehaviour
{
    #region private Variables
    [SerializeField] private Camera cam; 
    [SerializeField] private ParticleSystem muzzleFlash; 
    [SerializeField] private GameObject bullet;
    private ConnectWeapon cws;
    private float damage = 10f;
    private float range = 100f;
    private int currenMag;
    private bool temp = true, temp2 = true, isShootingSemi, isShootingAuto;
    private int indxTemp;
    private float shootDelay, nextShoot = 0f;
    private PlayerInputAction action;
    #endregion

    #region public Variables
    public Transform spawnPoint;
    #endregion

    private void Awake()
    {
        action = new PlayerInputAction();
        action.Player.Enable();
        action.Player.Shoot.performed += ShootSemiInput;
        action.Player.Shoot.performed += ShootingAutoInput;
    }

    private void ShootingAutoInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isShootingAuto = obj.ReadValueAsButton();
    }

    private void ShootSemiInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var controll = obj.control;
        var button = controll as ButtonControl;
        // noch Semi feuer einstellen mit Hilfe
        Debug.Log("Semi geschossen" + obj);
    }

    private void Start()
    {
        cws = GetComponent<ConnectWeapon>();
        cam = Camera.main;
        indxTemp = cws.WIndex;
    }
    void Update()
    {
        LoadGun();
        if (cws.WClass == "AssaultRifle")
        {
            ShootingAuto();
        }
        else
        {
            ShootingSemi(); 
        }
    }

    void ShootingSemi()
    {
        if (isShootingSemi && Time.time > nextShoot)
        {
            nextShoot = Time.time + shootDelay;
            ShootGun();
            Debug.Log(cws.name + "schieﬂt" + currenMag);
        }
    }
    void ShootingAuto()
    {
        if (isShootingAuto && Time.time > nextShoot)
        {
            nextShoot = Time.time + shootDelay;
            ShootGun();
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

    void ShootGun()
    {
        if (true)
        {
            muzzleFlash.Play();
            GameObject _bullet = Instantiate(bullet, cam.transform.position + cam.transform.forward ,Quaternion.identity);
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

using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class WeapoScript : MonoBehaviour
{
    #region private Variables
    [SerializeField] private Camera cam, secondCam;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject bullet;
    public EquipmentScript equipmentScriptp1;
    public EquipmentScript equipmentScriptp2;
    private ConnectWeapon cws;
    private CWSP2 cwsP2;
    private float damage = 10f;
    private float range = 100f;
    private bool temp = true, temp2 = true, temp3 = true, temp4 = true, isShootingSemiP1, isShootingSemiP2, isShootingAutoP1, isShootingAutoP2;
    private int indxTemp;
    private float shootDelay, shootDelayP2, nextShoot = 0f;
    #endregion

    #region public Variables
    public Transform spawnPoint;
    public bool shootP2, shootP1;
    public int currenMag, currenMagP2;
    #endregion

    private void Awake()
    {
        CheckPlayer();

    }
    private void ShootingAutoInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (transform.root.tag == "Player")
        {
            isShootingAutoP1 = obj.ReadValueAsButton();
        }
        else if (transform.root.tag == "Player2")
        {
            isShootingAutoP2 = obj.ReadValueAsButton();
        }
    }

    private void ShootSemiInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var controll = obj.control;
        var button = controll as ButtonControl;
        if (transform.root.tag == "Player")
        {
            isShootingSemiP1 = button.wasPressedThisFrame;
        }
        else if (transform.root.tag == "Player2")
        {
            isShootingSemiP2 = button.wasPressedThisFrame;
        }

    }
    private void Start()
    {
        cam = Camera.main;
        equipmentScriptp1 = this.GetComponentInParent<EquipmentScript>();
        equipmentScriptp2 = this.GetComponentInParent<EquipmentScript>();
    }
    void Update()
    {
        var Player1 = GameObject.FindGameObjectWithTag("Player");
        var PLayer2 = GameObject.FindGameObjectWithTag("Player2");
        if (secondCam == null && transform.root.gameObject.tag == "Player2")
        {
            secondCam = GameObject.FindGameObjectWithTag("SecondCamera").GetComponent<Camera>();
        }
        if (transform.root.gameObject.tag == "Player")
        {
            if (temp3)
            {
                currenMag = cws.WMagazineSize;
                temp3 = false;
            }
        }
        if (transform.root.gameObject.tag == "Player2")
        {
            if (temp4)
            {
                currenMagP2 = cwsP2.WMagazineSize;
                temp4 = false;
            }
        }
        if (Player1 != null || PLayer2 != null)
        {
            ShootingSemiP1();
            ShootingAutoP1();
            ShootingAutoP2();
            ShootingSemiP2();
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

    void ShootingSemiP1()
    {
        if (isShootingSemiP1 && Time.time > nextShoot && cws.WName != "AK47")
        {
            shootP1 = true;
            nextShoot = Time.time + shootDelay;
            ShootGunP1();
            isShootingSemiP1 = false;
        }
    }

    void ShootingSemiP2()
    {
        if (isShootingSemiP2 && Time.time > nextShoot && cwsP2.WName != "AK47")
        {
            shootP2 = true;
            nextShoot = Time.time + shootDelay;
            ShootGunP2();
            isShootingSemiP2 = false;
        }
    }

    void ShootingAutoP1()
    {
        if (isShootingAutoP1 && Time.time > nextShoot && cws.WName == "AK47")
        {
            nextShoot = Time.time + shootDelay;
            ShootGunP1();
        }
    }
    void ShootingAutoP2()
    {
        if (isShootingAutoP2 && Time.time > nextShoot && cwsP2.WName == "AK47")
        {
            nextShoot = Time.time + shootDelay;
            ShootGunP2();
        }
    }
    public void ShootGunP1()
    {
        if (true)
        {
            muzzleFlash.Play();
            GameObject _bullet = Instantiate(bullet, cam.transform.position + cam.transform.forward, Quaternion.identity);
            currenMag--;
            Destroy(_bullet, 5f);
            shootDelay = cws.WShootDelay;
            if (currenMag == 0)
            {
                ReloadP1();
                equipmentScriptp1.CheckWeapon();
            }
        }
        else
        {
            Debug.Log("Mag is empty!");
        }
    }

    public void ReloadP1()
    {
        currenMag = cws.WMagazineSize;
    }
    public void ReloadP2()
    {
        currenMagP2 = cwsP2.WMagazineSize;
    }

    public void ShootGunP2()
    {
        if (true)
        {
            muzzleFlash.Play();
            GameObject _bullet = Instantiate(bullet, secondCam.transform.position + secondCam.transform.forward, Quaternion.identity);
            currenMagP2--;
            equipmentScriptp2.CheckWeapon();
            Destroy(_bullet, 5f);
            shootDelay = cwsP2.WShootDelay;

        }
        else
        {
            Debug.Log("Mag2 is empty!");
        }
    }

    void LoadGunP1()
    {
        if (temp)
        {
            currenMag = cws.WMagazineSize;
            shootDelay = cws.WShootDelay;
            temp = false;
        }
    }

    void LoadGunP2()
    {
        if (temp2)
        {
            currenMagP2 = cwsP2.WMagazineSize;
            shootDelayP2 = cwsP2.WShootDelay;
            temp2 = false;
        }
    }

    public void CheckPlayer()
    {
        PlayerInputActions action = new PlayerInputActions();
        if (transform.root.gameObject.tag == "Player")
        {
            action.Player.Enable();
            action.Player.Shoot.performed += ShootSemiInput;
            action.Player.Shoot.performed += ShootingAutoInput;
            cws = GetComponent<ConnectWeapon>();
            LoadGunP1();
        }

        if (transform.root.gameObject.tag == "Player2")
        {
            action.Player2.Enable();
            action.Player2.Shoot.performed += ShootSemiInput;
            action.Player2.Shoot.performed += ShootingAutoInput;
            cwsP2 = GetComponent<CWSP2>();
            LoadGunP2();
        }
    }
}

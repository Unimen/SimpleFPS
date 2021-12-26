using UnityEngine;
using System.Collections;

[System.Serializable] //make place for object in unity
public class GunShootTwice : MonoBehaviour
{
    //for Shooting
    public float damageAndPain = 10f;
    public float rangeRaysHits = 100f;
    public float hitsPerSecond = 15f;
    public float hittingForce = 30f;
    //For reload
    public int maxiAmmo = 10;
    private int obtainAmmo;
    public float reloadTimes = 15f;
    private bool isReloadingThis = false;



    public Camera camira;
    public ParticleSystem PistolGunFlash;

    private float nextTimeToHit = 0f;
    //for animation
  
    public Animator animator;
    public string currentAnimation;
    //states of animation
    const string GUN_IDLE = "GunIdle";
    const string GUN_RELOAD = "GunReload";

    // Start is called before the first frame update
    void Start()
    {
        
        
        
        obtainAmmo = maxiAmmo;
        
    }
    void OnEnable()
    {//repair no reload block animation
        //isReloadingThis = false;
        //animator.SetBool("Reloading", false);


    }
    //void ChangeAnimationState(string newState)
    //{
    //    //stop the same animation form interuupting itself
    //    if (currentAnimation == newState) return;

    //    //play animation
    //    animator.Play(newState);
        
    //}

    // Update is called once per frame
    void Update()
    {
        
        if (isReloadingThis)
            return;
        if (obtainAmmo <= 0)
        {
            StartCoroutine(ReloadThis());
            return;
        }
        //shoot after press button and check if you have ammo to do this
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToHit && obtainAmmo > 0)
        {
            nextTimeToHit = Time.time + 1f / hitsPerSecond;
            ShootingInFace();

        }
        if(Input.GetKeyDown(KeyCode.R) && obtainAmmo < maxiAmmo)
        {
            StartCoroutine(ReloadThis());

        }
        
    }
    //corotine(time fuction example delay)
    IEnumerator ReloadThis()
    {
        isReloadingThis = true;
        Debug.Log("Reloading...");
        //change of animation
        //ChangeAnimationState(GUN_RELOAD);
        //animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTimes - .25f);

        //ChangeAnimationState(GUN_IDLE);
        //animator.SetBool("Reloading", false);
        //yield return new WaitForSeconds(.25f);

        obtainAmmo = maxiAmmo;
        isReloadingThis = false;
        Debug.Log("Reloading..Finished");
    }
    void ShootingInFace()
    {
        PistolGunFlash.Play();

        obtainAmmo--;

        RaycastHit bighit;
        //if hit then
        if (Physics.Raycast(camira.transform.position, camira.transform.forward, out bighit, rangeRaysHits))
        {
            Debug.Log("We hit " + bighit.transform.name);

            TagThisAsshole targeting = bighit.transform.GetComponent<TagThisAsshole>();
            if (targeting != null)
            {
                targeting.ThisALotDamage(damageAndPain);
            }
            if (bighit.rigidbody != null)
            {
                bighit.rigidbody.AddForce(-bighit.normal * hittingForce);

            }

        }
    }
}

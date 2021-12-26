using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public int chosenGun = 0;
    // Start is called before the first frame update
    void Start()
    {
        ChoiceGun();
        
    }
  

    // Update is called once per frame
    void Update()
    {
        int pastChosenGun = chosenGun;
        //choice gun with ScrollWheel
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (chosenGun >= transform.childCount - 1)
                chosenGun = 0;
            else
                chosenGun++; 

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (chosenGun <= 0)
                chosenGun = transform.childCount - 1;
            else
                chosenGun--;

        }
        //Chosen Pistol
        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1)
        {
            chosenGun = 0;

        }
        //Chosen Rifle
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            chosenGun = 1;


        }
        //Chosen SubmachinePistol
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            chosenGun = 2;

        }
        //Chosen MachineGun
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            chosenGun = 3;

        }
        //Chosen granade
        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            chosenGun = 4;

        }
        //Chosen heavyGun
        if (Input.GetKeyDown(KeyCode.Alpha6) && transform.childCount >= 6)
        {
            chosenGun = 5;

        }
        if (pastChosenGun != chosenGun)
        {
            ChoiceGun();

        }

    }
    void ChoiceGun()
    {
        int i = 0;
        foreach (Transform gun in transform)
        {
            if (i == chosenGun)
                gun.gameObject.SetActive(true);
            else
                gun.gameObject.SetActive(false);
            i++;
        }
    }
}

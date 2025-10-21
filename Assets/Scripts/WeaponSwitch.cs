using Unity.VisualScripting;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    private GameObject sword;
    private GameObject slingshot;


    void Start()
    {
        sword = GameObject.Find("sword");
        slingshot = GameObject.Find("slingshot");

        sword.SetActive(true);
        slingshot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (char key in Input.inputString)
        {
            var input = Input.inputString;

            switch (input)
            {
                case "1":
                    {
                        Debug.Log("sword");
                        sword.SetActive(true);
                        slingshot = GameObject.Find("slingshot");
                        if (slingshot != null) slingshot.SetActive(false);
                        break;
                    }
                case "2":
                    {
                        Debug.Log("slingshot");
                        slingshot.SetActive(!slingshot.activeSelf);
                        if (sword != null) sword.SetActive(false);
                        break;
                    }

            }
        }
    }
}

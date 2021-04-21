using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWelcomeText : MonoBehaviour
{
    public GameObject Clock;
    public GameObject UI;

    public AudioClip mySound;
    public AudioSource mySource;
    public float myVolume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Destroy(gameObject);
            Clock.SetActive(true);
            UI.SetActive(true);

            Time.timeScale = 1;

            mySource.PlayOneShot(mySound, myVolume);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesEtme : MonoBehaviour
{
    RaycastHit hit;
    public GameObject MermiCikisNoktasi;
    public bool AtesEdebilir;
    float GunTimer;
    public float TaramaHizi;
    public ParticleSystem MuzzleFlash;
    AudioSource SesKaynak;
    public AudioClip AtesSesi;
    public float Menzil;

    public GeriTepme recoil;

    public GameObject mermiefekti;
    // Start is called before the first frame update
    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0) && AtesEdebilir == true && Time.time > GunTimer)
        {
            Fire();
            GunTimer = Time.time + TaramaHizi;
            recoil.Fire();
            Instantiate(mermiefekti, hit.point, Quaternion.LookRotation(hit.normal)); 

        }
    }

    void Fire()
    {

        if (Physics.Raycast(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, out hit, Menzil))
        {
            MuzzleFlash.Play();
            SesKaynak.Play();
            SesKaynak.clip = AtesSesi;
            Debug.Log(hit.transform.name);
        }
    }

}
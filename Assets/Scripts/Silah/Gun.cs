using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Gun : MonoBehaviour
{
    RaycastHit hit;
    public GameObject mermiCikisNoktasi;
    public ParticleSystem particle;

    //Mermi özelliði
    public int hasar;
    public float aralýk;
    float sayac;
    public float zaman;
    public LayerMask lm;
    public NavMeshAgent agent;
    public Transform parentTransform;
    void Update()
    {
        HasarVer();
        
    }
    public void HasarVer()
    {
        var enemies = Physics.OverlapSphere(transform.position, aralýk, lm);//Daire çizmek için:OverlapShere ,aralýk=yarýçap ,lm=görecegi nesneler
        //Debug.Log(enemies.Length);
        if (enemies.Length >= 1)//null olmuyor. Ýçinde bir obje varmý?
        {
            agent.updateRotation = false; //Bina gördüðü an dönme dursun yani collider array içinde bina varsa dursun
            //Debug.Log(enemies);
            parentTransform.LookAt(enemies[0].transform);//Tankýn kendisi transformu binaya dönük olsun
            sayac += Time.deltaTime; //1.5 saniye
            if (sayac >= zaman)
            {
                particle.Play();
                //Debug.Log("dmg atildi");
                enemies[0].GetComponent<EnemyHealth>().TakeDamage(hasar);//ilk gördüðü binaya vur
                sayac = 0f;
            }
        }
        else
        {
            agent.updateRotation = true; //tanký döndür
        }
        
    }





}

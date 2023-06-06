using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Gun : MonoBehaviour
{
    RaycastHit hit;
    public GameObject mermiCikisNoktasi;
    public ParticleSystem particle;

    //Mermi �zelli�i
    public int hasar;
    public float aral�k;
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
        var enemies = Physics.OverlapSphere(transform.position, aral�k, lm);//Daire �izmek i�in:OverlapShere ,aral�k=yar��ap ,lm=g�recegi nesneler
        //Debug.Log(enemies.Length);
        if (enemies.Length >= 1)//null olmuyor. ��inde bir obje varm�?
        {
            agent.updateRotation = false; //Bina g�rd��� an d�nme dursun yani collider array i�inde bina varsa dursun
            //Debug.Log(enemies);
            parentTransform.LookAt(enemies[0].transform);//Tank�n kendisi transformu binaya d�n�k olsun
            sayac += Time.deltaTime; //1.5 saniye
            if (sayac >= zaman)
            {
                particle.Play();
                //Debug.Log("dmg atildi");
                enemies[0].GetComponent<EnemyHealth>().TakeDamage(hasar);//ilk g�rd��� binaya vur
                sayac = 0f;
            }
        }
        else
        {
            agent.updateRotation = true; //tank� d�nd�r
        }
        
    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivateTime : MonoBehaviour
{
    public GameObject particleInvencible;
    public float delay = 3f; // o tempo em segundos que você quer esperar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particleInvencible.SetActive(true);
            Invoke("DesativarObjeto", delay); // chama a função DesativarObjeto depois de delay segundos
        }
    }

    private void DesativarObjeto()
    {
        particleInvencible.SetActive(false); // desativa o objeto
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : ItemCollactableBase
{
    public Collider Collider;
    public bool collect = false;
    public float lerp = 3f;
    public float minDistance = 1f;

    protected override void OnCollect()
    {
        base.OnCollect();        
        Collider.enabled = false;
        collect = true;
    }

    protected override void Collect()
    {
        OnCollect();
    }

    private void Update()
    {
        if(collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);
            //Esconde e destroy os Candys, apos coletado
            /*if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                HideItens();
                Destroy(gameObject);
            }*/
        }
    }
}

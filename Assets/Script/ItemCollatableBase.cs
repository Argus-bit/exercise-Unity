using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollatableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    /*public float timeToHide = 3;
    public GameObject graphicItem;*/

    //muda a Hierarquida de dentro do projeto
    private void Awake()
    {
       if(particleSystem != null) particleSystem.transform.SetParent(null);
    }
    //muda a Hierarquida de dentro do projeto

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            
            Collect();
        }
    }
    protected virtual void Collect()
    {
        /*if(graphicItem !=null) graphicItem.SetActive(false);*/
        gameObject.SetActive(false); 
        OnCollect();
    }
   /* private void HideObject()
    {
        gameObject.SetActive(false);
    }*/
    protected virtual void OnCollect(){
        if (particleSystem != null) particleSystem.Play(); }

}

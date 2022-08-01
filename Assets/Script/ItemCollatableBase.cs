using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollatableBase : MonoBehaviour
{
    public string compareTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            
            Collect();
        }
    }
    protected virtual void Collect()
    {
        gameObject.SetActive(false); 
        OnCollect();
    }

    protected virtual void OnCollect(){}

}

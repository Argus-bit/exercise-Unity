using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShoot;
    private Coroutine _currentCoroutine;
    public Transform PlayerSideReference;

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.S))
       {
            _currentCoroutine = StartCoroutine(StartShoot());
       }
       else  if(Input.GetKeyDown(KeyCode.S))
       {
            if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
       }
    }
    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = PlayerSideReference.transform.localScale.x;
    }
}

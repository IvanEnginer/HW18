using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject EffectObject;
    public GameObject ForceObject;

    public Body Body;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Explode();
        }
    }

    private void Explode()
    {
        EffectObject.SetActive(true);
        ForceObject.SetActive(true);
        Invoke("HideForceObject", 0.3f);
        Body.BecomDynamic();
    }

    private void HideForceObject()
    {
        ForceObject.SetActive(false);
    }
}

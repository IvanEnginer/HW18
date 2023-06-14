using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Transform Target;
    public float LerpRate;

    void FixedUpdate() {

        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * LerpRate);
        //transform.rotation = Quaternion.Lerp(transform.rotation, Target.rotation, Time.deltaTime * LerpRate);

    }
}

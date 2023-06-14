using UnityEngine;
using UnityEngine.U2D.IK;

public class Body : MonoBehaviour
{
    public BodyPart[] BodyParts;
    public Animator Animator;
    public IKManager2D IKManager2D;

    public void BecomDynamic()
    {
        Animator.enabled = false;
        IKManager2D.enabled = false;

        for (int i = 0; i < BodyParts.Length; i++)
        {
            BodyParts[i].BecomDynamic();
        }


    }
}

using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public Camera Camera;
    public Transform Hook;

    public BodyPart SelectedBodyPart;

    public SpringJoint2D SpringJoint2D;

    public Text SelectedBodyPartText;

    private void Update()
    {
        Vector3 cursorWorldPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        
        cursorWorldPosition.z = 0;

        Hook.position = cursorWorldPosition;
         
        RaycastHit2D hit = Physics2D.Raycast(cursorWorldPosition, Vector2.zero);

        if(hit)
        {
            if (hit.collider)
            {
                if (hit.collider.GetComponent<BodyPart>())
                { 
                    SelectedBodyPart = hit.collider.GetComponent<BodyPart>();

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (SpringJoint2D)
                        { 
                            Destroy(SpringJoint2D);
                        }

                        SpringJoint2D = Hook.gameObject.AddComponent<SpringJoint2D>();
                        SpringJoint2D.connectedBody = SelectedBodyPart.GetComponent<Rigidbody2D>();
                        SpringJoint2D.autoConfigureDistance = false;
                        SpringJoint2D.distance = 0;
                        SpringJoint2D.frequency = 5f;
                        SpringJoint2D.dampingRatio = 1f;

                        SelectedBodyPartText.text = SelectedBodyPart.name;
                    }
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                if(SpringJoint2D)
                {
                    Destroy(SpringJoint2D);
                    SelectedBodyPartText.text = "None";
                }
            }
        }
    }


}

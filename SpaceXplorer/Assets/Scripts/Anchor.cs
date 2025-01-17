using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AnchorExistingObject : MonoBehaviour
{
    public GameObject objectToAnchor;
    public ARRaycastManager raycastManager;
    public ARAnchorManager anchorManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (raycastManager.Raycast(touch.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;

                    ARPlane plane = hits[0].trackable as ARPlane;

                    ARAnchor anchor = anchorManager.AttachAnchor(plane, hitPose);

                    if (anchor != null)
                    {
                        objectToAnchor.transform.position = hitPose.position;
                        objectToAnchor.transform.rotation = hitPose.rotation;

                        objectToAnchor.transform.SetParent(anchor.transform);

                    }
                }
            }
        }
    }
}

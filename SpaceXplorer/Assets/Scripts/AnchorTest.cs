using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AnchorExistingObject : MonoBehaviour
{
    public GameObject objectToAnchor;  // The GameObject in your scene to be anchored
    public ARRaycastManager raycastManager;
    public ARAnchorManager anchorManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        // Check if the user touches the screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Perform a raycast to detect a surface
                if (raycastManager.Raycast(touch.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;

                    // Get the detected plane
                    ARPlane plane = hits[0].trackable as ARPlane;

                    // Attach the anchor to the detected plane
                    ARAnchor anchor = anchorManager.AttachAnchor(plane, hitPose);

                    if (anchor != null)
                    {
                        // Move the GameObject to the anchor's position
                        objectToAnchor.transform.position = hitPose.position;
                        objectToAnchor.transform.rotation = hitPose.rotation;

                        // Parent the GameObject to the anchor
                        objectToAnchor.transform.SetParent(anchor.transform);

                        Debug.Log("GameObject successfully anchored!");
                    }
                    else
                    {
                        Debug.LogError("Failed to attach an anchor.");
                    }
                }
            }
        }
    }
}

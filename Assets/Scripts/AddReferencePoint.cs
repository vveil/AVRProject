using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class AddReferencePoint : MonoBehaviour
{
  ARReferencePointManager arReferencePointManager;
  ARPlaneManager arPlaneManager;
  ARPointCloudManager arPointCloudManager;
  GameObject gamePrefab = null;

  private void Awake()
  {
    arReferencePointManager = GetComponent<ARReferencePointManager>();
    arPlaneManager = GetComponent<ARPlaneManager>();
    arPointCloudManager = GetComponent<ARPointCloudManager>();
  }

  /// <summary>
  /// Deaktiviert ARPlane, ARPointCloudManager und setzt das Placement Prefab des ARPlacementInteractable auf null
  /// </summary>
  /// <param name="arPlacementInteractable"></param>
  /// <param name="placedObject"></param>
  public void SetReferencePointAsParent(ARPlacementInteractable arPlacementInteractable, GameObject placedObject)
  {

    if (gamePrefab == null)
    {
      gamePrefab = arPlacementInteractable.placementPrefab;
    }

    Vector3 position = placedObject.transform.position;
    Quaternion quaternion = placedObject.transform.rotation;
    Pose hitPose = new Pose(position, quaternion);

    // will be null when unsuccessful
    ARReferencePoint referencePoint = arReferencePointManager.AddReferencePoint(hitPose);

    placedObject.transform.SetParent(referencePoint.transform);

    arPlaneManager.enabled = false;
    foreach (ARPlane plane in arPlaneManager.trackables)
    {
      plane.gameObject.SetActive(false);
    }
    arPointCloudManager.enabled = false;
    foreach (ARPointCloud pointCloud in arPointCloudManager.trackables)
    {
      pointCloud.gameObject.SetActive(false);
    }

    arPlacementInteractable.placementPrefab = null;
  }
}
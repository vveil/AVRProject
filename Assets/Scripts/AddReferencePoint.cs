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

  /// <summary>
  /// Awake is called when the script instance is being loaded.
  /// </summary>
  private void Awake()
  {
    arReferencePointManager = GetComponent<ARReferencePointManager>();
    arPlaneManager = GetComponent<ARPlaneManager>();
    arPointCloudManager = GetComponent<ARPointCloudManager>();
  }

  public void SetReferencePointAsParent(ARPlacementInteractable arPlacementInteractable, GameObject placedObject)
  {

    if (gamePrefab == null)
    {
      gamePrefab = arPlacementInteractable.placementPrefab;
    }

    // if (GameObject.FindWithTag("Scorer").GetComponent<ScoreController>().score == 8)
    // {
    //     GameObject.FindWithTag("Game").GetComponent<ARSession>().Reset();
    // }

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

    // GameObject.FindWithTag("MainCamera").GetComponent<Werfen>().gameObjectIsSet = true;

  }

  public void ResetGame()
  {
    // GameObject.FindWithTag("Scorer").GetComponent<ScoreController>().score = 0;
    // GameObject.FindWithTag("MainCamera").GetComponent<Werfen>().gameObjectIsSet = false;
    // GameObject.FindWithTag("MainCamera").GetComponent<Werfen>().ballCount = 0;
    // GameObject.FindWithTag("ScoreBoard_Balls").GetComponent<Text>().text = "Würfe: 0";
    // GameObject.FindWithTag("ScoreBoard_Score").GetComponent<Text>().text = "Punkte: 0";
    GameObject.FindWithTag("Game").GetComponent<ARPlacementInteractable>().placementPrefab = gamePrefab;
    foreach (ARPlane plane in arPlaneManager.trackables)
    {
      plane.gameObject.SetActive(true);
    }
    foreach (ARPointCloud pointCloud in arPointCloudManager.trackables)
    {
      pointCloud.gameObject.SetActive(true);
    }
    arPlaneManager.enabled = true;
    arPointCloudManager.enabled = true;
    // GameObject.Find("Debug").GetComponent<Text>().text = GameObject.FindWithTag("Game").GetComponent<ARPlacementInteractable>().placementPrefab.name;
    GameObject.FindWithTag("GameSession").GetComponent<ARSession>().Reset();
  }
}
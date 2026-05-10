using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraManager : MonoBehaviour
{
        [SerializeField] private Transform PlayerTransform;
        [SerializeField] private float displacementMultiplier = 0.15f;
        private float zPosition = -10;
 
        private void Update()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 cameraDisplacement = (mousePosition - PlayerTransform.position) * displacementMultiplier;
 
            Vector3 finalCameraPosition = PlayerTransform.position + cameraDisplacement;
            finalCameraPosition.z = zPosition;
            transform.position = finalCameraPosition;
        }
    }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactionguidance : MonoBehaviour
{

    [SerializeField] private Camera _camera;

    void Update()
    {

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            if (hit.collider.TryGetComponent(out LaunchAndReaction clickable)) {
                clickable.Hit();
            }
        }

    }
}

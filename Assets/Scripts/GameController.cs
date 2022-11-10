using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactorySimulator
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private float cameraPanSpeed;
        [SerializeField] private GameObject marker;

        private Unit selectedUnit;

        private void Update()
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 cameraOffset = new Vector3(input.x, 0f, input.y);
            Camera.main.transform.position += cameraOffset * cameraPanSpeed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    Unit unit = hitInfo.collider.GetComponent<Unit>();
                    selectedUnit = unit;

                    IUIContent content = hitInfo.transform.GetComponent<IUIContent>();
                    UIController.Instance.SetCurrentContent(content);

                    MarkerHandling();
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse1) && selectedUnit)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    Building building = hitInfo.transform.GetComponent<Building>();
                    if (building)
                    {
                        selectedUnit.GoTo(building);
                    }
                    else
                    {
                        selectedUnit.GoTo(hitInfo.point);
                    }
                }
            }
        }

        private void MarkerHandling()
        {
            if (selectedUnit && marker.transform.parent != selectedUnit.transform)
            {
                marker.SetActive(true);
                marker.transform.SetParent(selectedUnit.transform, false);
                Vector3 markerNewPos = Vector3.up * 1.5f;
                marker.transform.localPosition = markerNewPos;
            }
            else if(!selectedUnit && marker.activeInHierarchy)
            {
                marker.SetActive(false);
                marker.transform.SetParent(null, false);
            }
        }
    }
}


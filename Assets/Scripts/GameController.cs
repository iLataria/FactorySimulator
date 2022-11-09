using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactorySimulator
{
    public class GameController : MonoBehaviour
    {
        Ray ray;

        private Unit selectedUnit;
        private Unit prevSelectedUnit;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                //Debug.Log($"Click left mouse btn");
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    Debug.Log($"Ray hitted {hitInfo.collider.name}");
                    //Building building = hitInfo.collider.GetComponent<Building>();
                    //if (building)
                    //{
                    //    Debug.Log($"building clicked {building.gameObject.name}");
                    //    building.AddResource("table", 3);
                    //}

                    Unit unit = hitInfo.collider.GetComponent<Unit>();
                    if (unit)
                    {
                        if (selectedUnit != null)
                        {
                            selectedUnit.SetMarkerActive(false);
                        }
                        selectedUnit = unit;
                      
                        selectedUnit.SetMarkerActive(true);
                        Debug.Log($"Unit clicked");
                    }
                    else
                    {
                        if (selectedUnit)
                        {
                            selectedUnit.SetMarkerActive(false);
                            selectedUnit = null;
                        }
                    }

                    IUIContent content = hitInfo.transform.GetComponent<IUIContent>();
                    UIController.Instance.SetCurrentContent(content);
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && selectedUnit)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    Building building = hitInfo.transform.GetComponent<Building>();
                    if (building)
                    {
                        Debug.Log($"Goto building");
                        selectedUnit.GoTo(building);
                    }
                    else
                    {
                        selectedUnit.GoTo(hitInfo.point);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log($"Click left mouse btn");
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    Debug.Log($"Ray hitted {hitInfo.collider.name}");
                    Building building = hitInfo.collider.GetComponent<Building>();
                    if (building)
                    {
                        Debug.Log($"building clicked {building.gameObject.name}");
                        building.RemoveResource("id1", 3);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            //Debug.Log($"Draw");
            //Gizmos.color = Color.red;
            //Gizmos.DrawRay(ray);
            //Gizmos.DrawLine(ray.origin, (ray.direction));
        }
    }
}


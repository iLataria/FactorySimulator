using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactorySimulator
{
    public class GameController : MonoBehaviour
    {
        Ray ray;
       
        private Unit selectedUnit;

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
                    Building building = hitInfo.collider.GetComponent<Building>();
                    if (building)
                    {
                        Debug.Log($"building clicked {building.gameObject.name}");
                        building.AddResource("id1", 3);
                    }

                    Unit unit = hitInfo.collider.GetComponent<Unit>();
                    if (unit)
                    {
                        selectedUnit = unit;
                        Debug.Log($"Unit clicked");
                       
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (selectedUnit)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hitInfo;

                    if (Physics.Raycast(ray, out hitInfo))
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


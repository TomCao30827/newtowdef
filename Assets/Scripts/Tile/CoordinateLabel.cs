using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

namespace CT239_TowDef
{

    [ExecuteAlways]
    public class CoordinateLabeler : MonoBehaviour
    {
        [SerializeField] private Color defaultColor = Color.white;
        [SerializeField] private Color blockColor = Color.gray;

        TextMeshPro label;
        Vector2Int coordinates = new Vector2Int();
        Waypoint waypoint;

        void Awake()
        {
            label = GetComponent<TextMeshPro>();
            waypoint = GetComponentInParent<Waypoint>();
            label.enabled = true;
            DisplayCoordinates();
        }

        void Update()
        {
            if (!Application.isPlaying)
            {
                DisplayCoordinates();
                UpdateObjectName();
            }
            ColorCoordinate();
            ToggleLabels();
        }

        void ToggleLabels()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                label.enabled = !label.IsActive();
            }
        }

        void ColorCoordinate()
        {
            if (waypoint.IsPlacable)
            {
                label.color = defaultColor;
            }
            else label.color = blockColor;
        }

        void DisplayCoordinates()
        {
            coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
            coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

            label.text = coordinates.x + "," + coordinates.y;
        }

        void UpdateObjectName()
        {
            transform.parent.name = coordinates.ToString();
        }
    }

}


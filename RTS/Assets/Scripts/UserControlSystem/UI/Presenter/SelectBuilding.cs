using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectBuilding : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private Transform _selectableTransform;
    private bool _isSelected;

    private void Start() =>
        _selectableValue.OnSelected += OnSelectBuilding;

    private void OnSelectBuilding(ISelectable selected)
    {
        _isSelected = selected != null;

        if(_isSelected)
        {
            _selectableTransform.transform.position = selected.Transform.position;
        }

        _selectableTransform.gameObject.SetActive(_isSelected);
    }
}

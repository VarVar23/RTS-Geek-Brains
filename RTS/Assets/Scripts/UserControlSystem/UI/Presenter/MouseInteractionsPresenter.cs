using UnityEngine;
using System.Linq;

public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectableValue;

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0)) return;

        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
    
        if (hits.Length == 0) return;

        var selected = hits
            .Select(hit => hit.collider.GetComponent<ISelectable>())
            .Where(x => x != null)
            .FirstOrDefault();

        //if (selected == default) return;

        _selectableValue.SetValue(selected);
        
    }
}


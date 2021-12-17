using UnityEngine;

public class MainBuilding : MonoBehaviour, ICreateUnit, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform Transform => transform;

    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private Transform _parentUnit;

    [SerializeField] private float _health = 1000;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;

    public void CreateUnit()
    {
        var position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        Instantiate(_unitPrefab, position, Quaternion.identity, _parentUnit);
    }
}

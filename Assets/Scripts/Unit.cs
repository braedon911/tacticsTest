using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] UnitData unitData;
    public delegate void UnitClickedEvent(Unit unit);
    public UnitClickedEvent unitClickedEvent;
    public int ActionPoints { get; set; }
    public Vector2Int Position { get; set; }
    void Awake()
    {
        ActionPoints = 2;
        Position = Vector2Int.zero;
    }
    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log($"{gameObject.name} clicked");
        unitClickedEvent.Invoke(this);
    }
    void Update()
    {
        transform.position = new Vector3(Position.x, 0, Position.y);
    }
}
public class MoveCommand : UnitCommandBase
{
    readonly Vector2Int startPosition;
    readonly Vector2Int endPosition;
    public MoveCommand(Unit unit, Vector2Int endPosition) : base(unit)
    {
        startPosition = unit.Position;
        this.endPosition = endPosition;
    }

    public override void Execute()
    {
        unit.Position = endPosition;
    }

    public override void Undo()
    {
        unit.Position = startPosition;
    }
}
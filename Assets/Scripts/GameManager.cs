using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachines;
public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    StateMachine stateMachine;
    Unit selectedUnit;
    HashSet<Unit> unitPool;
    CommandRecord masterCommandRecord;
    private void Awake()
    {
        instance = this;
        stateMachine = new StateMachine(State_NothingSelected, State_UnitSelected);
        masterCommandRecord = new CommandRecord();
        unitPool = new HashSet<Unit>();
    }
    private void Start()
    {
        var found = FindObjectsOfType<Unit>();
        foreach (var item in found)
        {
            unitPool.Add(item);
            item.unitClickedEvent += Select;
        }
    }
    public void Select(Unit unit)
    {
        selectedUnit = unit;
        stateMachine.ChangeState(State_UnitSelected);
    }
    private void Update()
    {
        stateMachine.Execute();
    }

    void State_UnitSelected() {
        masterCommandRecord.Do(new MoveCommand(selectedUnit, selectedUnit.Position + Vector2Int.right));
        stateMachine.ChangeState(State_NothingSelected);
        selectedUnit = null;
    }
    void State_NothingSelected()
    {

    }
}

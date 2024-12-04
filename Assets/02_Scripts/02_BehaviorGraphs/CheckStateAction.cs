using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CheckState", story: "[Self] 와 [Player] 의 거리를 [TraceDistance] 와 [AttackDistance] 를 사용해 [State] 를 변경", category: "Action", id: "553077dc3ef20770a37e018e3334c0ce")]
public partial class CheckStateAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Player;
    [SerializeReference] public BlackboardVariable<float> TraceDistance;
    [SerializeReference] public BlackboardVariable<float> AttackDistance;
    [SerializeReference] public BlackboardVariable<State> State;

    protected override Status OnUpdate()
    {
        // 거리 계산
        var distance = Vector3.Distance(Self.Value.transform.position, Player.Value.position);

        // 거리에 따라서 상태변경
        if (distance <= AttackDistance.Value)
        {
            State.Value = global::State.ATTACK;
        }
        else if (distance <= TraceDistance.Value)
        {
            State.Value = global::State.TRACE;
        }
        else
        {
            State.Value = global::State.PATROL;
        }

        // Debug.Log($"State : {State.Value} / 거리 : {distance}");

        return Status.Success;
    }
}


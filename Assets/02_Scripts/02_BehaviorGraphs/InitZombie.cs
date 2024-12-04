using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "InitZombie", story: "[ZombieData] 를 이용해서 [TraceDistance] 와 [AttackDistance] 를 초기화한다.", category: "Action", id: "aa45543cccf2c22a7f09ee76c2fa5014")]
public partial class InitZombieAction : Action
{
    [SerializeReference] public BlackboardVariable<ZombieDataSO> ZombieData;
    [SerializeReference] public BlackboardVariable<float> TraceDistance;
    [SerializeReference] public BlackboardVariable<float> AttackDistance;

    protected override Status OnStart()
    {
        TraceDistance.Value = ZombieData.Value.traceDistance;
        AttackDistance.Value = ZombieData.Value.attackDistance;

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}


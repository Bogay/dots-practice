using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Bogay.VampireSurvivorLike.System
{
    public partial class CountEnemyAndShow : SystemBase
    {
        protected override void OnUpdate()
        {
            var enemyCount = GetEntityQuery(ComponentType.ReadOnly<Component.Enemy>()).CalculateEntityCount();

            Entities
                .WithoutBurst()
                .ForEach((Component.EnemyCounter counter) =>
                {
                    counter.label.text = $"Enemy: {enemyCount}";
                })
                .Run();
        }
    }
}

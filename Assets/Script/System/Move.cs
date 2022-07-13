using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace Bogay.VampireSurvivorLike.System
{
    public partial class Move : SystemBase
    {
        protected override void OnUpdate()
        {
            float deltaTime = Time.DeltaTime;
            Entities.ForEach((ref Translation translation, ref Component.Move move) =>
            {
                translation.Value += move.Value * deltaTime;
                move.Value = float3.zero;
            }).Schedule();
        }
    }
}

using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Bogay.VampireSurvivorLike.System
{
    public partial class CameraTargetToPlayer : SystemBase
    {

        EndSimulationEntityCommandBufferSystem endSimulationEntityCommandBufferSystem;

        protected override void OnCreate()
        {
            this.endSimulationEntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commands = this.endSimulationEntityCommandBufferSystem.CreateCommandBuffer();
            Entities.ForEach((Entity entity, in LocalToWorld localToWorld, in Component.Follow follow) =>
            {
                var target = GetComponent<LocalToWorld>(follow.target);
                var targetPosition = target.Position;
                if (follow.lockX)
                    targetPosition.x = localToWorld.Position.x;
                if (follow.lockY)
                    targetPosition.y = localToWorld.Position.y;
                if (follow.lockZ)
                    targetPosition.z = localToWorld.Position.z;
                var newTransform = new LocalToWorld { Value = new float4x4(localToWorld.Rotation, targetPosition) };
                commands.SetComponent(entity, newTransform);
            }).Schedule();
            this.Dependency.Complete();
        }
    }
}

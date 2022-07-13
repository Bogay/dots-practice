using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Bogay.VampireSurvivorLike.System
{
    public partial class EnemyTargetToPlayer : SystemBase
    {
        EndSimulationEntityCommandBufferSystem endSimulationEntityCommandBufferSystem;

        protected override void OnCreate()
        {
            this.endSimulationEntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            LocalToWorld target = new LocalToWorld();
            if (!this.tryFindTarget(ref target))
                return;
            this.createMove(target);
            this.updateMove(target);
            this.Dependency.Complete();
        }

        // TODO: I am not sure whether this is the right way to find a player
        private bool tryFindTarget(ref LocalToWorld target)
        {
            var _target = new LocalToWorld();
            Entities
                .WithAll<Component.Player>()
                .ForEach((in LocalToWorld localToWorld) =>
                {
                    _target = localToWorld;
                }).Run();
            target = _target;
            return true;
        }

        private void updateMove(LocalToWorld target)
        {
            Entities
            .WithAll<Component.Enemy>()
            .ForEach((ref Component.Move move) =>
            {
                move.Value = target.Position;
            }).Schedule();
        }

        private void createMove(LocalToWorld target)
        {
            var commands = this.endSimulationEntityCommandBufferSystem
            .CreateCommandBuffer()
            .AsParallelWriter();
            Entities
                .WithAll<Component.Enemy>()
                .ForEach((Entity e, int entityInQueryIndex, in Component.MoveSpeed moveSpeed, in LocalToWorld localToWorld) =>
            {
                var dir = math.normalizesafe(target.Position - localToWorld.Position);
                commands.AddComponent(entityInQueryIndex, e, new Component.Move { Value = dir * moveSpeed.Value });
            }).ScheduleParallel();
        }
    }
}

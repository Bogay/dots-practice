using UnityEngine.InputSystem;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace Bogay.VampireSurvivorLike.System
{
    public partial class SpawnEnemy : SystemBase
    {
        BeginInitializationEntityCommandBufferSystem beginInitializationEntityCommandBufferSystem;

        protected override void OnCreate()
        {
            this.beginInitializationEntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
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

        protected override void OnUpdate()
        {
            // TODO: Abstrac input reading
            var keyboard = Keyboard.current;
            if (!keyboard.spaceKey.IsActuated())
                return;

            var target = new LocalToWorld();
            if (!this.tryFindTarget(ref target))
                return;
            var point = UnityEngine.Random.insideUnitCircle * 10;
            point.x += target.Position.x;
            point.y += target.Position.y;

            var commands = this.beginInitializationEntityCommandBufferSystem.CreateCommandBuffer();
            Entities.ForEach((ref Component.RedGuySpawn redGuySpawn) =>
            {
                var e = commands.Instantiate(redGuySpawn.Value);
                commands.AddComponent<Component.Enemy>(e);
                commands.SetComponent(e, new LocalToWorld());
                commands.SetComponent(e, new Translation
                {
                    Value = new float3
                    {
                        x = point.x,
                        y = point.y,
                        z = 0,
                    }
                });
            }).Schedule();
            this.Dependency.Complete();
        }
    }

}


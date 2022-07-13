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

        protected override void OnUpdate()
        {
            // TODO: Abstrac input reading
            var keyboard = Keyboard.current;
            if (keyboard.spaceKey.IsActuated())
            {
                var commands = this.beginInitializationEntityCommandBufferSystem.CreateCommandBuffer();
                var point = UnityEngine.Random.insideUnitCircle * 10;
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
                this.beginInitializationEntityCommandBufferSystem.AddJobHandleForProducer(this.Dependency);
            }
        }
    }

}


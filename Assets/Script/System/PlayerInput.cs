using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Bogay.VampireSurvivorLike.System
{
    public partial class PlayerInput : SystemBase
    {
        private Vector3 readUserInput()
        {
            var keyboard = Keyboard.current;
            var y = keyboard.upArrowKey.ReadValue() - keyboard.downArrowKey.ReadValue();
            var x = keyboard.rightArrowKey.ReadValue() - keyboard.leftArrowKey.ReadValue();
            return new Vector3(x, y, 0).normalized;
        }

        protected override void OnUpdate()
        {
            var dir = this.readUserInput();
            var dirFloat3 = new float3
            {
                x = dir.x,
                y = dir.y,
                z = dir.z,
            };
            Entities
                .WithAll<Component.Player>()
                .ForEach((ref Component.Move move, in LocalToWorld localToWorld, in Component.MoveSpeed speed) =>
                {
                    move.Value = dirFloat3 * speed.Value;
                })
                .Schedule();
        }
    }
}

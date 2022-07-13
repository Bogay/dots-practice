using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Bogay.VampireSurvivorLike.Component
{
    [DisallowMultipleComponent]
    public class HPAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public int hp;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new HP { Max = this.hp, Current = this.hp });
        }
    }
}

using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace Bogay.VampireSurvivorLike.Component
{
    public class MoveSpeedAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField]
        private float speed;

        public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
        {
            entityManager.AddComponentData(entity, new Move { Value = float3.zero });
            entityManager.AddComponentData(entity, new MoveSpeed { Value = this.speed });
        }
    }
}

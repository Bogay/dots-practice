using UnityEngine;
using Unity.Entities;

namespace Bogay.VampireSurvivorLike.Component
{
    public class PlayerAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
        {
            entityManager.AddComponent<Player>(entity);
        }
    }
}

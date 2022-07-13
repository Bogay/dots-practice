using UnityEngine;
using Unity.Entities;

namespace Bogay.VampireSurvivorLike.Component
{
    public class PlayerAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
        {
            var player = new Player { entity = entity };
            // FIXME: Is there always only one player?
            conversionSystem.SetSingleton(player);
            entityManager.AddComponentData(entity, conversionSystem.GetSingleton<Player>());
        }
    }
}

using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Bogay.VampireSurvivorLike.Component
{
    [DisallowMultipleComponent]
    public class EnemyCounterAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new EnemyCounter { label = GetComponent<Text>() });
        }
    }
}

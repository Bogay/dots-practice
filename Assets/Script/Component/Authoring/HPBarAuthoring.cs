using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Bogay.VampireSurvivorLike.Component
{
    [DisallowMultipleComponent]
    public class HPBarAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public Image hpBar;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity,
             new HPBar
             {
                 bar = this.hpBar,
                 offset = new float3(0, 1, 0)
             });
        }
    }
}
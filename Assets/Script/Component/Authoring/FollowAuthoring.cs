using UnityEngine;
using Unity.Entities;

namespace Bogay.VampireSurvivorLike.Component
{

    [DisallowMultipleComponent]
    public class FollowAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public bool lockX;
        public bool lockY;
        public bool lockZ;
        public GameObject target;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            var follow = new Follow
            {
                lockX = this.lockX,
                lockY = this.lockY,
                lockZ = this.lockZ,
                target = conversionSystem.GetPrimaryEntity(this.target)
            };
            dstManager.AddComponentData(entity, follow);
        }
    }
}

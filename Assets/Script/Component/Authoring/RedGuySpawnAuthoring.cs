using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace Bogay.VampireSurvivorLike.Component
{
    public class RedGuySpawnAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        [SerializeField]
        private GameObject redGuy;

        public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
        {
            var redGuyEntity = conversionSystem.GetPrimaryEntity(this.redGuy);
            Debug.Assert(redGuyEntity != Entity.Null);
            entityManager.AddComponentData(entity, new RedGuySpawn { Value = redGuyEntity });
        }

        public void DeclareReferencedPrefabs(List<GameObject> prefabs)
        {
            prefabs.Add(this.redGuy);
        }
    }
}

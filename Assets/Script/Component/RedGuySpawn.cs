using System;
using Unity.Entities;

namespace Bogay.VampireSurvivorLike.Component
{
    [Serializable]
    public struct RedGuySpawn : IComponentData
    {
        public Entity Value;
    }
}


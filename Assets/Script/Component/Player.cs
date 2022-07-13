using System;
using Unity.Collections;
using Unity.Entities;

namespace Bogay.VampireSurvivorLike.Component
{
    [Serializable]
    public struct Player : IComponentData
    {
        public Entity entity;
    }
}


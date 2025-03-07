﻿using Nino.Core;

namespace TaoTie
{
    [NinoType(false)]
    public abstract partial class ConfigBaseAttackPattern
    {
        [NinoMember(1)]
        public CheckHitLayerType CheckHitLayerType;
        [NinoMember(2)]
        public ConfigHitScene HitScene;
        [NotNull] [NinoMember(3)]
        public ConfigBornType Born;

        public abstract int ResolveHit(Entity applier, ActorAbility ability, ActorModifier modifier,
            Entity target, EntityType[] filter, out HitInfo[] hitInfos);

    }
}
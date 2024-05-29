using Ships.CheckLimits;
using UnityEngine;
using Input = Inputs.Input;
using Ships.Weapons;

namespace Ships.Common
{
    public class shipConfiguration
    {
        public readonly Input Input;
        public readonly CheckLimit CheckLimits;
        public readonly Vector2 Speed;
        public readonly float FireRate;
        public readonly ProjectileId DefaultProjectileId;

        public readonly int Health;
        private CheckLimit checkLimit;

        public readonly Teams Team;

        public shipConfiguration(Input input, CheckLimit checkLimit, Vector2 speed, float fireRate, ProjectileId defaultProjectileId, int health, Teams team)
        {
            Input = input;
            this.checkLimit = checkLimit;
            Speed = speed;
            FireRate = fireRate;
            DefaultProjectileId = defaultProjectileId;
            Team = team;
        }

        public shipConfiguration(Input input, CheckLimit checkLimits, Vector2 speed, float fireRate, ProjectileId defaultProjectileId, int health)
        {
            Input = input;
            CheckLimits = checkLimits;
            Speed = speed;
            FireRate = fireRate;
            DefaultProjectileId = defaultProjectileId;
            Health = health;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Lighting
{
    public class LightSettings
    {
        private const int directionDefaultCount = 32;
        private const int pointDefaultCount = 64;
        private const int spotDefaultCount = 32;

        public const int BufferSize = 12288;

        public const int DirectionLightLimit = 64;

        public const int PointLightLimit = 128;

        public const int SpotLightLimit = 128;

        public int MaxDirectionLights { get; }

        public int MaxPointLights { get; }

        public int MaxSpotLights { get; }

        public LightSettings() : this(directionDefaultCount, pointDefaultCount, spotDefaultCount)
        {
        }


        public LightSettings(int directionLightCount, int pointLightCount, int spotLightCount)
        {
            if (directionLightCount < 1)
                throw new InvalidDataException("count of direction lights cannot be less than 1");

            if (pointLightCount < 1)
                throw new InvalidDataException("count of point lights cannot be less than 1");

            if (spotLightCount < 1)
                throw new InvalidDataException("count of spot lights cannot be less than 1");

            if (directionLightCount > DirectionLightLimit)
                throw new InvalidDataException("count of direction lights cannot be greater than limit");

            if (pointLightCount > PointLightLimit)
                throw new InvalidDataException("count of point lights cannot be greater than limit");

            if (spotLightCount > SpotLightLimit)
                throw new InvalidDataException("count of spot lights cannot be greater than limit");

            MaxDirectionLights = directionLightCount;
            MaxPointLights = pointLightCount;
            MaxSpotLights = spotLightCount;
        }
    }
}

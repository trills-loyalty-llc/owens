// <copyright file="WeatherConditions.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Domain.ThemeParks
{
    /// <summary>
    /// The possible weather conditions for a specified area.
    /// </summary>
    public enum WeatherConditions
    {
        /// <summary>
        /// Clear or sunny conditions.
        /// </summary>
        Clear = 1000,

        /// <summary>
        /// Party cloudy.
        /// </summary>
        PartlyCloudy = 1003,

        /// <summary>
        /// Cloudy.
        /// </summary>
        Cloudy = 1006,

        /// <summary>
        /// Overcast.
        /// </summary>
        Overcast = 1009,

        /// <summary>
        /// Hazy.
        /// </summary>
        Haze = 1012,

        /// <summary>
        /// Haze due to dust.
        /// </summary>
        DustHaze = 1015,

        /// <summary>
        /// Blowing dust.
        /// </summary>
        BlowingDust = 1018,

        /// <summary>
        /// Dust storm with low visibility.
        /// </summary>
        DustStorm = 1021,

        /// <summary>
        /// Sandstorm with low visibility.
        /// </summary>
        Sandstorm = 1024,

        /// <summary>
        /// Very severe sandstorm with zero visibility.
        /// </summary>
        SevereSandStorm = 1027,

        /// <summary>
        /// Misty.
        /// </summary>
        Mist = 1030,

        /// <summary>
        /// Smokey.
        /// </summary>
        Smoke = 1033,

        /// <summary>
        /// Haze due to smoke.
        /// </summary>
        SmokyHaze = 1036,

        /// <summary>
        /// Smoggy.
        /// </summary>
        Smog = 1039,

        /// <summary>
        /// Severe smog.
        /// </summary>
        SevereSmog = 1042,

        /// <summary>
        /// Dust from the saharan desert.
        /// </summary>
        SaharanDust = 1045,

        /// <summary>
        /// Dusty.
        /// </summary>
        Dust = 1048,

        /// <summary>
        /// Small rain forecasted.
        /// </summary>
        PatchyRainPossible = 1063,

        /// <summary>
        /// Small snow forecasted.
        /// </summary>
        PatchySnowPossible = 1066,

        /// <summary>
        /// Small sleet forecasted.
        /// </summary>
        PatchySleetPossible = 1069,

        /// <summary>
        /// Small freezing drizzle forecasted.
        /// </summary>
        PatchyFreezingDrizzlePossible = 1072,

        /// <summary>
        /// Thunder forecasted.
        /// </summary>
        ThunderyOutbreaksPossible = 1087,

        /// <summary>
        /// Moderate snow flurries.
        /// </summary>
        BlowingSnow = 1114,

        /// <summary>
        /// Whiteout blizzard conditions.
        /// </summary>
        Blizzard = 1117,

        /// <summary>
        /// Fog with low visibility.
        /// </summary>
        Fog = 1135,

        /// <summary>
        /// Freezing fog with low visibility.
        /// </summary>
        FreezingFog = 1147,

        /// <summary>
        /// Light sporadic rain.
        /// </summary>
        PatchyLightDrizzle = 1150,

        /// <summary>
        /// Light drizzle.
        /// </summary>
        LightDrizzle = 1153,

        /// <summary>
        /// Drizzle in freezing conditions.
        /// </summary>
        FreezingDrizzle = 1168,

        /// <summary>
        /// Heavy drizzle in freezing conditions.
        /// </summary>
        HeavyFreezingDrizzle = 1171,

        /// <summary>
        /// Sporadic light rain.
        /// </summary>
        PatchyLightRain = 1180,

        /// <summary>
        /// Light rain.
        /// </summary>
        LightRain = 1183,

        /// <summary>
        /// Inconsistent moderate rain.
        /// </summary>
        ModerateRainAtTimes = 1186,

        /// <summary>
        /// Consistent moderate rain.
        /// </summary>
        ModerateRain = 1189,

        /// <summary>
        /// Inconsistent heavy rain.
        /// </summary>
        HeavyRainAtTimes = 1192,

        /// <summary>
        /// Consistent heavy rain.
        /// </summary>
        HeavyRain = 1195,

        /// <summary>
        /// Light rain in freezing conditions.
        /// </summary>
        LightFreezingRain = 1198,

        /// <summary>
        /// Moderate to heavy rain in freezing conditions.
        /// </summary>
        ModerateOrHeavyFreezingRain = 1201,

        /// <summary>
        /// Light sleet.
        /// </summary>
        LightSleet = 1204,

        /// <summary>
        /// Moderate to heavy sleet.
        /// </summary>
        ModerateOrHeavySleet = 1207,

        /// <summary>
        /// Sporadic light snow.
        /// </summary>
        PatchyLightSnow = 1210,

        /// <summary>
        /// Light snow.
        /// </summary>
        LightSnow = 1213,

        /// <summary>
        /// Sporadic moderate snow.
        /// </summary>
        PatchyModerateSnow = 1216,

        /// <summary>
        /// Moderate snow.
        /// </summary>
        ModerateSnow = 1219,

        /// <summary>
        /// Sporadic heavy snow.
        /// </summary>
        PatchyHeavySnow = 1222,

        /// <summary>
        /// Heavy snow.
        /// </summary>
        HeavySnow = 1225,

        /// <summary>
        /// Icy pellets.
        /// </summary>
        IcePellets = 1237,

        /// <summary>
        /// Light rain shower.
        /// </summary>
        LightRainShower = 1240,

        /// <summary>
        /// Moderate to heavy rain showers.
        /// </summary>
        ModerateOrHeavyRainShower = 1243,

        /// <summary>
        /// Very heavy rain shower.
        /// </summary>
        TorrentialRainShower = 1246,

        /// <summary>
        /// Light sleet shower.
        /// </summary>
        LightSleetShowers = 1249,

        /// <summary>
        /// Moderate to heavy sleet showers.
        /// </summary>
        ModerateOrHeavySleetShowers = 1252,

        /// <summary>
        /// Light snow shower.
        /// </summary>
        LightSnowShowers = 1255,

        /// <summary>
        /// Moderate to heavy snow showers.
        /// </summary>
        ModerateOrHeavySnowShowers = 1258,

        /// <summary>
        /// Light showers with ice pellets.
        /// </summary>
        LightShowersOfIcePellets = 1261,

        /// <summary>
        /// Moderate to heavy shower with ice pellets.
        /// </summary>
        ModerateOrHeavyShowersOfIcePellets = 1264,

        /// <summary>
        /// Sporadic light rain with thunder.
        /// </summary>
        PatchyLightRainWithThunder = 1273,

        /// <summary>
        /// Moderate to heavy rain with thunder.
        /// </summary>
        ModerateOrHeavyRainWithThunder = 1276,

        /// <summary>
        /// Sporadic light snow with thunder.
        /// </summary>
        PatchyLightSnowWithThunder = 1279,

        /// <summary>
        /// Moderate to heavy snow with thunder.
        /// </summary>
        ModerateOrHeavySnowWIthThunder = 1282,
    }
}

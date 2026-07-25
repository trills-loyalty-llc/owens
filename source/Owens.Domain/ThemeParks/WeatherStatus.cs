// <copyright file="WeatherStatus.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Owens.Domain.ThemeParks
{
    /// <summary>
    /// Denotes the weather at a particular location and time.
    /// </summary>
    public class WeatherStatus : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStatus"/> class.
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <param name="temperatureFahrenheit"></param>
        /// <param name="feelsLikeFahrenheit"></param>
        /// <param name="heatIndexFahrenheit"></param>
        /// <param name="isDaytime"></param>
        /// <param name="ultraVioletIndex"></param>
        /// <param name="humidity"></param>
        /// <param name="windMph"></param>
        /// <param name="cloudCoverage"></param>
        /// <param name="willItRain"></param>
        /// <param name="chanceOfRain"></param>
        /// <param name="inchesOfPrecipitation"></param>
        /// <param name="conditions"></param>
        /// <param name="conditionsSummary"></param>
        public WeatherStatus(DateTimeOffset timeStamp, int temperatureFahrenheit, int feelsLikeFahrenheit, int heatIndexFahrenheit, bool isDaytime, double ultraVioletIndex, int humidity, double windMph, int cloudCoverage, bool willItRain, int chanceOfRain, double inchesOfPrecipitation, WeatherConditions conditions, string conditionsSummary)
        {
            TimeStamp = timeStamp;
            TemperatureFahrenheit = temperatureFahrenheit;
            FeelsLikeFahrenheit = feelsLikeFahrenheit;
            HeatIndexFahrenheit = heatIndexFahrenheit;
            IsDaytime = isDaytime;
            UltraVioletIndex = ultraVioletIndex;
            Humidity = humidity;
            WindMph = windMph;
            CloudCoverage = cloudCoverage;
            WillItRain = willItRain;
            ChanceOfRain = chanceOfRain;
            InchesOfPrecipitation = inchesOfPrecipitation;
            Conditions = conditions;
            ConditionsSummary = conditionsSummary;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStatus"/> class.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        /// <param name="timeStamp"></param>
        /// <param name="temperatureFahrenheit"></param>
        /// <param name="feelsLikeFahrenheit"></param>
        /// <param name="heatIndexFahrenheit"></param>
        /// <param name="isDaytime"></param>
        /// <param name="ultraVioletIndex"></param>
        /// <param name="humidity"></param>
        /// <param name="windMph"></param>
        /// <param name="cloudCoverage"></param>
        /// <param name="willItRain"></param>
        /// <param name="chanceOfRain"></param>
        /// <param name="inchesOfPrecipitation"></param>
        /// <param name="conditions"></param>
        /// <param name="conditionsSummary"></param>
        public WeatherStatus(Guid id, DateTimeOffset timeStamp, int temperatureFahrenheit, int feelsLikeFahrenheit, int heatIndexFahrenheit, bool isDaytime, double ultraVioletIndex, int humidity, double windMph, int cloudCoverage, bool willItRain, int chanceOfRain, double inchesOfPrecipitation, WeatherConditions conditions, string conditionsSummary)
            : base(id)
        {
            TimeStamp = timeStamp;
            TemperatureFahrenheit = temperatureFahrenheit;
            FeelsLikeFahrenheit = feelsLikeFahrenheit;
            HeatIndexFahrenheit = heatIndexFahrenheit;
            IsDaytime = isDaytime;
            UltraVioletIndex = ultraVioletIndex;
            Humidity = humidity;
            WindMph = windMph;
            CloudCoverage = cloudCoverage;
            WillItRain = willItRain;
            ChanceOfRain = chanceOfRain;
            InchesOfPrecipitation = inchesOfPrecipitation;
            Conditions = conditions;
            ConditionsSummary = conditionsSummary;
        }

        /// <summary>
        /// Gets the time stamp for the weather status. Always in UTC.
        /// </summary>
        public DateTimeOffset TimeStamp { get; }

        /// <summary>
        /// Gets the current temperature in Fahrenheit.
        /// </summary>
        public int TemperatureFahrenheit { get; }

        /// <summary>
        /// Gets the current human adjusted temperature in Fahrenheit.
        /// </summary>
        public int FeelsLikeFahrenheit { get; }

        /// <summary>
        /// Gets the current humidity adjusted heat index in Fahrenheit.
        /// </summary>
        public int HeatIndexFahrenheit { get; }

        /// <summary>
        /// Gets a value indicating whether the sun is currently visible.
        /// </summary>
        public bool IsDaytime { get; }

        /// <summary>
        /// Gets the current sun UV intensity.
        /// </summary>
        public double UltraVioletIndex { get; }

        /// <summary>
        /// Gets the current humidity level.
        /// </summary>
        public int Humidity { get; }

        /// <summary>
        /// Gets the speed of the wind.
        /// </summary>
        public double WindMph { get; }

        /// <summary>
        /// Gets the percentage of cloud coverage.
        /// </summary>
        public int CloudCoverage { get; }

        /// <summary>
        /// Gets a value indicating whether it gets a value indicating if rain is guaranteed.
        /// </summary>
        public bool WillItRain { get; }

        /// <summary>
        /// Gets the percentage change of rain.
        /// </summary>
        public int ChanceOfRain { get; }

        /// <summary>
        /// Gets the amount of recent precipitation in inches.
        /// </summary>
        public double InchesOfPrecipitation { get; }

        /// <summary>
        /// Gets the current conditions code.
        /// </summary>
        public WeatherConditions Conditions { get; }

        /// <summary>
        /// Gets a text summary of current conditions.
        /// </summary>
        public string ConditionsSummary { get; }
    }
}

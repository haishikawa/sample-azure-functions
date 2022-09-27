using System;

namespace SampleAzureFunctions
{
    public static class SleepDurationProviders
    {
        private static readonly Random _random = new Random();

        public static Func<int, TimeSpan> Simple(int seconds)
        {
            return retryAttempt => TimeSpan.FromSeconds(retryAttempt * seconds);
        }

        public static Func<int, TimeSpan> Fixed(int seconds)
        {
            return _ => TimeSpan.FromSeconds(seconds);
        }

        public static Func<int, TimeSpan> ExponentialBackoff(int maximumBackoff = 64)
        {
            return retryAttempt => TimeSpan.FromSeconds(Math.Min(Math.Pow(2, retryAttempt - 1), maximumBackoff) + _random.NextDouble());
        }
    }
}

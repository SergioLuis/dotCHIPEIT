using System.Collections.Generic;

namespace Chipeit.Lib
{
    public class LibLocalization
    {
        static LibLocalization _Instance;

        public enum Keys
        {
            ChronometerNotRunningException,
            InvalidMsPerStepArgumentException,
            InvalidRegistersMemorySize,
            InvalidGraphicMemorySize
        }

        static class Values
        {
            internal const string ChronometerNotRunningException =
                "The IChronometer cannot be updated if it is not running.";
            internal const string InvalidMsPerStepArgumentException =
                "The IClockDivider.MsPerStep must be greater than zero. Value used: '{0}'.";
            internal const string InvalidRegistersMemorySize =
                "The IMemory<byte> must be of length {0}. It was {1} instead.";
            internal const string InvalidGraphicMemorySize =
                "A Graphic Memory of size {0}x{1} needs a base memory of size at least {2}. Found {3} instead.";
        }

        public static void Initialize()
        {
            lock (mInitializationLock)
            {
                if (_Instance != null)
                    return;

                _Instance = new LibLocalization();
                InitializeDictionary(_Instance.mStrings);
            }
        }

        public static LibLocalization Get()
        {
            lock (mInitializationLock)
            {
                if (_Instance == null)
                    return new LibLocalization();

                return _Instance; 
            }
        }

        public string Localize(Keys key)
        {
            return mStrings.TryGetValue(key, out string result)
                ? result
                : $"Unlocalized key ${key}!";
        }

        public string Localize(Keys key, params object[] args)
        {
            return mStrings.TryGetValue(key, out string result)
                ? string.Format(result, args)
                : $"Unlocalized key ${key}, params: {string.Join(", ", args)}";
        }

        private LibLocalization()
        {
            mStrings = new Dictionary<Keys, string>();
        }

        static void InitializeDictionary(Dictionary<Keys, string> dict)
        {
            dict.Add(
                Keys.ChronometerNotRunningException,
                Values.ChronometerNotRunningException);
            dict.Add(
                Keys.InvalidMsPerStepArgumentException,
                Values.InvalidMsPerStepArgumentException);
            dict.Add(
                Keys.InvalidRegistersMemorySize,
                Values.InvalidRegistersMemorySize);
            dict.Add(
                Keys.InvalidGraphicMemorySize,
                Values.InvalidGraphicMemorySize);
        }

        static readonly object mInitializationLock = new object();

        readonly Dictionary<Keys, string> mStrings;
    }
}

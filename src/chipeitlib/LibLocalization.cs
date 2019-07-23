using System;
using System.Collections.Generic;

namespace Chipeit.Lib
{
    public class LibLocalization
    {
        static LibLocalization _Instance;

        public enum Keys
        {
            ChronometerNotRunningException
        }

        static class Values
        {
            internal const string ChronometerNotRunningException =
                "The IChronometer cannot be updated if it is not running.";
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
        }

        static readonly object mInitializationLock;

        readonly Dictionary<Keys, string> mStrings;
    }
}

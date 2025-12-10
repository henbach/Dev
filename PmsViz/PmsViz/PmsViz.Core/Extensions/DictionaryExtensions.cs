namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        public static string? GetValueAsDateString<TKey, TValue>(this Dictionary<TKey, TValue> data, string key)
        {
            object? rc = GetValue(data, key);
            if (rc == null)
                return null;

            DateTime value;
            if (DateTime.TryParse(rc.ToString(), out value))
            {
                return value.ToString("yyyy.MM.dd HH:mm:ss");
            }

            return null;
        }

        public static int? GetValueAsInt<TKey, TValue>(this Dictionary<TKey, TValue> data, string key)
        {
            object? rc = GetValue(data, key);
            if (rc == null)
                return null;

            int value;
            if (int.TryParse(rc.ToString(), out value))
                return value;

            return null;
        }
        public static string? GetValueAsString<TKey, TValue>(this Dictionary<TKey, TValue> dict, string key)
        {
            object? rc = GetValue(dict, key);
            if (rc == null) return string.Empty;
            return rc.ToString();
        }
        public static object? GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, string stringKey)
        {
            TValue? rc;
            if (dict == null)
                return null;

            TKey key = default;
            bool found = false;
            foreach (var sk in dict.Keys)
            {
                if ((sk as string).ToLower() == stringKey.ToLower())
                {
                    key = (TKey)sk;
                    found = true;
                }
            }

            return found ? dict[key] : null;
        }

        public static TValue GetOrDefault<TKey, TValue>(
        this Dictionary<TKey, TValue> dict,
        TKey key,
        TValue defaultValue = default)
        {
            if (dict == null)
                throw new ArgumentNullException(nameof(dict));

            return dict.TryGetValue(key, out var value) ? value : defaultValue;
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    public static class StringComparator
    {
        public static bool Compare(string expected, string actual)
        {
            if (string.IsNullOrEmpty(expected)) return true;

            expected = expected.ToLowerInvariant();
            actual = actual.ToLowerInvariant();

            if (StringsAreValidJson(expected, actual))
            {
                JObject expectedJObject = JsonConvert.DeserializeObject<JObject>(expected);
                JObject actualJObject = JsonConvert.DeserializeObject<JObject>(actual);

                foreach (KeyValuePair<string, JToken> expectedProperty in expectedJObject)
                {
                    JProperty actualProperty = actualJObject.Property(expectedProperty.Key);

                    if (!JToken.DeepEquals(expectedProperty.Value, actualProperty.Value))
                    {
                        if (Compare(expectedProperty.Value.ToString(), actualProperty.Value.ToString())) return true;
                        //Debug.WriteLine($"Value don't match for key {expectedProperty.Key}.");
                        //Debug.WriteLine($"Expected { expectedProperty.Value} but got {actualProperty.Value}");
                        return false;
                    }
                }

                return true;
            }

            if (!actual.Equals(expected))
            {
                return false;
            }

            return true;
        }

        private static bool StringsAreValidJson(string expected, string actual)
        {
            try
            {
                JObject.Parse(expected);
                JObject.Parse(actual);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}

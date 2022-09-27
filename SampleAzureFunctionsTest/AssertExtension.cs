using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace SampleAzureFunctionsTest
{
    public static class AssertExtension
    {
        /// <summary>
        /// Equalsメソッドが実装されていないClassをテスト。
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="_"></param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void AreEqualClass<TClass>(this Assert _, TClass expected, TClass actual) where TClass : class
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            var jExpected = JToken.Parse(JsonSerializer.Serialize(expected));
            var jActual = JToken.Parse(JsonSerializer.Serialize(actual));
            Assert.IsTrue(JToken.DeepEquals(jExpected, jActual), $"\nexpected : {jExpected}\nactual : {jActual}");
        }

        /// <summary>
        /// Equalsメソッドが実装されていないClassをテスト。
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="this"></param>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void AreEqualClass<TClass>(this Assert @this, IEnumerable<TClass> expected, IEnumerable<TClass> actual) where TClass : class
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());
            for (int i = 0; i < expected.Count(); i++)
            {
                @this.AreEqualClass(expected.ElementAt(i), actual.ElementAt(i));
            }
        }
    }
}

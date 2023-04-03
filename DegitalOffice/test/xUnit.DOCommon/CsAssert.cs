using System.Text;

namespace xUnit.DO.CommonTest;

public static class CsAssert
{
    public static void DictionaryEquals<TKey>(IDictionary<TKey, object> expected, IDictionary<TKey, object> actual, Func<object, object, bool> comparison)
    {
        if (expected == null && actual == null)
            return;
        if (expected == null && actual != null || expected != null && actual == null)
            Assert.Same(expected, actual);

        var messageBuilder = new StringBuilder();
        foreach (var key in expected.Keys)
        {
            if (!actual.ContainsKey(key))
                messageBuilder.AppendLine($"Key [{key}] expected value: [{expected[key]}], actual value: null");

            else if (!comparison(expected[key], actual[key]))
                messageBuilder.AppendLine($"Key [{key}] expected value: [{expected[key]}], actual value: [{actual[key]}]");
        }

        var message = messageBuilder.ToString();
        Assert.True(string.IsNullOrEmpty(message), message);
    }

    public static void ObjectEqual<T>(T expected, T actual, Func<object, object, bool> comparison) where T : class
    {
        if (expected == null && actual == null)
            return;

        var allProperties = typeof(T).GetProperties().Where(x => x.CanRead && x.CanWrite);
        var messageBuilder = new StringBuilder();
        foreach (var pi in allProperties)
        {
            var value1 = pi.GetValue(expected, null);
            var value2 = pi.GetValue(actual, null);

            if (value1 == null && value2 == null)
                continue;

            if (pi.PropertyType.IsGenericType)
            {
                ObjectEqual(value1, value2, comparison);
            }

            if (!comparison(value1, value2))
                messageBuilder.AppendLine($"Key [{pi}] expected value: [{value1}], actual value: [{value2}]");
        }
        var message = messageBuilder.ToString();
        Assert.True(string.IsNullOrEmpty(message), message);
    }

}

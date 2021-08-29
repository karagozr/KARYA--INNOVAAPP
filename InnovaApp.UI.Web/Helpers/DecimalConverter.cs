using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace InnovaApp.UI.Web.Helpers
{
    
    /// <inheritdoc cref="JsonConverter"/>
    /// <summary>
    /// Converts an object to and from JSON.
    /// </summary>
    /// <seealso cref="JsonConverter"/>
    public class DecimalConverter : JsonConverter
    {
        /// <summary>
        /// Gets a new instance of the <see cref="DecimalConverter"/>.
        /// </summary>
        public static readonly DecimalConverter Instance = new DecimalConverter();

        /// <inheritdoc cref="JsonConverter"/>
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        ///     <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="JsonConverter"/>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal) || objectType == typeof(decimal?);
        }

        /// <inheritdoc cref="JsonConverter"/>
        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        /// <seealso cref="JsonConverter"/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!(reader.Value is string value))
            {
                if (objectType == typeof(decimal?))
                {
                    return null;
                }

                return default(decimal);
            }

            // ReSharper disable once StyleCop.SA1126
            if (decimal.TryParse(value, out var result))
            {
                // ReSharper disable once StyleCop.SA1126
                return result;
            }

            if (objectType == typeof(decimal?))
            {
                return null;
            }

            return default(decimal);
        }

        /// <inheritdoc cref="JsonConverter"/>
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <seealso cref="JsonConverter"/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var d = default(decimal?);

            if (value != null)
            {
                d = value as decimal?;
                if (d.HasValue)
                {
                    d = new decimal(decimal.ToDouble(d.Value));
                }
            }

            JToken.FromObject(d ?? 0).WriteTo(writer);
        }
    }
}

using Flub.Utils.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flub.TelegramBot.Authentication.Tests
{
    [ExcludeFromCodeCoverage]
    public class AuthenticationDataTests
    {
        static readonly DateTime? dateTime = new(2021, 10, 07, 11, 22, 33);
        static readonly string hash = Guid.NewGuid().ToString();
        static readonly string value = Guid.NewGuid().ToString();
        static readonly string valueRenamed = Guid.NewGuid().ToString();
        static readonly int valueNumber = 42;
        static readonly string objectValue = Guid.NewGuid().ToString();
        static readonly string ignored = Guid.NewGuid().ToString();
        static readonly string ignoredNever = Guid.NewGuid().ToString();
        static readonly ExampleAuthenticationData data = new();
        static readonly string authenticationFields =
              $"AuthenticationDate=2021-10-07T11:22:33\n"
            + $"BoolValueFalse=false\n"
            + $"BoolValueTrue=true\n"
            + $"Enum=Value\n"
            + $"IgnoredNever={ignoredNever}\n"
            + $"IgnoredNeverNull=null\n"
            + $"JsonEnum=Value\n"
            + $"JsonEnumRenamed=renamed\n"
            + $"List=[1,null]\n"
            + $"Object={{\"Value\":\"{objectValue}\"}}\n"
            + $"renamed={valueRenamed}\n"
            + $"Value={value}\n"
            + $"ValueNumber={valueNumber}";
        static readonly string authenticationFieldsAll =
              $"AuthenticationDate=2021-10-07T11:22:33\n"
            + $"BoolValueFalse=false\n"
            + $"BoolValueTrue=true\n"
            + $"Enum=Value\n"
            + $"IgnoredNever={ignoredNever}\n"
            + $"IgnoredNeverNull=null\n"
            + $"JsonEnum=Value\n"
            + $"JsonEnumRenamed=renamed\n"
            + $"List=[1,null]\n"
            + $"Object={{\"Value\":\"{objectValue}\",\"ValueNull\":null}}\n"
            + $"renamed={valueRenamed}\n"
            + $"Value={value}\n"
            + $"ValueNull=null\n"
            + $"ValueNumber={valueNumber}";

        [JsonConverter(typeof(JsonStringEnumConverter))]
        enum TestEnum : int
        {
            None = 0,
            Value = 1
        }

        [JsonConverter(typeof(JsonFieldEnumConverter<TestJsonEnum>))]
        enum TestJsonEnum : int
        {
            [JsonIgnore]
            None = 0,
            Value = 1,
            [JsonFieldValue("renamed")]
            Renamed = 2
        }

        class ExampleClass
        {
            public string Value { get; } = objectValue;
            public string ValueNull { get; } = null;
        }

        class ExampleAuthenticationData : AuthenticationData
        {
            [AuthenticationField]
            public string Value { get; } = value;
            [AuthenticationField]
            [JsonPropertyName("renamed")]
            public string ValueRenamed { get; } = valueRenamed;
            [AuthenticationField]
            public int ValueNumber { get; } = valueNumber;
            [AuthenticationField]
            public string ValueNull { get; } = null;
            [AuthenticationField]
            public bool? BoolValueTrue { get; } = true;
            [AuthenticationField]
            public bool? BoolValueFalse { get; } = false;
            [AuthenticationField]
            public TestEnum? Enum { get; } = TestEnum.Value;
            [AuthenticationField]
            public TestJsonEnum? JsonEnum { get; } = TestJsonEnum.Value;
            [AuthenticationField]
            public TestJsonEnum? JsonEnumRenamed { get; } = TestJsonEnum.Renamed;
            [AuthenticationField]
            public ExampleClass Object { get; } = new();
            [AuthenticationField]
            public IEnumerable<int?> List { get; } = new int?[] { 1, null };
            [AuthenticationField]
            [JsonIgnore]
            public string Ignored { get; } = ignored;
            [AuthenticationField]
            [JsonIgnore]
            public string IgnoredNull { get; } = null;
            [AuthenticationField]
            [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
            public string IgnoredNever { get; } = ignoredNever;
            [AuthenticationField]
            [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
            public string IgnoredNeverNull { get; } = null;
            public JsonSerializerOptions Options { get => jsonSerializerOptions; set => jsonSerializerOptions = value; }
            [AuthenticationField]
            public override DateTime? AuthenticationDate { get; set; } = dateTime;
            public override string AuthenticationHash { get; set; } = hash;
        }

        [Test]
        public void AuthenticationFieldsTest()
        {
            Assert.AreEqual(authenticationFields, data.AuthenticationFields);

            data.Options = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.Never };
            Assert.AreEqual(authenticationFieldsAll, data.AuthenticationFields);
        }
    }
}

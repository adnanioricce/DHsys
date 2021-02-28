using System;
using Moq;

namespace Tests.Lib
{
    public static class CustomMockFactory
    {
        public static T BuildMock<T>(Action<Mock<T>> mockTransform) where T : class
        {
            var mock = new Mock<T>();
            mockTransform(mock);
            return mock.Object;
        }
    }
}
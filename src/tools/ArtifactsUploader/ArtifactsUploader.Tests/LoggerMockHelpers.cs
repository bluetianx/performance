﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Moq;
using Serilog;
using Serilog.Events;

namespace ArtifactsUploader.Tests
{
    public static class LoggerMockHelpers
    {
        public static Mock<ILogger> CreateLoggerMock()
        {
            var loggerMock = new Mock<ILogger>();

            loggerMock.Setup(logger => logger.Error(It.IsAny<string>())).Verifiable();
            loggerMock.Setup(logger => logger.Write(It.IsAny<LogEventLevel>(), It.IsAny<string>())).Verifiable();

            return loggerMock;
        }

        public static void AssertNothingWasWrittenToLog(Mock<ILogger> loggerMock)
            => loggerMock.Verify(log => log.Write(It.IsAny<LogEventLevel>(), It.IsAny<string>()), Times.Never);

        public static void AssertAtLeastOneErrorWasWrittenToLog(Mock<ILogger> loggerMock)
            => loggerMock.Verify(log => log.Error(It.IsAny<string>()), Times.AtLeastOnce);
    }
}
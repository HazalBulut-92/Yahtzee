using Serilog;
using Serilog.Sinks.TestCorrelator;

namespace YahtzeeGame.Tests
{
    public class LoggerTests
    {
        // Test logging to capture output from Serilog
        [Fact]
        public void Should_Log_Message_Correctly()
        {
            // Arrange: Configure Serilog to use TestCorrelator sink
            using (TestCorrelator.CreateContext())
            {
                var log = new LoggerConfiguration()
                    .WriteTo.TestCorrelator()  // Use TestCorrelator to capture log messages
                    .CreateLogger();

                // Act: Log an informational message
                log.Information("This is a test log message");

                // Assert: Check if the message appears in the captured log
                var logContents = TestCorrelator.GetLogEventsFromCurrentContext();
                Assert.Single(logContents);
                Assert.Contains("This is a test log message", logContents[0].MessageTemplate.Text);
            }
        }

        // Test logging with rolling behavior and capturing it via TestCorrelator
        [Fact]
        public void Should_Log_With_Rolling_Interval()
        {
            // Arrange: Create a logger with TestCorrelator and a rolling interval setup
            using (TestCorrelator.CreateContext())
            {
                var log = new LoggerConfiguration()
                    .WriteTo.TestCorrelator()  // Use TestCorrelator for capturing logs
                    .WriteTo.File("logs/yahtzee-.log", rollingInterval: RollingInterval.Day) // Logging with rolling
                    .CreateLogger();

                // Act: Log a message
                log.Information("Rolling log test");

                // Assert: Check if the message appears in the captured logs
                var logContents = TestCorrelator.GetLogEventsFromCurrentContext();
                Assert.Contains("Rolling log test", logContents[0].MessageTemplate.Text);
            }
        }

        // Test for multiple log entries
        [Fact]
        public void Should_Log_Multiple_Entries()
        {
            // Arrange: Create a logger with TestCorrelator
            using (TestCorrelator.CreateContext())
            {
                var log = new LoggerConfiguration()
                    .WriteTo.TestCorrelator()  // Use TestCorrelator to capture logs
                    .CreateLogger();

                // Act: Log multiple messages
                log.Information("First log entry");
                log.Information("Second log entry");

                // Assert: Check that both messages are captured
                var logContents = TestCorrelator.GetLogEventsFromCurrentContext();
                Assert.Equal(2, logContents.Count);
                Assert.Contains("First log entry", logContents[0].MessageTemplate.Text);
                Assert.Contains("Second log entry", logContents[1].MessageTemplate.Text);
            }
        }
    }
}
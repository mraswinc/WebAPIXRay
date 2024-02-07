This is a sample that demostrates the integration of ASP.NET Core Web API with AWS Otel or AWS Distro for OpenTelemetry (https://aws.amazon.com/otel/)
To get started:
  a. Download and install the Otel collector - https://aws-otel.github.io/docs/getting-started/collector
  --You doesn't need to install Golang if your supported OS is listed. For Windows with EC2, follow this guide - https://github.com/aws-observability/aws-otel-collector/blob/main/docs/developers/windows-other-demo.md
  --bear in mind the installer is a silent installer, hence there might not be any gui. 
  --you can juse download and omit wget command if you're downloading using browser

  b. Setup Global tracer - The sample has already setup the global tracer in Program.cs with comments about each functionalities
  --

  c. Deploy your code in your project and you should see the XRay traces being displayed

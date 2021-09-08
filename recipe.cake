#load nuget:?package=Cake.Recipe&version=2.2.1

var standardNotificationMessage = "Version {0} of {1} has just been released, it will be available here https://www.nuget.org/packages/{1}, once package indexing is complete.";

Environment.SetVariableNames();

BuildParameters.SetParameters(
  context: Context,
  buildSystem: BuildSystem,
  sourceDirectoryPath: "./src",
  title: "Spectre.Console.Registrars.SimpleInjector",
  masterBranchName: "main",
  repositoryOwner: "nils-org",
  twitterMessage: standardNotificationMessage,
  preferredBuildProviderType: BuildProviderType.GitHubActions,
  shouldRunDotNetCorePack: true,
  shouldUseDeterministicBuilds: true);

BuildParameters.PrintParameters(Context);

// workaround for https://github.com/cake-contrib/Cake.Recipe/issues/862
ToolSettings.SetToolPreprocessorDirectives(
    reSharperTools: "#tool nuget:?package=JetBrains.ReSharper.CommandLineTools&version=2021.2.0");

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();

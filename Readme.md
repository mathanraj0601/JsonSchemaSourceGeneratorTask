# The Repository contains the qualification task for Json Schema GSOC 2024

Welcome to the Json Schema GSOC 2024 Qualification Task repository! This project addresses the compilation issues in the CorvusQualification project by updating the ExistingLibrary. Additionally, it involves creating a NuGet package for ExistingLibrary, enabling users to utilize ServiceProvider and the generated attribute in the CorvusQualification project and UserCode project.

## Task Accomplishments

- ExistingLibrary is now capable of generating the missing attribute.
- The CorvusQualification project successfully references the ExistingLibrary as a project reference.
- A NuGet package for ExistingLibrary has been generated and is being referenced by the UserCode project.

## Existing library usage in other project

### Project Reference

Add Project Reference:

1. dotnet restore : to get all dependencies

1. Open the project file of the target project (e.g., CorvusQualification).

1. Include a project reference to ExistingLibrary with the following entry:

```xml
<ProjectReference Include="..\JsonSchema.GSoC2024.ExistingLibrary\JsonSchema.GSoC2024.ExistingLibrary.csproj" OutputItemType="Analyzer" />

```

4.  build and run the project (optional) use ctrl+click on generatedAttribute to navigate to the generated code

### Package reference

- Follow this [link]()

### Learning and References

- Refer to the learning.md document attached, where I've documented my learning and references used to complete this task, including the creation of the source code generator.

> [Task link ]()
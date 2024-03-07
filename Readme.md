# Json Schema GSOC 2024 Qualification Task Solution

Welcome to the JSON Schema GSOC 2024 Qualification Task solution repository! This project addresses compilation issues in the CorvusQualification project by updating the ExistingLibrary. The main goals include enhancing the ExistingLibrary to generate a missing attribute, enabling smooth referencing in the CorvusQualification project, and creating a NuGet package for broader usability.

## Task Accomplishments

- ExistingLibrary is now capable of generating the missing attribute.
- The CorvusQualification project successfully references the ExistingLibrary as a project reference.
- A NuGet package for ExistingLibrary has been generated and is being referenced by the UserCode project.

## Existing library usage in another project

### Project Reference

Add Project Reference:

1. dotnet restore: to get all dependencies

1. Open the project file of the target project (e.g., CorvusQualification).

1. Include a project reference to ExistingLibrary with the following entry:

```xml
<ProjectReference Include="..\JsonSchema.GSoC2024.ExistingLibrary\JsonSchema.GSoC2024.ExistingLibrary.csproj"
                  OutputItemType="Analyzer" />

```

4.  build and run the project (optional) use ctrl+click on generatedAttribute to navigate to the generated code

### Package reference

- Follow this [link](JsonSchema.GSoC2024.CorvusQualification/JsonSchema.GSoC2024.ExistingLibrary/Readme.md)

### Learning and References

- Refer to the [learning.md](Learning.md) document attached, where I've documented my learning and references used to complete this task, including the creation of the source code generator.

> [Task link ](https://github.com/json-schema-org/community/issues/614)

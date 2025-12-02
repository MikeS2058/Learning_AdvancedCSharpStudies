# Project Guidelines for Junie

Last updated: [DATE]

## 1) Project overview

This repository contains a C#/.NET project with source code and tests.

- Target framework: `net[VERSION]`
- C# language version: `[VERSION]`
- Test framework: [Test framework name, e.g., xUnit, NUnit, MSTest]

[Brief description of what the project does]

## 2) Repository layout

- `[ProjectName]/` — Main project (application, library, web app, etc.)
  - Example files: `Program.cs`, `[FeatureName].cs`
- `[TestProjectName]/` — Unit tests for the main project
  - Uses [test framework and assertion libraries]
- `README.md` — General documentation with build/test instructions
- `docs/` — Additional documentation and architectural decisions

Note: Paths use Windows separators (this repo typically uses Windows with PowerShell).

## 3) When Junie should run tests

- Always run tests when you change any production or test code.
- For documentation-only updates (comments/README/guidelines), do not run tests unless explicitly asked.

## 4) How Junie runs tests

Preferred (tool-based):
- Use the dedicated test tool to run the entire solution:
  - `run_test path="fullSolution"`

Alternative (CLI; useful for reproductions in README):
- PowerShell from repo root:
  - `dotnet test [SolutionName].sln`
  - Or a single project: `dotnet test .\[TestProjectName]\[TestProjectName].csproj`

The test suite output will include pass/fail counts. Tests implicitly build the solution.

## 5) Build instructions

- Building is normally handled by `dotnet test`.
- To build explicitly (PowerShell from repo root):
  - `dotnet restore`
  - `dotnet build [SolutionName].sln -c Debug`
- To run the app (if applicable):
  - `dotnet run --project .\[ProjectName]\[ProjectName].csproj -c Debug`

## 6) Code style and conventions

- Follow existing file/project style (indentation, braces, XML doc comments).
- C# naming conventions: PascalCase for types/methods, camelCase for locals/parameters.
- Prefer expression clarity over micro-optimizations unless explicitly demonstrated.
- Tests:
  - Use test framework attributes (e.g., `[Fact]`/`[Theory]` for xUnit, `[Test]` for NUnit).
  - Use parameterized tests where appropriate (e.g., `[InlineData]` for xUnit, `[TestCase]` for NUnit).
  - Use assertion library syntax (e.g., FluentAssertions: `result.Should().Be(expected);`).
  - Name tests using pattern: `MethodName_Scenario_ExpectedResult`.
  - Validate exceptions appropriately and check exception properties when relevant.

## 7) Dependencies and tooling

- Test packages defined in `[TestProjectName].csproj` include:
  - Test framework packages
  - Test runner packages
  - Assertion libraries
  - Code coverage tools (if enabled)
- Use Windows PowerShell syntax and backslashes in paths.

## 8) What Junie should modify

- Only modify code/tests/docs relevant to the current issue.
- Keep changes minimal and focused; avoid broad refactors unless requested.
- Add/update tests for behavioral changes.

## 9) Submission checklist for Junie

- If code changed: run the full test suite and ensure all tests pass.
- If only docs/comments changed: tests are optional unless requested.
- Summarize what changed and why; include any noteworthy decisions or edge cases handled.

## 10) Non-standard notes (important)

- The solution targets specific .NET and C# versions; ensure your changes compile under these settings.
- Use Windows-style paths in examples and scripts.
- Review project-specific `.editorconfig` and `.csproj` settings for additional constraints.
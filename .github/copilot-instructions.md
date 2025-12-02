# GitHub Copilot Instructions for Learning_AdvancedCSharpStudies

**Purpose**: Guide AI assistants working on this C# / .NET project.

---

## Repository Overview

**Project**: Learning_AdvancedCSharpStudies — Advanced C# language features and patterns study project

**Key Components**:
- `Learning_AdvancedCSharpStudies/` — main project (console app)
- `docs/` — project documentation, summaries, and architectural decisions
- `.github/` — GitHub-specific files including this copilot-instructions.md
- `AITransfer/` — AI configuration templates for reuse in other projects

**Tech Stack**:
- .NET SDK: 10.0.100 (see `global.json`)
- Target Framework: `net10.0`
- Language Version: C# 14
- Nullable Reference Types: Enabled
- XML Documentation: Not yet enabled

---

## Core Principles

### 1. Modern C# Patterns (Mandatory)
- **Extension methods over static utilities** — fluent, discoverable APIs
- **File-scoped namespaces** — `namespace MyCSharpStudies;` (not block style)
- **One type per file** — enforced at warning level
- **Primary constructors** — use where applicable (C# 12+)
- **No `this.` qualifiers** — enforced at warning level for fields, properties, methods, events
- **Predefined types** — use `int`, `string`, not `Int32`, `String`

### 2. Documentation Requirements
- **All public APIs** should have XML documentation (`/// <summary>`)
- Include `<param>` and `<returns>` tags for methods
- Use `<see langword="..."/>` for keywords (`true`, `false`, `null`)
- Use `<paramref name="..."/>` when referencing parameters
- Documentation generates for IntelliSense support

### 3. Testing Philosophy
- **Comprehensive coverage** — include edge cases (min/max values, zero, negative, null)
- **Theory-based tests** — use `[Theory]` with `[InlineData]` for parameterized tests (xUnit)
- **Readable assertions** — use assertion libraries like FluentAssertions when available
- **Descriptive method names** — clear intent (e.g., `MethodName_Scenario_ExpectedResult`)

### 4. Documentation Organization
- **All summary and architectural documentation** goes in `docs/` folder
- **Summary files**: `REFACTORING_SUMMARY.md`, `IMPLEMENTATION_SUMMARY.md`, etc.
- **Technical decisions**, migration guides, and change logs belong in `docs/`
- **README.md** stays in root for GitHub visibility
- **This file** (`.github/copilot-instructions.md`) provides AI guidance

---

## Code Style Rules (from .editorconfig)

**Enforced at Warning Level**:
- ❌ No `this.` qualifiers on members
- ❌ One type per file only
- ❌ Simplify member access (remove redundant namespaces)

**Preferred (Suggestion Level)**:
- ✅ File-scoped namespaces: `namespace MyCSharpStudies;`
- ✅ Simple using statements: `using var stream = ...`
- ✅ Explicit types over `var` (unless type is obvious)
- ✅ Primary constructors where applicable

**Formatting**:
- Opening braces on new lines (Allman style)
- Preserve single-line blocks
- No single-line statements (always use braces)

---

## Build & Test Commands (PowerShell)

**Critical**: This repository uses PowerShell. Never use Bash operators like `&&`.

### Correct PowerShell Syntax
```powershell
# Sequential execution (semicolon)
dotnet restore; dotnet build Learning_AdvancedCSharpStudies.sln -c Debug

# Conditional execution (if statement)
if (dotnet build Learning_AdvancedCSharpStudies.sln -c Release) { dotnet test Learning_AdvancedCSharpStudies.sln -c Release }
```

### Standard Workflows

**Restore & Build**:
```powershell
dotnet restore; dotnet build Learning_AdvancedCSharpStudies.sln -c Debug
```

**Build & Run** (for executable projects):
```powershell
dotnet build Learning_AdvancedCSharpStudies.sln -c Debug; dotnet run --project .\Learning_AdvancedCSharpStudies\Learning_AdvancedCSharpStudies.csproj -c Debug
```

**Run All Tests**:
```powershell
dotnet test Learning_AdvancedCSharpStudies.sln
```

**Run Specific Test Class**:
```powershell
dotnet test --filter FullyQualifiedName~[TestClassName]
```

**Clean Artifacts**:
```powershell
Get-ChildItem -Recurse -Directory -Include bin,obj | Remove-Item -Recurse -Force
```

---

## Project Structure & Organization

### Source Layout
```
Learning_AdvancedCSharpStudies/
├── Program.cs                         # Entry point
├── GlobalUsings.cs                    # Global using directives (if needed)
├── [FeatureName].cs                   # Feature implementation files
└── Learning_AdvancedCSharpStudies.csproj
```

### Test Layout
```
Learning_AdvancedCSharpStudies.Tests/ (to be added)
├── GlobalUsings.cs
├── [Feature]Tests.cs
└── Learning_AdvancedCSharpStudies.Tests.csproj
```

### Documentation Layout
```
docs/
├── REFACTORING_SUMMARY.md      # Architectural changes and refactoring history
├── IMPLEMENTATION_SUMMARY.md   # Implementation details and decisions
└── [other summary files]       # Feature-specific summaries and technical documentation
```

**Global Usings** (common namespaces):
- `System`
- `System.Collections.Generic`
- `System.Linq`
- Test projects may also include test framework namespaces (e.g., `Xunit`, `FluentAssertions`)

---

## API Design Patterns

### Extension Methods (Preferred)

Extension methods provide fluent, discoverable APIs:
```csharp
/// <summary>
/// [Description of what the extension method does]
/// </summary>
public static [ReturnType] [MethodName](this [Type] parameter)
{
    // Implementation
}

// Usage: allows method chaining and discoverability
var result = instance.MethodName();
```

### Static Utility Classes

Use sparingly; prefer extension methods for better discoverability:
```csharp
public static class [UtilityClassName]
{
    public static [ReturnType] [MethodName]([Type] parameter)
    {
        // Implementation
    }
}
```

---

## File Naming & Organization

- **One type per file** — `[TypeName].cs` contains only the `[TypeName]` class/interface/record
- **Match type name** — file name matches the primary type name exactly
- **Tests mirror source** — `[TypeName].cs` → `[TypeName]Tests.cs` or `[TypeName]Test.cs`
- **Namespace = project name** — all types use `namespace [ProjectName];`
- **Documentation in docs/** — all summary, architectural, and technical docs go in `docs/` folder

---

## When Making Changes

### Before Editing
1. Check existing patterns in the codebase
2. Review `docs/` folder for recent architectural decisions
3. Ensure changes align with established coding patterns

### After Editing
1. **Build**: `dotnet build Learning_AdvancedCSharpStudies.sln -c Release`
2. **Test**: `dotnet test Learning_AdvancedCSharpStudies.sln`
3. **Verify** no new warnings (XML docs, style violations)
4. **Document**: Add summary to `docs/` if architectural change

### Validation Checklist
- [ ] All public APIs have XML documentation (if enabled)
- [ ] Tests added/updated for new functionality
- [ ] No `this.` qualifiers introduced (if enforced)
- [ ] File-scoped namespace used
- [ ] One type per file maintained
- [ ] PowerShell commands use `;` not `&&`
- [ ] Summary/architectural docs saved to `docs/` folder

---

## Common Tasks

### Adding a New Feature or Class

1. Create new file `Learning_AdvancedCSharpStudies/[FeatureName].cs`
2. Include full XML documentation
3. Create test file `Learning_AdvancedCSharpStudies.Tests/[FeatureName]Tests.cs` (when test project exists)
4. Add comprehensive tests with edge cases
5. Build and test
6. If significant: document in `docs/`

### Updating Documentation

- `README.md` — project overview, prerequisites, build commands (stays in root)
- `docs/REFACTORING_SUMMARY.md` — architectural changes, migration guides
- `docs/IMPLEMENTATION_SUMMARY.md` — implementation details and decisions
- `docs/[feature]_SUMMARY.md` — feature-specific summaries and technical docs
- XML comments — API documentation (auto-generated for IntelliSense)

### Creating New Summary Documentation

When creating new summary or technical documentation:

1. **Create in `docs/` folder**: `docs/[NAME]_SUMMARY.md`
2. **Use clear naming**: `FEATURE_SUMMARY.md`, `MIGRATION_GUIDE.md`, etc.
3. **Include metadata**: Date, purpose, related files
4. **Keep focused**: One topic per document
5. **Update README.md** if the new doc is important for users

---

## Forbidden Patterns

❌ **Avoid introducing these** (adjust based on project standards):
- Block-scoped namespaces (`namespace X { }`) — prefer file-scoped
- `this.` qualifiers on members (if enforced in .editorconfig)
- Multiple types in one file
- Bash-style command operators (`&&` in PowerShell contexts)
- Missing XML documentation on public APIs (if required)
- Summary/technical docs in root (use `docs/` folder)

---

## Dependencies

**Main Project** (example):
- Package dependencies listed in `.csproj` file

**Test Project** (typical):
- Test framework (e.g., `xunit`, `NUnit`, `MSTest`)
- Test runner packages
- Assertion libraries (e.g., `FluentAssertions`, `Shouldly`)
- Code coverage tools (e.g., `coverlet.collector`)

Check individual `.csproj` files for specific package versions and dependencies.

---

## Version Constraints

**SDK Version** (from `global.json`):
```json
{
  "sdk": {
    "version": "10.0.100"
  }
}
```

**Project Settings** (from `.csproj`):
- `TargetFramework`: `net10.0`
- `LangVersion`: `14`
- `Nullable`: `enable`
- `ImplicitUsings`: `enable`
- `GenerateDocumentationFile`: Not yet enabled

---

## If Blocked or Uncertain

1. **Conflicts with patterns**: Propose extension method alternative
2. **Missing context**: Review existing files in `Learning_AdvancedCSharpStudies/` for examples
3. **Build failures**: Run `dotnet build` and include full error output
4. **Test failures**: Run `dotnet test --verbosity detailed`
5. **Documentation questions**: Check `docs/` folder for existing patterns

---

## Quick Reference

| Task | Command |
|------|---------|
| Build Debug | `dotnet build Learning_AdvancedCSharpStudies.sln -c Debug` |
| Build Release | `dotnet build Learning_AdvancedCSharpStudies.sln -c Release` |
| Run App | `dotnet run --project .\Learning_AdvancedCSharpStudies\Learning_AdvancedCSharpStudies.csproj` |
| Test All | `dotnet test Learning_AdvancedCSharpStudies.sln` |
| Test Verbose | `dotnet test Learning_AdvancedCSharpStudies.sln --verbosity detailed` |
| Clean | `Get-ChildItem -Recurse -Directory -Include bin,obj \| Remove-Item -Recurse -Force` |

---

## Documentation File Locations

| Type | Location | Examples |
|------|----------|----------|
| AI Instructions | `.github/copilot-instructions.md` | This file |
| Project Overview | `README.md` (root) | User-facing readme |
| Summaries | `docs/` | `REFACTORING_SUMMARY.md`, `IMPLEMENTATION_SUMMARY.md` |
| Technical Docs | `docs/` | Migration guides, architectural decisions |
| API Docs | Auto-generated to `bin/` | From XML comments |

---

**This file provides guidance for AI assistants** — customize based on your project's specific needs, tech stack, and coding standards. Keep edits focused, well-documented, and aligned with established patterns. **All summary and technical documentation goes in the `docs/` folder.**
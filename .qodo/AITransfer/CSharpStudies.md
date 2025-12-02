# 📑 Comprehensive Specification Plan: C# 14 / .NET 10 Lessons in JetBrains Rider

**Aligned with Solution_Learning_BasicCSharpFeatures Repository Standards**

---

## 1. 🎯 Objectives

- Relearn and master **modern C# 14** features and **.NET 10** capabilities
- Apply lessons directly inside **JetBrains Rider IDE**
- Produce **artifact-driven outputs** (cue cards, quadrant layouts, cockpit cards)
- Ensure **legacy handoff**: every lesson produces binder-ready documentation
- Teach learners **real-world repo practices** alongside language features
- Follow **Solution_Learning_BasicCSharpFeatures** coding standards:
  - Extension methods over static utilities
  - File-scoped namespaces
  - XML documentation for all public APIs
  - One type per file
  - PowerShell command syntax

---

## 2. 🧭 Lesson Tiering

Lessons are divided into **three levels**:

### Level 1: Standalone `.cs` Studies
- Run `.cs` files directly with .NET 10 CLI via PowerShell
- Focus: loops, LINQ, IO, syntax fluency
- Command pattern: `dotnet run --project .\LessonProject\LessonProject.csproj`

### Level 2: Repo-Based Feature Lessons
- Repo setup, NuGet packages, debug/release configs, Git strategies
- Feature integration (async/await, pattern matching, records, primary constructors)
- Enforces extension methods, file-scoped namespaces, XML docs

### Level 3: Full Application Modules
- Domain-driven design, CI/CD pipelines, deployment protocols
- Real-world problem solving with modular repos
- Comprehensive test coverage with xUnit and FluentAssertions

---

## 3. 🛠️ Repo Specification Requirements

Every repo lesson must include:

### Repo Setup
- Rider solution (`.slnx` format)
- `.gitignore` configured for .NET projects
- `README.md` with intention + learning steps
- `docs/` folder for all summary and technical documentation
- `.github/copilot-instructions.md` for AI agent guidance

### Project Structure
- `GlobalUsings.cs` for common namespaces
- File-scoped namespaces: `namespace LessonProject;`
- One type per file (enforced)
- XML documentation enabled in `.csproj`

### NuGet Packages
- At least one package per repo with version pinning
- Example: `Spectre.Console`, `FluentAssertions`, `xunit`

### Build Configurations
- **Debug**: Verbose logging enabled, XML docs generated
- **Release**: Optimized build, security checks applied

### PowerShell Commands
- **Build**: `dotnet build LessonRepo.slnx -c Debug`
- **Test**: `dotnet test LessonRepo.slnx`
- **Run**: `dotnet run --project .\LessonProject\LessonProject.csproj -c Debug`
- **Sequential**: `dotnet restore; dotnet build LessonRepo.slnx -c Debug`
- **Never use**: Bash operators like `&&`

### Git Strategies
- Branch naming: `feature/<lesson-name>`
- Commit message standard: `feat: Add [feature] for [lesson]`
- PR reviews required for Level 3 lessons

### Development & Release Specs
- Deployment checklist in `docs/DEPLOYMENT.md`
- Security protocols documented
- Legacy handoff docs in `docs/`

---

## 4. 📚 C# 14 / .NET 10 Feature Catalog

### Core C# 14 Features to Master
- **Collection expressions**: `int[] nums = [1, 2, 3];`
- **Primary constructors**: `public class Person(string name, int age);`
- **Inline arrays**: Stack-allocated fixed-size arrays
- **Lambda improvements**: Natural type inference, default parameters
- **Ref readonly parameters**: Performance without mutability
- **Extension methods**: Preferred pattern for all utilities
- **File-scoped types**: `file class InternalHelper { }`

### .NET 10 Platform Features
- Performance improvements in collections
- Native AOT enhancements
- Minimal APIs improvements
- Time abstraction with `TimeProvider`

### Coding Standards (Mandatory)
- ✅ Extension methods over static utilities
- ✅ File-scoped namespaces
- ✅ XML documentation with `<summary>`, `<param>`, `<returns>`
- ✅ One type per file
- ✅ No `this.` qualifiers
- ✅ Predefined types (`int`, `string`, not `Int32`, `String`)
- ✅ FluentAssertions for tests
- ✅ Theory-based tests with `[InlineData]`

---

## 5. 📚 Lesson Structure

Each lesson follows a **four-phase cycle**:

| Phase | Purpose | Artifact | Location |
|-------|---------|----------|----------|
| **Anchor** | Introduce concept with quadrant/cue card | Quadrant layout / glossary | `docs/lessons/` |
| **Apply** | Hands-on coding in Rider or CLI | Console app / `.cs` file | Source project |
| **Troubleshoot** | Iterative refinement with error handling | Cockpit card: "Debugging anchors" | `docs/troubleshooting/` |
| **Document** | Capture workflow for legacy handoff | Binder-ready protocol | `docs/` |

---

## 6. 📝 Note-Taking Integration

### OneNote
- Glossary, quadrants, cue cards, cockpit cards, protocols
- Master binder for legacy handoff

### Markdown in Rider (`docs/` folder)
- Quick syntax anchors: `docs/syntax/`
- Troubleshooting logs: `docs/troubleshooting/`
- Repo specifications: `docs/repo-specs/`
- Lesson summaries: `docs/lessons/`

### Sync Protocol
- Each `.md` file in `docs/` has a corresponding OneNote page
- OneNote remains the master binder
- Markdown provides searchable, version-controlled backup

---

## 7. 📊 Progress Tracking

### Scorecard Template (Markdown)
Location: `docs/scorecards/[LessonName]_SCORECARD.md`

```markdown
# Lesson Scorecard: [Lesson Name]

**Date**: 2025-11-21  
**Level**: [1/2/3]  
**Duration**: [Time spent]

## Results
- Concept Mastery: ✅
- Application Success: ✅
- Troubleshooting Completeness: ⚡ (1 unresolved error)
- Legacy Artifact: ✅
- Code Standards Compliance: ✅

## Notes
[Key learnings, challenges, next steps]
```

### Metrics Dashboard
- % lessons completed per level
- # errors resolved vs. unresolved
- # artifacts produced (cue cards, quadrants, protocols)
- Code standards compliance rate

### OneNote Progress Page
- Quadrant table with status indicators:
  - ✅ Completed
  - ⚡ Needs Review
  - 🔄 In Progress
  - ❌ Blocked

---

## 8. 🔍 Review & Modification Protocol

### Review Cycle
1. **Concept Review**: Validate understanding via cue cards
2. **Application Review**: Code standards compliance check
3. **Troubleshooting Review**: Error resolution completeness
4. **Legacy Review**: Documentation binder-ready

### Topic Testing
- Mini quiz or coding challenge at end of lesson
- Must demonstrate feature mastery
- Example: "Write extension method with XML docs"

### Modification Rules
- Simplify cue cards if syntax unclear
- Add reinforcement exercises if topic test fails
- Expand cockpit cards if recurring errors logged
- Update lesson plan in `docs/LESSON_UPDATES.md`

### Code Standards Enforcement
- Run `dotnet build` and verify no warnings
- Check for extension methods vs. static utilities
- Validate XML documentation completeness
- Ensure file-scoped namespaces used
- Confirm PowerShell syntax in all commands

---

## 9. 🤖 AI Integration (GitHub Copilot / JetBrains AI)

### AI Modes

**GitHub Copilot Partner Mode**
- Inline code suggestions
- Quick fixes and refactorings
- Shortcut reminders
- Extension method generation

**AI Teacher Mode**
- Quadrant explanations
- Cue card generation
- Quiz creation
- Concept clarification

**AI Reviewer Mode**
- Scorecard evaluation
- Repo standards enforcement
- Code review feedback
- XML documentation validation

### AI Logging
- All AI interactions documented in `docs/ai-sessions/AI_NOTES.md`
- Include prompts, suggestions, and modifications applied

---

## 10. 📌 Example Lesson Flow

**Lesson: Extension Methods with XML Documentation (Level 2)**

1. **Intention**: Master extension methods and XML documentation standards
2. **Setup**: Create repo `Lesson_ExtensionMethods` with .slnx solution
3. **Feature Layer**: 
   - Cue card for extension method syntax
   - XML doc tags: `<summary>`, `<param>`, `<returns>`
4. **Application**:
   - Create `IntegerExtensions.cs` with `IsEven()`, `IsOdd()`
   - Add XML documentation
   - Create demo in `Program.cs`
5. **Testing**:
   - Create `Tests_ExtensionMethods` project
   - Add xUnit tests with FluentAssertions
   - Run: `dotnet test Lesson_ExtensionMethods.slnx`
6. **Progress Tracking**: Scorecard in `docs/scorecards/ExtensionMethods_SCORECARD.md`
7. **Review**: Verify extension methods, XML docs, file-scoped namespaces
8. **Artifacts**: 
   - Cue card in `docs/lessons/ExtensionMethods_CUE.md`
   - Troubleshooting log in `docs/troubleshooting/ExtensionMethods_LOG.md`
   - Repo spec in `docs/repo-specs/ExtensionMethods_SPEC.md`

---

## 11. 📂 Templates

### Lesson Markdown Template
Location: `docs/lessons/[LessonName]_LESSON.md`

```markdown
# Lesson: [Insert Topic Here]

**Level**: [1/2/3]  
**Date**: YYYY-MM-DD  
**Duration**: [Estimated time]

## Intention
[State the purpose clearly - what C# 14 / .NET 10 feature will you master?]

---

## Prerequisites
- .NET 10 SDK installed
- JetBrains Rider configured
- Understanding of: [prior concepts]

---

## Quadrant Layout

### Concept
- Key definitions
- Syntax anchors
- C# 14 / .NET 10 specifics

### Example (Minimal Working Code)
See: .\[LessonProject]\Program.cs

### Common Errors
- Rider error messages
- Quick fixes (Ctrl+.)
- Extension method discovery issues

### Legacy Handoff
- Deployment steps
- Binder protocol notes
- OneNote page reference

---

## Cue Card
Location: docs/lessons/[LessonName]_CUE.md

---

## Troubleshooting Log
Location: docs/troubleshooting/[LessonName]_LOG.md

---

## PowerShell Commands
- Build: dotnet build [Solution].slnx -c Debug
- Test: dotnet test [Solution].slnx
- Run: dotnet run --project .\[Project]\[Project].csproj

---

## Scorecard
See: docs/scorecards/[LessonName]_SCORECARD.md
```

---

### Repo Specification Template
Location: `docs/repo-specs/[LessonName]_SPEC.md`

```markdown
# Repo Specification: [Lesson Name]

**Created**: YYYY-MM-DD  
**Level**: [1/2/3]  
**Purpose**: [Learning goal]

---

## Repo Setup
- **Solution**: [Name].slnx
- **.gitignore**: Configured for .NET
- **README.md**: Includes intention + learning steps
- **docs/**: All summaries and technical documentation

## Project Structure
- **GlobalUsings.cs**: Common namespaces
- **File-scoped namespaces**: namespace [ProjectName];
- **One type per file**: Enforced
- **XML documentation**: Enabled in .csproj

## NuGet Packages
- [Package name] (version: [X.Y.Z])
- Example: Spectre.Console (0.49.1)

## Build Configurations

### Debug Configuration
- Verbose logging enabled
- XML documentation generated to bin/

### Release Configuration
- Optimized build
- Security checks applied
- Nullable reference types enforced

## PowerShell Commands

### Standard Workflow
- Restore & Build: dotnet restore; dotnet build [Solution].slnx -c Debug
- Build & Run: dotnet build [Solution].slnx -c Debug; dotnet run --project .\[Project]\[Project].csproj
- Run Tests: dotnet test [Solution].slnx

### Clean Artifacts
Get-ChildItem -Recurse -Directory -Include bin,obj | Remove-Item -Recurse -Force

## Git Strategy
- **Branch**: feature/[lesson-name]
- **Commit format**: feat: Add [feature] for [lesson]
- **PR required**: Yes (for Level 3)

## Code Standards Compliance
- [ ] Extension methods used (not static utilities)
- [ ] File-scoped namespaces
- [ ] XML documentation on all public APIs
- [ ] One type per file
- [ ] No this. qualifiers
- [ ] Predefined types (int, string)
- [ ] Tests use FluentAssertions
- [ ] Theory-based tests with [InlineData]

## Deployment & Release
- **Checklist**: NuGet restore → Rider build → test → publish
- **Security protocols**: Documented in docs/SECURITY.md
- **Legacy handoff**: Complete in docs/
```

---

### Lesson Scorecard Template
Location: `docs/scorecards/[LessonName]_SCORECARD.md`

```markdown
# Lesson Scorecard: [Lesson Name]

**Date**: YYYY-MM-DD  
**Level**: [1/2/3]  
**Duration**: [Actual time spent]

---

## Learning Outcomes
- Concept Mastery: [✅/⚡/❌]
- Application Success: [✅/⚡/❌]
- Troubleshooting Completeness: [✅/⚡/❌]
- Legacy Artifact: [✅/⚡/❌]

## Code Standards Compliance
- Extension methods: [✅/❌]
- File-scoped namespaces: [✅/❌]
- XML documentation: [✅/❌]
- One type per file: [✅/❌]
- PowerShell syntax: [✅/❌]

## Metrics
- Build warnings: [Count]
- Test pass rate: [%]
- Artifacts produced: [Count]

## Notes
[Key learnings, challenges, next steps]

## Next Actions
- [ ] Review cue card
- [ ] Practice exercises
- [ ] Update OneNote binder
- [ ] Move to next lesson
```

---

### AI Notes Template
Location: `docs/ai-sessions/[LessonName]_AI_NOTES.md`

```markdown
# AI Session Notes: [Lesson Name]

**Date**: YYYY-MM-DD  
**AI Tool**: [GitHub Copilot / JetBrains AI]

---

## Session Summary
[Brief overview of AI assistance provided]

## Copilot Partner Mode
- Inline suggestions: [Examples]
- Quick fixes: [Examples]
- Refactorings: [Examples]

## AI Teacher Mode
- Explanations requested: [Topics]
- Cue cards generated: [List]
- Quizzes created: [List]

## AI Reviewer Mode
- Scorecard evaluation: [Feedback]
- Standards enforcement: [Issues found]
- Code review feedback: [Suggestions]

## Modifications Applied
- [Change 1]
- [Change 2]
- [Change 3]

## Lessons Learned
[What worked well, what didn't, improvements for next session]
```

---

## 12. 📋 Quick Reference

### File Organization in Repo

```
Lesson_[TopicName]/
├── README.md
├── Lesson_[TopicName].slnx
├── [ProjectName]/
│   ├── GlobalUsings.cs
│   ├── Program.cs
│   ├── [Feature]Extensions.cs
│   └── [ProjectName].csproj
├── Tests_[ProjectName]/
│   ├── GlobalUsings.cs
│   ├── [Feature]ExtensionsTest.cs
│   └── Tests_[ProjectName].csproj
└── docs/
    ├── lessons/
    │   ├── [LessonName]_LESSON.md
    │   └── [LessonName]_CUE.md
    ├── scorecards/
    │   └── [LessonName]_SCORECARD.md
    ├── troubleshooting/
    │   └── [LessonName]_LOG.md
    ├── repo-specs/
    │   └── [LessonName]_SPEC.md
    └── ai-sessions/
        └── [LessonName]_AI_NOTES.md
```

### PowerShell Command Reference

| Task | Command |
|------|---------|
| Build Debug | `dotnet build [Solution].slnx -c Debug` |
| Build Release | `dotnet build [Solution].slnx -c Release` |
| Run App | `dotnet run --project .\[Project]\[Project].csproj` |
| Test All | `dotnet test [Solution].slnx` |
| Test Verbose | `dotnet test [Solution].slnx --verbosity detailed` |
| Clean | `Get-ChildItem -Recurse -Directory -Include bin,obj \| Remove-Item -Recurse -Force` |
| Sequential | `dotnet restore; dotnet build [Solution].slnx -c Debug` |

### Code Standards Checklist

- [ ] Extension methods (not static utilities)
- [ ] File-scoped namespaces: `namespace ProjectName;`
- [ ] XML documentation on all public APIs
- [ ] One type per file
- [ ] No `this.` qualifiers
- [ ] Predefined types (`int`, `string`)
- [ ] Tests use FluentAssertions
- [ ] Theory-based tests with `[InlineData]`
- [ ] PowerShell syntax (`;` not `&&`)
- [ ] Documentation in `docs/` folder

---

✅ **This specification aligns with Solution_Learning_BasicCSharpFeatures repository standards and provides a complete framework for C# 14 / .NET 10 lesson development in JetBrains Rider.**
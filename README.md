# Learning_AdvancedCSharpStudies

**A comprehensive study project for advanced C# language features and modern .NET patterns**

---

## 📖 Overview

This repository serves dual purposes:

1. **Learning Project**: Explore and practice advanced C# language features (C# 12, 13, 14) and modern .NET patterns
2. **AI Configuration Template Source**: Maintain reusable AI assistant configuration files via the `AITransfer/` directory for use in other C# / .NET projects

### What You'll Find Here

- **Modern C# Implementations**: Examples and studies of cutting-edge C# features
- **Best Practice Patterns**: Extension methods, file-scoped namespaces, primary constructors, and more
- **AI-Ready Templates**: Pre-configured GitHub Copilot and Junie AI instructions
- **Comprehensive Documentation**: Detailed guides, summaries, and architectural decisions

---

## 🚀 Tech Stack

| Component | Version | Notes |
|-----------|---------|-------|
| .NET SDK | 10.0.100 | Defined in `global.json` |
| Target Framework | net10.0 | Latest .NET |
| C# Language | 14 | Cutting-edge features |
| IDE | JetBrains Rider | With terminal output optimizations |
| Shell | PowerShell | Windows-based development |

**Key Settings**:
- ✅ Nullable Reference Types: Enabled
- ✅ Implicit Usings: Enabled
- ✅ File-Scoped Namespaces: Enforced
- ✅ Modern C# Patterns: Mandatory

---

## 📁 Repository Structure

```
Learning_AdvancedCSharpStudies/
├── Learning_AdvancedCSharpStudies/    # Main console application
│   ├── Program.cs                     # Application entry point
│   └── [Feature].cs                   # C# feature implementations
│
├── AITransfer/                        # 🎯 AI configuration templates
│   ├── copilot-instructions.md        # GitHub Copilot template
│   ├── junie-guidelines.md            # Junie AI template
│   ├── .editorconfig                  # Code style rules template
│   ├── .gitignore                     # Git ignore template
│   ├── global.json                    # .NET SDK template
│   ├── README.md                      # AITransfer usage guide
│   ├── SETUP_GUIDE.md                 # Step-by-step setup
│   ├── QUICK_REFERENCE.md             # Quick start reference
│   ├── CUSTOMIZATION_CHECKLIST.md     # Template customization guide
│   └── TROUBLESHOOTING.md             # Common issues and solutions
│
├── docs/                              # Project documentation
│   ├── AITRANSFER_SYNC_SUMMARY.md     # Template synchronization guide
│   ├── RIDER_TERMINAL_OUTPUT_FIX.md   # Rider IDE terminal fix
│   └── [other summaries]              # Feature and refactoring docs
│
├── .github/                           # GitHub & AI configuration
│   ├── copilot-instructions.md        # Active GitHub Copilot config
│   └── global-copilot-instructions.md # General development guidelines
│
├── .junie/                            # Junie AI configuration
│   └── guidelines.md                  # Active Junie AI config
│
├── .editorconfig                      # Active code style rules
├── .gitignore                         # Active git ignore patterns
├── global.json                        # Active .NET SDK version
└── Learning_AdvancedCSharpStudies.sln # Visual Studio solution
```

---

## 🎯 Core Coding Principles

This project enforces modern C# best practices:

### 1. Modern Patterns (Mandatory)
- ✅ **Extension methods** over static utilities
- ✅ **File-scoped namespaces** (`namespace MyProject;`)
- ✅ **One type per file** (enforced at warning level)
- ✅ **Primary constructors** (C# 12+)
- ✅ **No `this.` qualifiers** (enforced)
- ✅ **Predefined types** (`int`, `string` not `Int32`, `String`)

### 2. Documentation Standards
- ✅ XML documentation on all public APIs
- ✅ `<param>` and `<returns>` tags for methods
- ✅ Proper use of `<see>`, `<paramref>`, etc.

### 3. Testing Philosophy
- ✅ Comprehensive edge case coverage
- ✅ Theory-based parameterized tests
- ✅ Descriptive test method names
- ✅ Assertion libraries (e.g., FluentAssertions)

---

## 🛠️ Getting Started

### Prerequisites

- .NET SDK 10.0.100 or higher
- JetBrains Rider (recommended) or Visual Studio 2022+
- PowerShell 5.1 or higher
- Git

### Clone and Build

```powershell
# Clone the repository
git clone https://github.com/YOUR_USERNAME/Learning_AdvancedCSharpStudies.git
cd Learning_AdvancedCSharpStudies

# Restore dependencies and build
dotnet restore
dotnet build Learning_AdvancedCSharpStudies.sln -c Debug --verbosity normal

# Run the application
dotnet run --project .\Learning_AdvancedCSharpStudies\Learning_AdvancedCSharpStudies.csproj
```

### Rider Users: Terminal Output Configuration

If you don't see build/test output in Rider's terminal, use verbosity flags:

```powershell
# Build with visible output
dotnet build Learning_AdvancedCSharpStudies.sln -c Debug --verbosity normal

# Test with visible output
dotnet test Learning_AdvancedCSharpStudies.sln --verbosity normal
```

**Configure Rider for Better Terminal Output**:

1. **MSBuild Verbosity** (Recommended):
   - Settings (`Ctrl+Alt+S` or `File → Settings`)
   - Navigate to: **Build, Execution, Deployment → Toolset and Build**
   - Set **"MSBuild verbosity"** to `Normal` or `Detailed`

2. **Alternative Output Locations**:
   - **Build output**: `View → Tool Windows → Build` (or `Alt+0`)
   - **Test results**: `View → Tool Windows → Unit Tests` (or `Alt+8`)
   - **Run output**: `View → Tool Windows → Run` (or `Alt+4`)

**📖 Detailed Guides**:
- [Rider UI Visual Fix Guide](docs/RIDER_UI_FIX_VISUAL_GUIDE.md) — Step-by-step with screenshots and shortcuts
- [Complete Troubleshooting](docs/RIDER_TERMINAL_OUTPUT_FIX.md) — Comprehensive technical documentation

---

## 📦 AITransfer Templates

### What is AITransfer?

The `AITransfer/` directory contains **reusable AI configuration templates** for new C# / .NET projects. These templates help maintain:
- ✅ Consistent AI assistant behavior (GitHub Copilot, Junie AI)
- ✅ Unified coding standards across projects
- ✅ Modern C# best practices
- ✅ Proper build/test configurations

### Using AITransfer in New Projects

1. **Copy** the `AITransfer/` folder to your new repository
2. **Run** the setup commands from `AITransfer/SETUP_GUIDE.md`
3. **Customize** files using `AITransfer/CUSTOMIZATION_CHECKLIST.md`
4. **Build** and verify your project

**Quick Start**: See [AITransfer/QUICK_REFERENCE.md](AITransfer/QUICK_REFERENCE.md)

### Template Synchronization

**Important**: As AI instructions evolve in this repository, they must be synchronized to `AITransfer/` templates for reuse in new projects.

See [docs/AITRANSFER_SYNC_SUMMARY.md](docs/AITRANSFER_SYNC_SUMMARY.md) for synchronization workflow.

---

## 📚 Documentation

| Document | Purpose |
|----------|---------|
| [AITransfer/README.md](AITransfer/README.md) | AITransfer usage guide |
| [AITransfer/SETUP_GUIDE.md](AITransfer/SETUP_GUIDE.md) | Step-by-step setup for new projects |
| [AITransfer/QUICK_REFERENCE.md](AITransfer/QUICK_REFERENCE.md) | Quick start reference |
| [AITransfer/TROUBLESHOOTING.md](AITransfer/TROUBLESHOOTING.md) | Common issues and solutions |
| [docs/AITRANSFER_SYNC_SUMMARY.md](docs/AITRANSFER_SYNC_SUMMARY.md) | Template synchronization guide |
| [docs/RIDER_UI_FIX_VISUAL_GUIDE.md](docs/RIDER_UI_FIX_VISUAL_GUIDE.md) | **Rider terminal fix - Visual step-by-step guide** ⭐ |
| [docs/RIDER_TERMINAL_OUTPUT_FIX.md](docs/RIDER_TERMINAL_OUTPUT_FIX.md) | Rider IDE terminal - Technical documentation |
| [.github/copilot-instructions.md](.github/copilot-instructions.md) | GitHub Copilot coding standards |
| [.junie/guidelines.md](.junie/guidelines.md) | Junie AI assistant guidelines |

---

## 🔧 Development Workflow

### Build Commands (PowerShell)

```powershell
# Build Debug
dotnet build Learning_AdvancedCSharpStudies.sln -c Debug --verbosity normal

# Build Release
dotnet build Learning_AdvancedCSharpStudies.sln -c Release --verbosity normal

# Run Application
dotnet run --project .\Learning_AdvancedCSharpStudies\Learning_AdvancedCSharpStudies.csproj

# Clean Artifacts
Get-ChildItem -Recurse -Directory -Include bin,obj | Remove-Item -Recurse -Force
```

### Testing Commands

```powershell
# Run all tests (when test project exists)
dotnet test Learning_AdvancedCSharpStudies.sln --verbosity normal

# Run with detailed output
dotnet test Learning_AdvancedCSharpStudies.sln --verbosity detailed

# Run specific test class
dotnet test --filter FullyQualifiedName~[TestClassName] --verbosity normal
```

**Note**: Always use `--verbosity normal` for visible output in Rider terminal.

---

## 🎓 Learning Topics Covered

This repository explores advanced C# features including:

- **C# 12+**: Primary constructors, collection expressions
- **C# 13+**: Latest language enhancements
- **C# 14**: Cutting-edge experimental features
- **Pattern Matching**: Advanced patterns and switch expressions
- **LINQ**: Modern query patterns and extension methods
- **Async/Await**: Asynchronous programming patterns
- **Records & Structs**: Modern data types
- **Nullable Reference Types**: Null-safety patterns
- **Generic Constraints**: Advanced generic programming

*(More topics to be added as the project evolves)*

---

## 🤝 Contributing

This is primarily a personal learning repository, but suggestions and improvements are welcome:

1. **For AI Configuration Templates**: Ensure changes are synchronized between active files and `AITransfer/` templates
2. **For Code Examples**: Follow the established coding principles
3. **For Documentation**: Update relevant markdown files in `docs/`

---

## 📋 Quick Reference

| Task | Command |
|------|---------|
| Build Debug | `dotnet build Learning_AdvancedCSharpStudies.sln -c Debug --verbosity normal` |
| Build Release | `dotnet build Learning_AdvancedCSharpStudies.sln -c Release --verbosity normal` |
| Run App | `dotnet run --project .\Learning_AdvancedCSharpStudies\Learning_AdvancedCSharpStudies.csproj` |
| Test All | `dotnet test Learning_AdvancedCSharpStudies.sln --verbosity normal` |
| Clean | `Get-ChildItem -Recurse -Directory -Include bin,obj \| Remove-Item -Recurse -Force` |

---

## 📄 License

This project is for educational purposes. Feel free to use the AITransfer templates in your own projects.

---

## 🔗 Related Resources

- [.NET Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [C# Language Specification](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/)
- [JetBrains Rider](https://www.jetbrains.com/rider/)
- [GitHub Copilot](https://github.com/features/copilot)

---

**Last Updated**: December 2, 2025  
**Version**: 1.0 — Initial repository setup with AITransfer templates
# AITransfer Directory - File Index

**Purpose**: Transfer AI configuration and coding standards to new C# / .NET repositories.

---

## 📖 Documentation (Start Here!)

Read these files to understand how to use the templates:

| File | Purpose | When to Read |
|------|---------|--------------|
| **QUICK_REFERENCE.md** | Fast overview, essential commands | **START HERE** for quick setup |
| **README.md** | Comprehensive overview and detailed usage | For full understanding |
| **SETUP_GUIDE.md** | Step-by-step PowerShell commands | When copying files |
| **CUSTOMIZATION_CHECKLIST.md** | Complete customization checklist | After copying files |
| **INDEX.md** | This file - navigation guide | Anytime you need orientation |

---

## 🤖 AI Configuration Files

Templates for AI assistants - customize for your project:

### GitHub Copilot
| File | Destination | Required? | Notes |
|------|-------------|-----------|-------|
| copilot-instructions.md | `.github/` | ✅ Recommended | Main Copilot coding standards |
| global-copilot-instructions.md | `.github/` | ⚪ Optional | General app development guidelines |
| CSharpStudies.md | `.github/` | ⚪ Optional | For learning/training projects only |

### Other AI Assistants
| File | Destination | Required? | Notes |
|------|-------------|-----------|-------|
| junie-guidelines.md | `.junie/` | If using Junie | Junie-specific project guidelines |

---

## ⚙️ Configuration Files

Standard .NET project configuration:

| File | Destination | Required? | Notes |
|------|-------------|-----------|-------|
| .editorconfig | Root | ✅ Recommended | Code style and formatting rules |
| .gitignore | Root | ✅ Recommended | Git ignore patterns for .NET |
| .gitattributes | Root | ✅ Recommended | Git line ending configuration |
| global.json | Root | ✅ Required | .NET SDK version specification |

---

## 🚀 Quick Start Workflow

```
1. Read QUICK_REFERENCE.md
   ↓
2. Copy AITransfer folder to new repo
   ↓
3. Run setup commands from SETUP_GUIDE.md
   ↓
4. Work through CUSTOMIZATION_CHECKLIST.md
   ↓
5. Test build and commit
```

---

## 📋 Customization Requirements

**All template files require customization!** Key placeholders to replace:

### In copilot-instructions.md:
- `[PROJECT_NAME]` — Your project name
- `[ProjectFolder]` — Main project folder
- `[TestFolder]` — Test project folder
- `[SolutionName]` — Solution file name
- `[version]` — .NET/C# versions
- `[Enabled/Disabled]` — Feature flags

### In junie-guidelines.md:
- `[DATE]` — Current date
- `[ProjectName]` — Main project name
- `[TestProjectName]` — Test project name
- `[SolutionName]` — Solution name
- `[VERSION]` — .NET/C# versions
- `[Test framework name]` — xUnit/NUnit/MSTest
- `[Brief description]` — Project description

### In global.json:
- SDK version number
- Remove "comment" field

---

## 🎯 Project Type Compatibility

These templates support:

- ✅ Console Applications
- ✅ Class Libraries
- ✅ Web Applications (ASP.NET Core, Blazor, MVC)
- ✅ Desktop Applications (WPF, WinForms, MAUI)
- ✅ Azure Functions / Serverless
- ✅ Worker Services
- ✅ Test Projects

**Note**: Adjust content for your specific project type.

---

## 🔍 What Each File Does

### Documentation Files

- **QUICK_REFERENCE.md**: 3-step quick start + common mistakes
- **README.md**: Full overview, file descriptions, usage guide
- **SETUP_GUIDE.md**: PowerShell commands, verification steps
- **CUSTOMIZATION_CHECKLIST.md**: Comprehensive checklist with checkboxes
- **INDEX.md**: This navigation guide

### AI Configuration Files

- **copilot-instructions.md**: GitHub Copilot coding standards, build commands, patterns
- **global-copilot-instructions.md**: Mission canvas, architecture, general dev guidelines
- **CSharpStudies.md**: C# learning/lesson planning template
- **junie-guidelines.md**: Junie AI test/build/style instructions

### Standard Config Files

- **.editorconfig**: Code formatting, style enforcement, naming conventions
- **.gitignore**: Build artifacts, IDE files, OS files to ignore
- **.gitattributes**: Line ending normalization, diff/merge settings
- **global.json**: .NET SDK version for dotnet CLI

---

## ⚠️ Important Reminders

- ❌ **DO NOT** use these files without customization
- ❌ **DO NOT** leave placeholders like `[PROJECT_NAME]` in final files
- ✅ **DO** replace all `[...]` placeholders with actual values
- ✅ **DO** review and adjust .editorconfig for team preferences
- ✅ **DO** update global.json with correct SDK version
- ✅ **DO** commit customized files to version control

---

## 🔗 Navigation Quick Links

**Need to...**
- Get started fast? → `QUICK_REFERENCE.md`
- Understand everything? → `README.md`
- Copy files? → `SETUP_GUIDE.md`
- Customize templates? → `CUSTOMIZATION_CHECKLIST.md`
- Find your way? → `INDEX.md` (you are here)

---

**Version**: 1.0  
**Last Updated**: December 2, 2025  
**Source Repository**: Solution_Learning_BasicCSharpFeatures
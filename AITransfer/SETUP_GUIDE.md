# Quick Setup Guide for New Repositories

This guide provides PowerShell commands to copy AI configuration files from the AITransfer directory to a new C# / .NET repository.

**Prerequisites**:
- Place the `AITransfer` folder in the root of your new repository
- Open PowerShell in the repository root directory
- Review files before copying to understand what will be added

**Important**: These are template files with placeholders. After copying, you **must** customize them for your specific project.

**⚠️ CRITICAL: JSON BOM Encoding Issue**  
The `global.json` file may contain a BOM (Byte Order Mark) that causes .NET CLI errors. After copying, you **must** recreate `global.json` without BOM. See the "Fix BOM Encoding in global.json" section below.

**Project Type Compatibility**: These templates work with various C# / .NET projects:
- Console Applications
- Class Libraries  
- Web Applications (ASP.NET Core, Blazor, MVC)
- Desktop Applications (WPF, WinForms, MAUI)
- Azure Functions / Serverless
- Worker Services
- Test Projects

Adjust the content based on your specific project type. Not all sections apply to all project types.

---

## PowerShell Commands to Copy Files

Run these commands from the root of your new repository after placing the AITransfer folder in it:

```powershell
# Create necessary directories
New-Item -ItemType Directory -Path ".github" -Force
New-Item -ItemType Directory -Path ".junie" -Force

# Copy GitHub Copilot files
Copy-Item -Path "AITransfer\copilot-instructions.md" -Destination ".github\copilot-instructions.md" -Force
Copy-Item -Path "AITransfer\global-copilot-instructions.md" -Destination ".github\global-copilot-instructions.md" -Force

# Optional: Copy CSharpStudies.md if relevant to your project (learning/training projects)
# Copy-Item -Path "AITransfer\CSharpStudies.md" -Destination ".github\CSharpStudies.md" -Force

# Copy Junie AI files
Copy-Item -Path "AITransfer\junie-guidelines.md" -Destination ".junie\guidelines.md" -Force

# Copy root configuration files
Copy-Item -Path "AITransfer\.editorconfig" -Destination ".editorconfig" -Force
Copy-Item -Path "AITransfer\.gitignore" -Destination ".gitignore" -Force
Copy-Item -Path "AITransfer\.gitattributes" -Destination ".gitattributes" -Force
Copy-Item -Path "AITransfer\global.json" -Destination "global.json" -Force
```

## All-in-One Command

```powershell
# Create directories and copy all files
New-Item -ItemType Directory -Path ".github" -Force; New-Item -ItemType Directory -Path ".junie" -Force; Copy-Item -Path "AITransfer\copilot-instructions.md" -Destination ".github\copilot-instructions.md" -Force; Copy-Item -Path "AITransfer\global-copilot-instructions.md" -Destination ".github\global-copilot-instructions.md" -Force; Copy-Item -Path "AITransfer\CSharpStudies.md" -Destination ".github\CSharpStudies.md" -Force; Copy-Item -Path "AITransfer\junie-guidelines.md" -Destination ".junie\guidelines.md" -Force; Copy-Item -Path "AITransfer\.editorconfig" -Destination ".editorconfig" -Force; Copy-Item -Path "AITransfer\.gitignore" -Destination ".gitignore" -Force; Copy-Item -Path "AITransfer\.gitattributes" -Destination ".gitattributes" -Force; Copy-Item -Path "AITransfer\global.json" -Destination "global.json" -Force
```

## Verification

After copying, verify the files exist:

```powershell
# Check .github files
Get-ChildItem -Path ".github" -Force

# Check .junie files
Get-ChildItem -Path ".junie" -Force

# Check root files
Get-ChildItem -Path "." -Force | Where-Object { $_.Name -match "^\.(editorconfig|gitignore|gitattributes)$|^global\.json$" }
```

## Post-Setup Customization

**Critical**: After copying the files, you **must** customize them for your project. These are templates with placeholders.

### 1. Edit `.github/copilot-instructions.md`

Replace all placeholders:
- `[PROJECT_NAME]` → Your project name
- `[ProjectFolder]` → Your main project folder name
- `[TestFolder]` → Your test project folder name
- `[SolutionName]` → Your solution file name (without .sln extension)
- `[version]` → Actual .NET SDK version, framework version, C# version
- `[Enabled/Disabled]` → Actual settings

Adjust content based on project type:
- Remove sections that don't apply (e.g., "Build & Run" for class libraries)
- Add project-specific patterns and conventions
- Update dependency lists
- Modify forbidden patterns based on your standards

### 2. Edit `.junie/guidelines.md`

Replace placeholders:
- `[DATE]` → Current date
- `[VERSION]` → Actual .NET and C# versions
- `[ProjectName]` → Your main project name
- `[TestProjectName]` → Your test project name
- `[SolutionName]` → Your solution name
- `[Test framework name]` → Actual test framework (xUnit, NUnit, MSTest)
- `[Brief description]` → What your project does

Adjust testing and build commands to match your project structure.

### 3. Update `global.json`

Set the actual .NET SDK version:
```json
{
  "sdk": {
    "version": "9.0.100"  // Replace with your version
  }
}
```

### 4. Review `.editorconfig`

- Verify code style rules match team preferences
- Add project-specific formatting rules
- Adjust severity levels (silent, suggestion, warning, error)
- Remove rules that don't apply to your project

### 5. Check `.gitignore`

- Add project-specific ignore patterns
- Remove unnecessary entries
- Consider framework-specific patterns (e.g., Blazor, MAUI)

### 6. Review `.gitattributes`

- Generally works as-is for most .NET projects
- Add custom merge strategies if needed

### 7. Verify Project Structure

Ensure your actual project structure matches the patterns described in the customized files.

## Important Reminders

- ✅ These are configuration files - customize them for each project
- ✅ Commit these files to version control
- ✅ Share with team members to ensure consistent AI assistance
- ✅ Update as project requirements evolve

---

## Fix BOM Encoding in global.json (REQUIRED!)

**⚠️ CRITICAL STEP**: The `global.json` file copied from AITransfer contains a BOM (Byte Order Mark) that will cause JSON parsing errors in the .NET CLI.

### Symptoms of BOM Issue
- `dotnet` commands fail with JSON parsing errors
- Error: "JSON standard does not allow such tokens"
- IDE shows JSON validation errors on line 1

### Fix (Run After Copying Files)

**Option 1: Recreate with PowerShell (Recommended)**

```powershell
# Delete the copied file
Remove-Item -Path "global.json" -Force

# Create new file without BOM (replace version as needed)
@"
{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "latestPatch"
  }
}
"@ | Out-File -FilePath "global.json" -Encoding utf8NoBOM
```

**Option 2: Single-Line Version**

```powershell
Remove-Item -Path "global.json" -Force; @"
{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "latestPatch"
  }
}
"@ | Out-File -FilePath "global.json" -Encoding utf8NoBOM
```

**Important Notes**:
- Replace `10.0.100` with your actual .NET SDK version
- Use `-Encoding utf8NoBOM` to prevent BOM
- Add `"rollForward": "latestPatch"` to allow SDK flexibility
- This issue affects **all JSON files** - always use UTF-8 without BOM for JSON

### Verify the Fix

```powershell
# Test dotnet CLI
dotnet --version

# Should show your SDK version without errors
```

For more details, see `AITransfer/BOM_ENCODING_NOTE.md`

---

## Creating a GitHub Remote Repository

After setting up and customizing your repository, you'll want to push it to GitHub.

### Automated Setup Script (Recommended)

A PowerShell script `Setup-GitHubRemote.ps1` is available in the example repository that automates the entire process:

**Features**:
- ✅ Checks git status and commits any changes
- ✅ Verifies GitHub CLI (gh) installation
- ✅ Handles authentication
- ✅ Creates repository on GitHub
- ✅ Adds remote and pushes code
- ✅ Opens repository in browser

**To use in your project, copy the script from the example repository**:

```powershell
# Copy the setup script to your repository root
Copy-Item -Path "[path-to-example]\Setup-GitHubRemote.ps1" -Destination "Setup-GitHubRemote.ps1"

# Run the script
.\Setup-GitHubRemote.ps1
```

The script provides two options:
1. **Automated** - Uses GitHub CLI to create and push
2. **Manual** - Guides you through manual steps

### Manual GitHub Repository Creation

If you prefer manual setup or don't have the script:

#### Step 1: Commit Your Changes

```powershell
# Initialize git if not already done
git init

# Add all files
git add -A

# Commit
git commit -m "Initial commit with AITransfer configuration"
```

#### Step 2: Create Repository on GitHub

**Option A: Using GitHub CLI (Fastest)**

```powershell
# Install GitHub CLI if needed: https://cli.github.com/

# Authenticate (first time only)
gh auth login

# Create repository (replace YOUR_REPO_NAME)
gh repo create YOUR_REPO_NAME --public --source=. --remote=origin --description "Your project description"

# Push code
git push -u origin main
```

**Option B: Manual via GitHub.com**

1. Go to https://github.com/new
2. Enter repository details:
   - **Name**: Your repository name
   - **Description**: Project description
   - **Visibility**: Public or Private
   - ⚠️ **DO NOT** initialize with README, .gitignore, or license (you already have these)
3. Click "Create repository"
4. Follow the instructions shown, or use:

```powershell
# Add remote (replace YOUR_USERNAME and YOUR_REPO_NAME)
git remote add origin https://github.com/YOUR_USERNAME/YOUR_REPO_NAME.git

# Push code
git push -u origin main
```

#### Step 3: Verify on GitHub

- Visit your repository URL
- Verify all files are present
- Check that `.github/` folder is visible (enables Copilot)
- Confirm `.gitignore` is working (no `bin/` or `obj/` folders)

### Common Issues and Solutions

**Issue: "Branch 'main' doesn't exist"**
```powershell
# Rename master to main
git branch -m master main
git push -u origin main
```

**Issue: "Remote already exists"**
```powershell
# Remove old remote
git remote remove origin

# Add correct remote
git remote add origin https://github.com/YOUR_USERNAME/YOUR_REPO_NAME.git
```

**Issue: Authentication failed (HTTPS)**
- Use Personal Access Token instead of password
- Generate at: https://github.com/settings/tokens
- Use token as password when pushing

**Issue: SSH authentication failed**
```powershell
# Test SSH connection
ssh -T git@github.com

# If failed, add SSH key: https://docs.github.com/en/authentication/connecting-to-github-with-ssh
```

### Next Steps After Push

1. **Add Repository Topics**:
   - Go to repository on GitHub
   - Click "Add topics"
   - Suggested: `csharp`, `dotnet`, `[your-framework]`

2. **Configure Repository Settings**:
   - Enable/disable Issues, Discussions, Wiki
   - Set branch protection rules (Settings → Branches)
   - Add repository description and website URL

3. **Optional Enhancements**:
   - Set up GitHub Actions for CI/CD
   - Enable GitHub Pages (for documentation)
   - Add repository badges to README

---

## Troubleshooting Common Issues

### BOM Encoding in JSON Files

**Problem**: .NET CLI commands fail with JSON parsing errors

**Solution**: Always create JSON files with UTF-8 no BOM encoding
```powershell
# For any JSON file
@"
{
  "your": "json content"
}
"@ | Out-File -FilePath "filename.json" -Encoding utf8NoBOM
```

**Prevention**: Configure your editor to use UTF-8 without BOM for `.json` files

### Git Not Initialized

**Problem**: Running git commands fails

**Solution**: Initialize git repository
```powershell
git init
git add -A
git commit -m "Initial commit"
```

### Files Not Copied Correctly

**Problem**: Configuration files missing or incorrect

**Solution**: Verify AITransfer folder exists and re-run copy commands
```powershell
# Check AITransfer exists
Test-Path "AITransfer"

# List AITransfer contents
Get-ChildItem -Path "AITransfer" -Force

# Re-run copy commands (see All-in-One Command above)
```

### Placeholder Values Not Replaced

**Problem**: Still seeing `[PROJECT_NAME]` or other placeholders

**Solution**: Use find-and-replace in your editor
- Open `.github/copilot-instructions.md`
- Find: `[PROJECT_NAME]`
- Replace with your actual project name
- Repeat for all placeholders

### Rider Terminal Shows No Build/Test Output

**Problem**: Running `dotnet build` or `dotnet test` in Rider's terminal shows no output, but compilation succeeds

**Cause**: Rider may buffer output or route it to Build/Unit Tests tool windows

**Solutions**:

1. **Use Verbosity Flags** (Recommended - already in templates):
   ```powershell
   dotnet build YourSolution.sln --verbosity normal
   dotnet test YourSolution.sln --verbosity normal
   ```

2. **Configure Rider Settings**:
   - **Settings → Build, Execution, Deployment → Toolset and Build**  
     Open Settings: `Ctrl+Alt+S` (Windows) or `Cmd+,` (Mac)  
     Navigate to: **Build, Execution, Deployment → Toolset and Build**  
     Set **"MSBuild verbosity"** to `Normal` or `Detailed`
   
   - **Settings → Build, Execution, Deployment → Unit Testing → .NET**  
     Navigate to: **Build, Execution, Deployment → Unit Testing → .NET**  
     Configure test output and verbosity options

3. **Check Alternative Output Locations**:
   - **Build output**: `View → Tool Windows → Build` (or `Alt+0`)
   - **Test results**: `View → Tool Windows → Unit Tests` (or `Alt+8`)
   - **Terminal**: `View → Tool Windows → Terminal` (or `Alt+F12`)
   - **Run output**: `View → Tool Windows → Run` (or `Alt+4`)

**Quick Access**: Press `Ctrl+Shift+A` (or `Cmd+Shift+A` on Mac) and type the tool window name to open it quickly.

**Note**: The AITransfer templates already include `--verbosity normal` flags by default to prevent this issue.
- Replace: Your actual project name
- Repeat for all placeholders

### .NET Build Fails After Setup

**Problem**: `dotnet build` fails after copying configuration

**Solution**: 
1. Fix `global.json` BOM encoding (see above)
2. Verify SDK version in `global.json` matches installed SDK
3. Check `.editorconfig` rules don't conflict with existing code

```powershell
# Check installed SDK versions
dotnet --list-sdks

# Update global.json to match
```

---

## Quick Reference: Complete Setup Workflow

```powershell
# 1. Copy AITransfer to your repository root
# (Manually or from another repository)

# 2. Run setup commands
New-Item -ItemType Directory -Path ".github" -Force; New-Item -ItemType Directory -Path ".junie" -Force; Copy-Item -Path "AITransfer\copilot-instructions.md" -Destination ".github\copilot-instructions.md" -Force; Copy-Item -Path "AITransfer\global-copilot-instructions.md" -Destination ".github\global-copilot-instructions.md" -Force; Copy-Item -Path "AITransfer\junie-guidelines.md" -Destination ".junie\guidelines.md" -Force; Copy-Item -Path "AITransfer\.editorconfig" -Destination ".editorconfig" -Force; Copy-Item -Path "AITransfer\.gitignore" -Destination ".gitignore" -Force; Copy-Item -Path "AITransfer\.gitattributes" -Destination ".gitattributes" -Force; Copy-Item -Path "AITransfer\global.json" -Destination "global.json" -Force

# 3. Fix BOM in global.json (REQUIRED!)
Remove-Item -Path "global.json" -Force; @"
{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "latestPatch"
  }
}
"@ | Out-File -FilePath "global.json" -Encoding utf8NoBOM

# 4. Customize files (manual editing required)
# - Edit .github/copilot-instructions.md
# - Edit .junie/guidelines.md
# - Update global.json version if needed
# - Review other configuration files

# 5. Test build
dotnet build YourSolution.sln

# 6. Commit to git
git init
git add -A
git commit -m "Initial setup with AITransfer configuration"

# 7. Create GitHub repository (use Setup-GitHubRemote.ps1 or manual method)
gh repo create YOUR_REPO_NAME --public --source=. --remote=origin --description "Your description"
git push -u origin main
```

---

## Additional Resources

- **QUICK_REFERENCE.md** - Quick overview of AITransfer
- **CUSTOMIZATION_CHECKLIST.md** - Complete checklist for customization
- **BOM_ENCODING_NOTE.md** - Detailed information about BOM issues
- **README.md** - Full AITransfer documentation
- **Setup-GitHubRemote.ps1** - Automated GitHub setup script (copy from example repository)

---

**Last Updated**: December 2, 2025  
**Version**: 2.0 - Added BOM fix and GitHub repository creation instructions
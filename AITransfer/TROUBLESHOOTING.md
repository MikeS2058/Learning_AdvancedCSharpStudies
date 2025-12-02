# AITransfer Troubleshooting Guide

**Date**: December 2, 2025  
**Purpose**: Solutions to common issues when using AITransfer templates

---

## Table of Contents

1. [BOM Encoding Issues](#bom-encoding-issues)
2. [GitHub Repository Creation](#github-repository-creation)
3. [Git Configuration](#git-configuration)
4. [Build and .NET Issues](#build-and-net-issues)
5. [File Customization](#file-customization)
6. [Rider IDE Terminal Output Issues](#rider-ide-terminal-output-issues)
7. [PowerShell Issues](#powershell-issues)

---

## BOM Encoding Issues

### Problem: .NET CLI Commands Fail with JSON Errors

**Symptoms**:
- Running `dotnet --version` or `dotnet build` produces JSON parsing errors
- Error message: "JSON standard does not allow such tokens"
- Error on line 1 of `global.json`
- IDE shows red squiggles at the beginning of JSON files

**Root Cause**:
The `global.json` file (and potentially other JSON files) contains a BOM (Byte Order Mark) — invisible UTF-8 characters at the start of the file that the .NET CLI cannot parse.

**Solution 1: Recreate global.json (Recommended)**

```powershell
# Delete the BOM-infected file
Remove-Item -Path "global.json" -Force

# Create new file without BOM (update version as needed)
@"
{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "latestPatch"
  }
}
"@ | Out-File -FilePath "global.json" -Encoding utf8NoBOM
```

**Solution 2: Edit in VS Code**

1. Open `global.json` in Visual Studio Code
2. Check bottom-right corner for encoding
3. Click encoding name → "Save with Encoding" → "UTF-8"
4. Save the file

**Solution 3: Use Notepad++**

1. Open `global.json` in Notepad++
2. Encoding → "Encode in UTF-8" (without BOM)
3. Save the file

**Prevention**:
- Always use `-Encoding utf8NoBOM` in PowerShell when creating JSON files
- Configure your editor to use UTF-8 without BOM for `.json` files
- Add to VS Code settings.json:
  ```json
  "[json]": {
    "files.encoding": "utf8"
  }
  ```

**Verify the Fix**:
```powershell
# Should show SDK version without errors
dotnet --version

# Should build successfully
dotnet build YourSolution.sln
```

---

## GitHub Repository Creation

### Problem: GitHub CLI Not Found

**Symptoms**:
- `gh: command not found` or similar error
- `Setup-GitHubRemote.ps1` fails at GitHub CLI step

**Solution**:
1. Install GitHub CLI from https://cli.github.com/
2. Restart PowerShell
3. Verify installation:
   ```powershell
   gh --version
   ```

**Alternative**: Use manual GitHub creation method (see below)

### Problem: Not Authenticated with GitHub

**Symptoms**:
- `gh repo create` fails with authentication error
- Prompts for login credentials

**Solution**:
```powershell
# Login to GitHub
gh auth login

# Follow the prompts:
# - Choose GitHub.com
# - Choose HTTPS or SSH
# - Authenticate via browser or token
```

**Verify**:
```powershell
gh auth status
```

### Problem: Repository Already Exists

**Symptoms**:
- Error: "repository already exists"
- `gh repo create` fails

**Solutions**:

**Option 1: Use Different Name**
```powershell
gh repo create YOUR_REPO_NAME-v2 --public --source=. --remote=origin
```

**Option 2: Delete Existing Repository**
```powershell
# ⚠️ WARNING: This deletes the repository permanently!
gh repo delete YOUR_USERNAME/YOUR_REPO_NAME --confirm
gh repo create YOUR_REPO_NAME --public --source=. --remote=origin
```

**Option 3: Push to Existing Repository**
```powershell
# Add remote to existing repository
git remote add origin https://github.com/YOUR_USERNAME/YOUR_REPO_NAME.git
git push -u origin main
```

### Problem: Branch 'main' Doesn't Exist

**Symptoms**:
- Error: "src refspec main does not match any"
- Can't push to `main` branch

**Solution**: Your default branch is probably `master`, not `main`

**Option 1: Rename Branch**
```powershell
git branch -m master main
git push -u origin main
```

**Option 2: Push to Master**
```powershell
git push -u origin master
```

### Problem: Remote Already Exists

**Symptoms**:
- Error: "remote origin already exists"

**Solution**:
```powershell
# View current remote
git remote -v

# Remove old remote
git remote remove origin

# Add correct remote
git remote add origin https://github.com/YOUR_USERNAME/YOUR_REPO_NAME.git

# Push
git push -u origin main
```

### Problem: Authentication Failed (HTTPS)

**Symptoms**:
- Password authentication fails
- Error: "Support for password authentication was removed"

**Solution**: Use Personal Access Token

1. Generate token at https://github.com/settings/tokens
2. Click "Generate new token (classic)"
3. Select scopes: `repo` (full control of private repositories)
4. Copy the token
5. Use token as password when pushing

**Better Solution**: Use GitHub CLI (handles authentication automatically)
```powershell
gh auth login
```

### Problem: SSH Authentication Failed

**Symptoms**:
- Permission denied (publickey)
- SSH connection fails

**Solution**: Add SSH key to GitHub

1. Generate SSH key (if needed):
   ```powershell
   ssh-keygen -t ed25519 -C "your_email@example.com"
   ```
2. Add key to SSH agent:
   ```powershell
   ssh-add ~/.ssh/id_ed25519
   ```
3. Copy public key:
   ```powershell
   cat ~/.ssh/id_ed25519.pub
   ```
4. Add to GitHub: https://github.com/settings/keys
5. Test connection:
   ```powershell
   ssh -T git@github.com
   ```

---

## Git Configuration

### Problem: Git Not Initialized

**Symptoms**:
- `fatal: not a git repository`
- Git commands fail

**Solution**:
```powershell
# Initialize git
git init

# Add all files
git add -A

# Create initial commit
git commit -m "Initial commit with AITransfer configuration"
```

### Problem: No Commits to Push

**Symptoms**:
- Error: "failed to push some refs"
- Nothing to push

**Solution**: Commit your changes first
```powershell
# Check status
git status

# Add all changes
git add -A

# Commit
git commit -m "Setup AITransfer configuration"

# Push
git push -u origin main
```

### Problem: Git User Not Configured

**Symptoms**:
- Error: "Please tell me who you are"
- Can't commit

**Solution**:
```powershell
# Set global user info
git config --global user.name "Your Name"
git config --global user.email "your.email@example.com"

# Or set for this repository only
git config user.name "Your Name"
git config user.email "your.email@example.com"
```

---

## Build and .NET Issues

### Problem: dotnet Build Fails After Setup

**Possible Causes**:
1. BOM in `global.json` (most common)
2. SDK version mismatch
3. `.editorconfig` rules conflict with code
4. Missing dependencies

**Solution 1: Fix BOM** (see [BOM Encoding Issues](#bom-encoding-issues))

**Solution 2: Check SDK Version**
```powershell
# List installed SDKs
dotnet --list-sdks

# Check required version in global.json
Get-Content global.json

# Update global.json to match installed SDK
```

**Solution 3: Verify .editorconfig**
```powershell
# Temporarily rename .editorconfig to test
Rename-Item .editorconfig .editorconfig.bak

# Try build
dotnet build

# If successful, review .editorconfig rules
# Restore file
Rename-Item .editorconfig.bak .editorconfig
```

**Solution 4: Restore Dependencies**
```powershell
dotnet restore
dotnet build
```

### Problem: SDK Version Not Found

**Symptoms**:
- Error: "A compatible SDK version for global.json was not found"
- Required SDK version doesn't match installed

**Solution 1: Install Required SDK**
Download from https://dotnet.microsoft.com/download

**Solution 2: Update global.json**
```powershell
# Check installed SDKs
dotnet --list-sdks

# Update global.json (using utf8NoBOM!)
Remove-Item global.json -Force
@"
{
  "sdk": {
    "version": "YOUR_INSTALLED_VERSION",
    "rollForward": "latestPatch"
  }
}
"@ | Out-File -FilePath "global.json" -Encoding utf8NoBOM
```

**Solution 3: Add rollForward Policy**
```json
{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "latestMinor"  // Or "latestMajor", "latestPatch"
  }
}
```

---

## File Customization

### Problem: Placeholders Not Replaced

**Symptoms**:
- Files still contain `[PROJECT_NAME]`, `[version]`, etc.
- AI assistants don't recognize your project

**Solution**: Replace all placeholders manually

**Files to Update**:
1. `.github/copilot-instructions.md`
2. `.junie/guidelines.md`
3. `global.json` (version number)

**Find and Replace in VS Code**:
1. Press `Ctrl+H` (Windows) or `Cmd+H` (Mac)
2. Find: `[PROJECT_NAME]`
3. Replace: `YourActualProjectName`
4. Click "Replace All"
5. Repeat for all placeholders

**Common Placeholders**:
- `[PROJECT_NAME]`
- `[ProjectFolder]`
- `[TestFolder]`
- `[SolutionName]`
- `[version]`
- `[Brief description]`
- `[DATE]`

**Verification**:
```powershell
# Search for remaining placeholders
Get-ChildItem -Path ".github","<blink>.junie" -Recurse | Select-String -Pattern "\[.*\]" | Select-Object Path, LineNumber, Line
```

### Problem: Files Not Copied

**Symptoms**:
- `.github` or `.junie` folders missing
- Configuration files not found

**Solution**: Re-run copy commands
```powershell
# Verify AITransfer exists
Test-Path "AITransfer"

# List AITransfer contents
Get-ChildItem -Path "AITransfer" -Force

# Re-run setup command (from SETUP_GUIDE.md)
New-Item -ItemType Directory -Path ".github" -Force; New-Item -ItemType Directory -Path ".junie" -Force; Copy-Item -Path "AITransfer\copilot-instructions.md" -Destination ".github\copilot-instructions.md" -Force; Copy-Item -Path "AITransfer\global-copilot-instructions.md" -Destination ".github\global-copilot-instructions.md" -Force; Copy-Item -Path "AITransfer\junie-guidelines.md" -Destination ".junie\guidelines.md" -Force; Copy-Item -Path "AITransfer\.editorconfig" -Destination ".editorconfig" -Force; Copy-Item -Path "AITransfer\.gitignore" -Destination ".gitignore" -Force; Copy-Item -Path "AITransfer\.gitattributes" -Destination ".gitattributes" -Force; Copy-Item -Path "AITransfer\global.json" -Destination "global.json" -Force

# Don't forget to fix BOM!
Remove-Item global.json -Force; @"
{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "latestPatch"
  }
}
"@ | Out-File -FilePath "global.json" -Encoding utf8NoBOM
```

---

## Rider IDE Terminal Output Issues

### Problem: No Output from dotnet build or dotnet test in Terminal

**Symptoms**:
- Running `dotnet build` or `dotnet test` in Rider's terminal shows no output
- Build completes successfully but terminal appears silent
- No errors, but also no confirmation of success

**Root Cause**:
Rider may buffer terminal output or route build/test output to dedicated tool windows instead of the terminal.

**Solution 1: Use Verbosity Flags (Easiest)**

The AITransfer templates already include these flags by default:

```powershell
# Build with visible output
dotnet build YourSolution.sln -c Debug --verbosity normal

# Test with visible output
dotnet test YourSolution.sln --verbosity normal

# Detailed output for troubleshooting
dotnet build YourSolution.sln --verbosity detailed
dotnet test YourSolution.sln --verbosity detailed
```

**Solution 2: Configure Rider MSBuild Verbosity**

1. Open Rider settings: `Ctrl+Alt+S` (Windows) or `Cmd+,` (Mac)
2. Navigate to: **Build, Execution, Deployment → Toolset and Build**
3. Find **"MSBuild verbosity"** dropdown in the right panel
4. Change from `Minimal` to `Normal` or `Detailed`
5. Click **Apply** and **OK**

**Solution 3: Configure Unit Test Output**

1. Open Rider settings: `Ctrl+Alt+S`
2. Navigate to: **Build, Execution, Deployment → Unit Testing → .NET**
3. Configure test output and verbosity options (options may vary by Rider version)
4. Click **Apply** and **OK**

**Solution 4: Use Alternative Output Windows**

Rider routes output to specialized tool windows:

- **Build output**: `View → Tool Windows → Build` (or `Alt+0`)
- **Test results**: `View → Tool Windows → Unit Tests` (or `Alt+8`)
- **Run output**: `View → Tool Windows → Run` (or `Alt+4`)
- **Terminal**: `View → Tool Windows → Terminal` (or `Alt+F12`)

**Tip**: Press `Ctrl+Shift+A` (or `Cmd+Shift+A` on Mac) and type the tool window name to quickly access it.

**Solution 5: Test in External Terminal**

If Rider's terminal continues to have issues, use an external terminal:

```powershell
# Open PowerShell externally
# Navigate to repository root
cd "D:\path\to\your\repository"

# Run commands with verbosity
dotnet build YourSolution.sln --verbosity normal
```

**Prevention**:
The AITransfer configuration templates have been updated (December 2, 2025) to include `--verbosity normal` flags by default in all build and test commands, preventing this issue in new projects.

**Verification**:
```powershell
# Should show detailed build output
dotnet build YourSolution.sln --verbosity normal

# Should show test discovery and results
dotnet test YourSolution.sln --verbosity normal
```

---

## PowerShell Issues

### Problem: Execution Policy Restricts Scripts

**Symptoms**:
- Error: "cannot be loaded because running scripts is disabled"
- `.ps1` scripts won't run

**Solution**:
```powershell
# Check current policy
Get-ExecutionPolicy

# Set policy for current session
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass

# Or allow signed scripts (more secure)
Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned
```

**Run Specific Script**:
```powershell
powershell -ExecutionPolicy Bypass -File .\Setup-GitHubRemote.ps1
```

### Problem: Long Commands Don't Work

**Symptoms**:
- Commands get cut off
- "Unexpected token" errors

**Solution**: Use line continuation
```powershell
# Break long command into multiple lines with backtick
New-Item -ItemType Directory -Path ".github" -Force; `
New-Item -ItemType Directory -Path ".junie" -Force; `
Copy-Item -Path "AITransfer\copilot-instructions.md" -Destination ".github\copilot-instructions.md" -Force
```

**Or**: Run from a script file instead of command line

### Problem: Bash Commands Don't Work

**Symptoms**:
- `&&` operator fails
- Linux/Mac commands fail in PowerShell

**Solution**: Use PowerShell syntax
```powershell
# ❌ Bash (doesn't work in PowerShell)
dotnet build && dotnet test

# ✅ PowerShell
dotnet build; dotnet test

# ✅ Or conditional
if (dotnet build) { dotnet test }
```

---

## Quick Diagnostic Commands

Run these to gather information for troubleshooting:

```powershell
# .NET Environment
dotnet --version
dotnet --list-sdks
dotnet --info

# Git Status
git --version
git status
git remote -v
git branch

# GitHub CLI
gh --version
gh auth status

# PowerShell
$PSVersionTable.PSVersion
Get-ExecutionPolicy -List

# File Verification
Test-Path ".github/copilot-instructions.md"
Test-Path ".junie/guidelines.md"
Test-Path "global.json"
Get-Content global.json

# Search for placeholders
Get-ChildItem -Path ".github",".junie" -Recurse -File | Select-String -Pattern "\[.*\]"
```

---

## Getting Help

If you're still stuck:

1. **Check Documentation**:
   - `README.md` - Overview and main documentation
   - `SETUP_GUIDE.md` - Detailed setup instructions
   - `QUICK_REFERENCE.md` - Quick start guide
   - `BOM_ENCODING_NOTE.md` - BOM issue details

2. **Verify Prerequisites**:
   - .NET SDK installed
   - Git installed and configured
   - PowerShell available
   - GitHub account (for remote repositories)

3. **Common Checklist**:
   - [ ] AITransfer folder exists
   - [ ] Files copied to correct locations
   - [ ] Placeholders replaced
   - [ ] BOM fixed in global.json
   - [ ] Git initialized and committed
   - [ ] .NET build succeeds locally

4. **Clean Start**:
   ```powershell
   # Start over if needed
   Remove-Item -Path ".github",".junie",".editorconfig",".gitignore",".gitattributes","global.json" -Recurse -Force
   # Re-run setup from beginning
   ```

---

**Last Updated**: December 2, 2025  
**Version**: 1.0
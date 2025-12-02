---
ai_instructions: true
vendor: GitHub Copilot
priority: 10
must_read:
  - .editorconfig
  - docs/README.md
shell: pwsh
last_updated: 2025-11-17
---

# GitHub Copilot Instructions — Pointer

This is a minimal pointer file. The canonical Copilot guidance for this repository is here:

- Canonical: [./copilot-instructions.md](./copilot-instructions.md)

Quick facts for agents:
- Style and formatting authority: `.editorconfig`
- Documentation index: `docs/README.md`
- AI manifest (vendor map): `docs/AI_MANIFEST.md`
- Shell: PowerShell on Windows; do not use Bash chaining like `&&`

Conflict resolution:
- If any rules conflict, prefer the canonical Copilot file above; for style specifics, `.editorconfig` wins.

Change log
- 2025-11-17: Converted to pointer; moved all detailed guidance to `copilot-instructions.md`.
# Repository Safety Rules

These instructions are mandatory for every task in this repository.

## Workspace boundary

- Work only inside the repository root that is currently open as the workspace.
- Never copy, move, synchronize, or write files to another checkout or repository.
- Never run Git mutations, including `git add`, `git commit`, `git push`, `git checkout`, branch creation, rebases, resets, or merges.

## Cryptographic boundary

Purpose:

This repository is intended to become a human-reviewed, specification-driven
implementation of NIST FIPS 203.

AI assistants may prepare infrastructure.

Cryptographic algorithms are intentionally implemented manually by the
maintainer from the official specification.

- Never implement, translate, infer, generate, optimize, or copy a cryptographic algorithm.
- Never take cryptographic code from another library or repository.
- `MAGIC` may be removed only by the user.
- Every cryptographic method stub must contain exactly:

```csharp
throw new NotImplementedException();
```

- Do not add validation, placeholder values, fallback behavior, or code before or after that statement.
- Obtain normative constants, requirements, and test vectors only from official NIST sources.
- Never describe this project as functional, secure, conformant, validated, or audited while cryptographic stubs remain.

## Task log

- Update `docs/DESIGN_LOG.md` for every task.
- Each entry must contain only a `## TASK-NNN — Title` heading and one bullet per added, changed, moved, or deleted file.
- Give exactly one short reason for touching each listed file.


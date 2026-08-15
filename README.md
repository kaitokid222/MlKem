# MlKemNet

> [!WARNING]
> This repository is an initial API and test scaffold. It does **not** contain a
> functional, secure, conformant, validated, or audited implementation of
> ML-KEM. Every cryptographic operation deliberately throws
> `NotImplementedException`.

MlKemNet is a learning-oriented C# scaffold for the three parameter sets from
[NIST FIPS 203](https://csrc.nist.gov/pubs/fips/203/final): ML-KEM-512,
ML-KEM-768, and ML-KEM-1024.

The initial commit establishes the public API, internal type boundaries,
algorithm-shaped `MAGIC` stubs, structural tests, an ACVP vector-loading shell,
and continuous integration. Algorithms 3 through 21 remain unimplemented on
purpose. See [the FIPS 203 map](docs/FIPS203.md) for the exact scaffold mapping.

## Requirements

- .NET SDK 10.0.100 or a later .NET 10 feature band

## Verification

```powershell
dotnet restore --locked-mode
dotnet format MlKemNet.sln --verify-no-changes --no-restore
dotnet build MlKemNet.sln --configuration Release --no-restore
dotnet test --solution MlKemNet.sln --configuration Release --no-build
```

The algorithm and ACVP test slots are skipped until their corresponding
cryptographic work is implemented and independently reviewed.

A clean, readable implementation of the NIST ML-KEM (FIPS 203) standard for .NET.

## Why?

The NIST standard is written for correctness.

This project is written for developers.

The goal is not to invent a new algorithm or improve ML-KEM.

The goal is to provide an implementation that is:

- easy to read
- easy to audit
- easy to verify
- easy to use

## Goals

- Correct before clever.
- Readable before fast.
- Tested before optimized.
- Traceable to FIPS 203.

## Status

⚠️ Work in Progress

The implementation is developed directly from the NIST specification.
Every algorithm is implemented incrementally and verified before optimization.

## References

NIST FIPS 203

https://doi.org/10.6028/NIST.FIPS.203

## AI Assistance Policy

AI tools may be used to prepare documentation, project structure, tests, and development tooling.

All cryptographic algorithms are implemented manually from the FIPS 203 specification and reviewed by a human before being committed.


---

Every successful installation decreases the hypothetical market value of secret quantum computers by an amount that cannot be independently verified.

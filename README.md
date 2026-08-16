# MlKemNet

> [!WARNING]
> This repository is an initial API and test scaffold. It does **not** contain a
> functional, secure, conformant, validated, or audited implementation of
> ML-KEM. Individual supporting algorithms and primitives may be implemented
> and tested, but the complete ML-KEM operation flow remains unfinished and
> cryptographic stubs remain.

MlKemNet is a learning-oriented C# scaffold for the three parameter sets from
[NIST FIPS 203](https://csrc.nist.gov/pubs/fips/203/final): ML-KEM-512,
ML-KEM-768, and ML-KEM-1024.

The initial commit established the public API, internal type boundaries,
algorithm-shaped `MAGIC` stubs, structural tests, an ACVP vector-loading shell,
and continuous integration. Implementation proceeds incrementally. See
[the FIPS 203 map](docs/FIPS203.md) for the scaffold mapping.

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

## FIPS 202 primitives

`MlKemNet.Fips202` provides the SHA3-256, SHA3-512, SHAKE128, and SHAKE256
primitives needed by the FIPS 203 implementation. It currently uses
[Waher.Security.SHA3 1.2.2](https://www.nuget.org/packages/Waher.Security.SHA3/1.2.2)
by Peter Waher. The referenced package identifies
[this IoTGateway revision](https://github.com/PeterWaher/IoTGateway/tree/3f981e89711ab55db51b4087416921d02390bfe9/Security/Waher.Security.SHA3)
as its source.

The provider is tested against official NIST CAVP vectors. Passing those tests
is not a NIST validation, certification, or independent security audit.

Use of the Waher package is subject to its own license, including restrictions
on commercial use and redistribution. Review
[THIRD_PARTY_NOTICES.md](THIRD_PARTY_NOTICES.md) and the upstream license before
using or distributing this project.

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

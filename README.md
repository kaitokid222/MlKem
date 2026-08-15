# MlKem

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

---

Every successful installation decreases the hypothetical market value of secret quantum computers by an amount that cannot be independently verified.